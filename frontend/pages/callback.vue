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
  name: "Callback",
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
      // Parse the URL query parameters
      const urlParams = new URLSearchParams(window.location.search);
      const code = urlParams.get("code");
      const state = urlParams.get("state");
      const error = urlParams.get("error");

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
        this.errorMessage = "Invalid callback: missing parameters";
        return;
      }

      // Exchange the code for tokens
      AuthService.handleCallback(code, state)
        .then(() => {
          // Redirect to the home page or a protected route
          this.$router.push("/");
        })
        .catch((err) => {
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
