import http from "@/utils/http-common";
import { AUTH } from "@/constants/auth-constants";

export default {
  // Exchange the authorization code for tokens
  exchangeCodeForTokens(
    code,
    codeVerifier,
    authUrl,
    clientId,
    clientSecret,
    redirectUri
  ) {
    const formData = new URLSearchParams();
    formData.append("client_id", clientId);
    formData.append("client_secret", clientSecret);
    formData.append("grant_type", AUTH.PARAMS.GRANT_TYPE.AUTHORIZATION_CODE);
    formData.append("code", code);
    formData.append("redirect_uri", redirectUri);
    formData.append("code_verifier", codeVerifier);

    return http.post(`${authUrl}/${AUTH.ENDPOINTS.TOKEN}`, formData, {
      headers: {
        "Content-Type": AUTH.HEADERS.CONTENT_TYPE,
      },
    });
  },

  // Refresh the access token using the refresh token
  refreshAccessToken(refreshToken, authUrl, clientId, clientSecret) {
    const formData = new URLSearchParams();
    formData.append("client_id", clientId);
    formData.append("client_secret", clientSecret);
    formData.append("grant_type", AUTH.PARAMS.GRANT_TYPE.REFRESH_TOKEN);
    formData.append("refresh_token", refreshToken);

    return http.post(`${authUrl}/${AUTH.ENDPOINTS.TOKEN}`, formData, {
      headers: {
        "Content-Type": AUTH.HEADERS.CONTENT_TYPE,
      },
    });
  },
};
