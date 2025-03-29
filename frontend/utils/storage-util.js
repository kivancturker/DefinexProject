import { AUTH } from "@/constants/auth-constants";

export default {
  setSession(authResult) {
    const expiresAt = JSON.stringify(
      authResult.expires_in * 1000 + new Date().getTime()
    );

    localStorage.setItem(AUTH.STORAGE.ACCESS_TOKEN, authResult.access_token);
    localStorage.setItem(AUTH.STORAGE.ID_TOKEN, authResult.id_token);
    localStorage.setItem(AUTH.STORAGE.EXPIRES_AT, expiresAt);

    if (authResult.refresh_token) {
      localStorage.setItem(
        AUTH.STORAGE.REFRESH_TOKEN,
        authResult.refresh_token
      );
    }
  },

  clearSession() {
    localStorage.removeItem(AUTH.STORAGE.ACCESS_TOKEN);
    localStorage.removeItem(AUTH.STORAGE.ID_TOKEN);
    localStorage.removeItem(AUTH.STORAGE.EXPIRES_AT);
    localStorage.removeItem(AUTH.STORAGE.REFRESH_TOKEN);
    localStorage.removeItem(AUTH.STORAGE.AUTH_STATE);
    localStorage.removeItem(AUTH.STORAGE.AUTH_NONCE);
    localStorage.removeItem(AUTH.STORAGE.CODE_VERIFIER);
  },

  getItem(key) {
    return localStorage.getItem(key);
  },

  setItem(key, value) {
    localStorage.setItem(key, value);
  },
};
