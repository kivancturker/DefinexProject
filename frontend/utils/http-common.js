import axios from "axios";

const API_URL = "http://localhost";
const API_PORT = 5000;
const BASE_URL = `${API_URL}:${API_PORT}/api`;

// Auth configuration
const AUTH_URL = "https://localhost:44365"; // Identity Server URL
const CLIENT_ID = "definex_client";
const SCOPE = "definex";

// Create axios instance
const axiosInstance = axios.create({
  baseURL: BASE_URL,
  headers: {
    "Content-Type": "application/json",
  },
});

// Check if token is about to expire (within 1 minute)
const isTokenExpiring = (expiresAt) => {
  if (!expiresAt) return true;

  // Return true if token expires in less than 1 minute
  return new Date(expiresAt).getTime() - 60000 < new Date().getTime();
};

// Refresh token function
const refreshAccessToken = async () => {
  try {
    const refreshToken = localStorage.getItem("refreshToken");

    if (!refreshToken) {
      throw new Error("No refresh token available");
    }

    // Make request to identity server token endpoint
    const response = await axios.post(
      `${AUTH_URL}/connect/token`,
      new URLSearchParams({
        grant_type: "refresh_token",
        client_id: CLIENT_ID,
        refresh_token: refreshToken,
        scope: SCOPE,
      }),
      {
        headers: {
          "Content-Type": "application/x-www-form-urlencoded",
        },
      }
    );

    const { access_token, refresh_token, expires_in } = response.data;

    // Calculate expiration time
    const expiresAt = new Date(
      new Date().getTime() + expires_in * 1000
    ).toISOString();

    // Update tokens in storage
    localStorage.setItem("token", access_token);
    localStorage.setItem("refreshToken", refresh_token);
    localStorage.setItem("expiresAt", expiresAt);

    return access_token;
  } catch (error) {
    console.error("Error refreshing token:", error);
    // Handle refresh failure - redirect to login
    localStorage.removeItem("token");
    localStorage.removeItem("refreshToken");
    localStorage.removeItem("expiresAt");
    window.location.href = "/login";
    return null;
  }
};

// Add a request interceptor to handle authentication
let isRefreshing = false;
let failedQueue = [];

const processQueue = (error, token = null) => {
  failedQueue.forEach((prom) => {
    if (error) {
      prom.reject(error);
    } else {
      prom.resolve(token);
    }
  });

  failedQueue = [];
};

axiosInstance.interceptors.request.use(
  async (config) => {
    // Get token from storage
    let token = localStorage.getItem("token");
    const expiresAt = localStorage.getItem("expiresAt");

    // Check if token exists and is about to expire
    if (
      token &&
      isTokenExpiring(expiresAt) &&
      !config.url.includes("/connect/token")
    ) {
      if (!isRefreshing) {
        isRefreshing = true;
        token = await refreshAccessToken().finally(() => {
          isRefreshing = false;
        });
      } else {
        // Wait for the refresh to complete
        try {
          token = await new Promise((resolve, reject) => {
            failedQueue.push({ resolve, reject });
          });
        } catch (err) {
          return Promise.reject(err);
        }
      }
    }

    // If we have a token, add it to the request
    if (token) {
      config.headers["Authorization"] = `Bearer ${token}`;
    }

    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

// Response interceptor to handle 401 errors
axiosInstance.interceptors.response.use(
  (response) => {
    return response;
  },
  async (error) => {
    const originalRequest = error.config;

    // If error is 401 and we haven't tried to refresh the token yet
    if (error.response?.status === 401 && !originalRequest._retry) {
      if (isRefreshing) {
        try {
          const token = await new Promise((resolve, reject) => {
            failedQueue.push({ resolve, reject });
          });
          originalRequest.headers["Authorization"] = `Bearer ${token}`;
          return axiosInstance(originalRequest);
        } catch (err) {
          return Promise.reject(err);
        }
      }

      originalRequest._retry = true;
      isRefreshing = true;

      try {
        const token = await refreshAccessToken();
        processQueue(null, token);
        originalRequest.headers["Authorization"] = `Bearer ${token}`;
        return axiosInstance(originalRequest);
      } catch (refreshError) {
        processQueue(refreshError, null);
        return Promise.reject(refreshError);
      } finally {
        isRefreshing = false;
      }
    }

    return Promise.reject(error);
  }
);

// Auth helper functions
export const setAuthData = (accessToken, refreshToken, expiresIn) => {
  const expiresAt = new Date(
    new Date().getTime() + expiresIn * 1000
  ).toISOString();
  localStorage.setItem("token", accessToken);
  localStorage.setItem("refreshToken", refreshToken);
  localStorage.setItem("expiresAt", expiresAt);
};

export const clearAuthData = () => {
  localStorage.removeItem("token");
  localStorage.removeItem("refreshToken");
  localStorage.removeItem("expiresAt");
};

export default axiosInstance;
