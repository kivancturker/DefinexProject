/**
 * Constants related to API endpoints and configuration
 */
export const API = {
  // Base URLs
  BASE: {
    URL: "http://localhost",
    PORT: 5000,
    GATEWAY_URL: "http://localhost:5000",
    CHAT_URL: "http://localhost:5224/chat",
  },

  // Headers
  HEADERS: {
    CONTENT_TYPE: "application/json",
    AUTHORIZATION: "Authorization",
  },

  // Configuration
  CONFIG: {
    MAX_REDIRECTS: 5,
  },
};

export default API;
