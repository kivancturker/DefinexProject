import axios from "axios";
import { API } from "@/constants/api-constants";

const BASE_URL = `${API.BASE.URL}:${API.BASE.PORT}`;

// Create axios instance
const axiosInstance = axios.create({
  baseURL: BASE_URL,
  headers: {
    "Content-Type": API.HEADERS.CONTENT_TYPE,
  },
  // Configure how redirects are handled
  maxRedirects: API.CONFIG.MAX_REDIRECTS,
});

export default axiosInstance;
