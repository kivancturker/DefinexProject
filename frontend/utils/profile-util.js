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
};
