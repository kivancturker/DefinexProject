// File: services/auth-service.js
import http from "@/utils/http-common";
import { AUTH } from "@/constants/auth-constants";
import { API } from "@/constants/api-constants";
import pkceUtils from "@/utils/pkce-util";
import storageUtils from "@/utils/storage-util";
import tokenUtils from "@/utils/token-util";
import profileUtils from "@/utils/profile-util";

class AuthService {
  // Initialize OIDC login flow with PKCE
  async login() {
    try {
      // Generate PKCE code_verifier and code_challenge
      const codeVerifier = pkceUtils.generateCodeVerifier();
      const codeChallenge = await pkceUtils.generateCodeChallenge(codeVerifier);

      // Store code_verifier in localStorage - we'll need it for the token request
      storageUtils.setItem(AUTH.STORAGE.CODE_VERIFIER, codeVerifier);

      // Construct OIDC authorization URL with required parameters
      const authUrl = new URL(
        `${API.BASE.GATEWAY_URL}/${AUTH.ENDPOINTS.AUTHORIZE}`
      );
      authUrl.searchParams.append("client_id", AUTH.CLIENT.ID);
      authUrl.searchParams.append("response_type", AUTH.PARAMS.RESPONSE_TYPE);
      authUrl.searchParams.append("scope", AUTH.CLIENT.SCOPE);
      authUrl.searchParams.append("redirect_uri", AUTH.CLIENT.REDIRECT_URI);
      const state = pkceUtils.generateRandomState();
      const nonce = pkceUtils.generateRandomState();
      authUrl.searchParams.append("state", state);
      authUrl.searchParams.append("nonce", nonce);
      authUrl.searchParams.append("response_mode", AUTH.PARAMS.RESPONSE_MODE);

      // Add PKCE parameters
      authUrl.searchParams.append("code_challenge", codeChallenge);
      authUrl.searchParams.append(
        "code_challenge_method",
        AUTH.PARAMS.CODE_CHALLENGE_METHOD
      );

      // Store state in localStorage for validation when the user returns
      storageUtils.setItem(AUTH.STORAGE.AUTH_STATE, state);
      storageUtils.setItem(AUTH.STORAGE.AUTH_NONCE, nonce);

      // Return the authorization URL
      return authUrl.toString();
    } catch (error) {
      console.error("Error generating PKCE code challenge:", error);
      throw error;
    }
  }

  // Handle the callback from the OIDC provider
  handleCallback(code, state) {
    // Verify the state matches what we stored
    const storedState = storageUtils.getItem(AUTH.STORAGE.AUTH_STATE);
    if (state !== storedState) {
      return Promise.reject("Invalid state parameter");
    }

    // Get the code_verifier we stored during login
    const codeVerifier = storageUtils.getItem(AUTH.STORAGE.CODE_VERIFIER);
    if (!codeVerifier) {
      return Promise.reject("Code verifier not found");
    }

    // Exchange the authorization code for tokens
    return tokenUtils
      .exchangeCodeForTokens(
        code,
        codeVerifier,
        API.BASE.GATEWAY_URL,
        AUTH.CLIENT.ID,
        AUTH.CLIENT.SECRET,
        AUTH.CLIENT.REDIRECT_URI
      )
      .then((response) => {
        // Store tokens
        storageUtils.setSession(response.data);
        return response.data;
      });
  }

  // Refresh the access token using the refresh token
  refreshToken() {
    const refreshToken = storageUtils.getItem(AUTH.STORAGE.REFRESH_TOKEN);
    if (!refreshToken) {
      return Promise.reject("No refresh token available");
    }

    return tokenUtils
      .refreshAccessToken(
        refreshToken,
        API.BASE.GATEWAY_URL,
        AUTH.CLIENT.ID,
        AUTH.CLIENT.SECRET
      )
      .then((response) => {
        storageUtils.setSession(response.data);
        return response.data;
      });
  }

  // Log the user out
  logout() {
    // Construct the end session URL
    const logoutUrl = new URL(
      `${API.BASE.GATEWAY_URL}/${AUTH.ENDPOINTS.END_SESSION}`
    );
    const idToken = storageUtils.getItem(AUTH.STORAGE.ID_TOKEN);

    if (idToken) {
      logoutUrl.searchParams.append("id_token_hint", idToken);
      logoutUrl.searchParams.append(
        "post_logout_redirect_uri",
        AUTH.CLIENT.POST_LOGOUT_REDIRECT_URI
      );
    }

    // Clear local storage
    storageUtils.clearSession();

    // Return the logout URL
    return logoutUrl.toString();
  }

  // Check if the user is authenticated
  isAuthenticated() {
    const expiresAt = JSON.parse(
      storageUtils.getItem(AUTH.STORAGE.EXPIRES_AT) || "0"
    );
    return new Date().getTime() < expiresAt;
  }

  // Get the user profile from the ID token
  getUserProfile() {
    const idToken = storageUtils.getItem(AUTH.STORAGE.ID_TOKEN);
    return profileUtils.getUserProfile(idToken);
  }

  // Get the access token for API calls
  getAccessToken() {
    return storageUtils.getItem(AUTH.STORAGE.ACCESS_TOKEN);
  }
}

export default new AuthService();
