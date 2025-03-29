<template>
  <div class="callback-container">
    <div class="spinner-container" v-if="loading">
      <div class="spinner-border text-primary" role="status">
        <span class="sr-only">Loading...</span>
      </div>
      <p class="mt-3">Processing login...</p>
    </div>
    <div v-if="error" class="error-container">
      <div class="alert alert-danger" role="alert">
        {{ errorMessage }}
      </div>
      <button class="btn btn-primary" @click="retryLogin">Try Again</button>
    </div>
  </div>
</template>

<script>
import AuthService from "@/services/auth-service";

export default {
  name: "SigninOidc",
  data() {
    return {
      loading: true,
      error: false,
      errorMessage: "",
    };
  },
  mounted() {
    this.handleCallback();
  },
  methods: {
    handleCallback() {
      // For form_post response_mode, the params could be in POST body
      // In Nuxt, accessing form POST parameters directly is tricky,
      // so we'll try both query parameters and any data that might be available

      // Try to get code and state from multiple sources
      const code =
        this.$route.query.code ||
        (this.$route.params && this.$route.params.code) ||
        (document.querySelector('input[name="code"]') &&
          document.querySelector('input[name="code"]').value);

      const state =
        this.$route.query.state ||
        (this.$route.params && this.$route.params.state) ||
        (document.querySelector('input[name="state"]') &&
          document.querySelector('input[name="state"]').value);

      const error =
        this.$route.query.error ||
        (this.$route.params && this.$route.params.error) ||
        (document.querySelector('input[name="error"]') &&
          document.querySelector('input[name="error"]').value);

      // Log what we received for debugging
      console.log("Received callback params:", { code, state, error });

      // Check if there was an error in the callback
      if (error) {
        this.error = true;
        this.loading = false;
        this.errorMessage = `Authentication error: ${error}`;
        return;
      }

      // Check if code and state are present
      if (!code || !state) {
        this.error = true;
        this.loading = false;
        this.errorMessage =
          "Invalid callback: missing parameters. Make sure the redirect URI is correct.";
        console.error("Missing code or state. Route:", this.$route);
        return;
      }

      // Exchange the code for tokens
      AuthService.handleCallback(code, state)
        .then(() => {
          // Redirect to the home page or a protected route
          this.$router.push("/");
        })
        .catch((err) => {
          console.error("Auth callback error:", err);
          this.error = true;
          this.loading = false;
          this.errorMessage = `Authentication failed: ${err}`;
        });
    },
    retryLogin() {
      window.location.href = AuthService.login();
    },
  },
  head() {
    return {
      title: "Processing Login",
      meta: [
        {
          hid: "description",
          name: "description",
          content: "Processing your authentication",
        },
      ],
    };
  },
};
</script>

<style scoped>
.callback-container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  width: 100%;
}

.spinner-container,
.error-container {
  text-align: center;
}

.error-container {
  max-width: 500px;
  padding: 20px;
}
</style>
