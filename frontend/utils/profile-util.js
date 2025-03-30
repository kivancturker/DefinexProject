export default {
  // Get the user profile from the ID token
  getUserProfile(idToken) {
    if (!idToken) return null;

    try {
      // Decode the JWT token
      const base64Url = idToken.split(".")[1];
      const base64 = base64Url.replace(/-/g, "+").replace(/_/g, "/");
      const jsonPayload = decodeURIComponent(
        atob(base64)
          .split("")
          .map((c) => {
            return "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2);
          })
          .join("")
      );

      return JSON.parse(jsonPayload);
    } catch (err) {
      return null;
    }
  },

  // Decode JWT token (works with any token - id_token or access_token)
  decodeToken(token) {
    if (!token) return null;

    try {
      // Decode the JWT token
      const base64Url = token.split(".")[1];
      const base64 = base64Url.replace(/-/g, "+").replace(/_/g, "/");
      const jsonPayload = decodeURIComponent(
        atob(base64)
          .split("")
          .map((c) => {
            return "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2);
          })
          .join("")
      );

      return JSON.parse(jsonPayload);
    } catch (err) {
      console.error("Error decoding token:", err);
      return null;
    }
  },

  // Get user roles from access token
  getUserRoles(accessToken) {
    const decodedToken = this.decodeToken(accessToken);
    if (!decodedToken) return [];

    // Common claim names for roles in JWT tokens
    // The actual property might vary depending on your auth server configuration
    const roleClaims = [
      "role", // Direct role claim - This is what our token uses
      "roles",
      "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
      "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/role",
    ];

    // Try to find roles in the token
    for (const claim of roleClaims) {
      if (decodedToken[claim]) {
        // Handle both string and array formats
        return Array.isArray(decodedToken[claim])
          ? decodedToken[claim]
          : [decodedToken[claim]];
      }
    }

    return [];
  },

  // Check if user is an admin
  isAdmin(accessToken) {
    const roles = this.getUserRoles(accessToken);
    return roles.some(
      (role) =>
        role.toLowerCase() === "admin" || role.toLowerCase() === "administrator"
    );
  },

  // Check if user is a customer
  isCustomer(accessToken) {
    const roles = this.getUserRoles(accessToken);
    return roles.some((role) => role.toLowerCase() === "customer");
  },

  // Debug function to print roles and token info
  debugTokenInfo(accessToken) {
    try {
      const decoded = this.decodeToken(accessToken);
      const roles = this.getUserRoles(accessToken);

      return {
        isValid: !!decoded,
        roles: roles,
        isAdmin: this.isAdmin(accessToken),
        isCustomer: this.isCustomer(accessToken),
        claims: decoded || {},
        expiresAt: decoded?.exp
          ? new Date(decoded.exp * 1000).toISOString()
          : "N/A",
      };
    } catch (err) {
      return {
        isValid: false,
        error: err.message,
      };
    }
  },
};
