/**
 * Constants related to authentication and identity management
 * Organized by their specific use cases
 */

export const AUTH = {
  // Client configuration
  CLIENT: {
    ID: "DefineX",
    SECRET: "secret",
    SCOPE: "openid profile email DefineX",
    REDIRECT_URI: "http://localhost:3000/signin-oidc",
    POST_LOGOUT_REDIRECT_URI: "http://localhost:3000/signout-callback-oidc",
  },

  // Storage keys
  STORAGE: {
    // Token related
    ACCESS_TOKEN: "access_token",
    ID_TOKEN: "id_token",
    REFRESH_TOKEN: "refresh_token",
    EXPIRES_AT: "expires_at",

    // PKCE and state management
    CODE_VERIFIER: "code_verifier",
    AUTH_STATE: "auth_state",
    AUTH_NONCE: "auth_nonce",
  },

  // OAuth endpoints
  ENDPOINTS: {
    AUTHORIZE: "connect/authorize",
    TOKEN: "connect/token",
    END_SESSION: "connect/endsession",
  },

  // OAuth request parameters
  PARAMS: {
    // Response related
    RESPONSE_TYPE: "code",
    RESPONSE_MODE: "query",

    // PKCE related
    CODE_CHALLENGE_METHOD: "S256",

    // Grant types
    GRANT_TYPE: {
      AUTHORIZATION_CODE: "authorization_code",
      REFRESH_TOKEN: "refresh_token",
    },
  },

  // Headers
  HEADERS: {
    CONTENT_TYPE: "application/x-www-form-urlencoded",
  },
};

export default AUTH;
