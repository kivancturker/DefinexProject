import axios from "axios";

const API_URL = "http://localhost";
const API_PORT = 5000;
const BASE_URL = `${API_URL}:${API_PORT}`;

// Auth configuration
// const AUTH_URL = "https://localhost:44365"; // Identity Server URL
// const CLIENT_ID = "definex_client";
// const SCOPE = "definex";

// Create axios instance
const axiosInstance = axios.create({
  baseURL: BASE_URL,
  headers: {
    "Content-Type": "application/json",
  },
  // Configure how redirects are handled
  maxRedirects: 5,
});

export default axiosInstance;
