import AuthService from "@/services/auth-service";
import http from "@/utils/http-common";
import { API } from "@/constants/api-constants";

export default ({ app, store, redirect }, inject) => {
  // Add an interceptor to attach the access token to requests
  http.interceptors.request.use(
    (config) => {
      // Check if the user is authenticated
      if (AuthService.isAuthenticated()) {
        // Add access token to the Authorization header
        const token = AuthService.getAccessToken();
        if (token) {
          config.headers[API.HEADERS.AUTHORIZATION] = `Bearer ${token}`;
        }
      }
      return config;
    },
    (error) => {
      return Promise.reject(error);
    }
  );

  // Add an interceptor to handle 401 Unauthorized errors
  http.interceptors.response.use(
    (response) => {
      return response;
    },
    async (error) => {
      const originalRequest = error.config;

      // If the error is 401 and we have a refresh token
      if (
        error.response &&
        error.response.status === 401 &&
        !originalRequest._retry
      ) {
        originalRequest._retry = true;

        try {
          // Try to refresh the token
          await AuthService.refreshToken();

          // Retry the original request with the new token
          const token = AuthService.getAccessToken();
          originalRequest.headers[
            API.HEADERS.AUTHORIZATION
          ] = `Bearer ${token}`;
          return http(originalRequest);
        } catch (refreshError) {
          // If refresh token fails, redirect to login
          AuthService._clearSession();
          redirect("/login");
          return Promise.reject(refreshError);
        }
      }

      return Promise.reject(error);
    }
  );

  // Create auth object with methods
  const auth = {
    isAuthenticated: AuthService.isAuthenticated,
    getUserProfile: AuthService.getUserProfile,
    login: () => {
      window.location.href = AuthService.login();
    },
    logout: () => {
      window.location.href = AuthService.logout();
    },
  };

  // Inject auth into the context as $auth
  inject("auth", auth);
};
