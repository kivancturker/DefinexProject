export default {
  // PKCE: Generate a random state or nonce
  generateRandomState() {
    return (
      Math.random().toString(36).substring(2, 15) +
      Math.random().toString(36).substring(2, 15)
    );
  },

  // PKCE: Generate a random code verifier
  generateCodeVerifier() {
    const array = new Uint8Array(32);
    window.crypto.getRandomValues(array);
    return this.base64UrlEncode(array);
  },

  // PKCE: Generate a code challenge from the code verifier
  async generateCodeChallenge(codeVerifier) {
    const hashedData = await this.sha256(codeVerifier);
    return this.base64UrlEncode(hashedData);
  },

  // PKCE: Helper to hash the code verifier
  async sha256(plain) {
    const encoder = new TextEncoder();
    const data = encoder.encode(plain);
    return window.crypto.subtle.digest("SHA-256", data);
  },

  // PKCE: Helper to base64url encode
  base64UrlEncode(buffer) {
    // If it's an ArrayBuffer, convert it to a regular array
    if (buffer instanceof ArrayBuffer) {
      buffer = new Uint8Array(buffer);
    }

    // If it's a Uint8Array, create a base64 string
    if (buffer instanceof Uint8Array) {
      let str = "";
      for (let i = 0; i < buffer.length; i++) {
        str += String.fromCharCode(buffer[i]);
      }
      buffer = str;
    }

    // Standard base64 encoder
    let base64 = btoa(buffer);

    // Convert to base64url (URL-safe)
    return base64.replace(/\+/g, "-").replace(/\//g, "_").replace(/=+$/, "");
  },
};
