<template>
  <div class="login-container">
    <div class="spinner-container" v-if="loading">
      <div class="spinner-border text-primary" role="status">
        <span class="sr-only">Loading...</span>
      </div>
      <p class="mt-3">Redirecting to login...</p>
    </div>
    <div v-if="error" class="error-container">
      <div class="alert alert-danger" role="alert">
        {{ errorMessage }}
      </div>
      <button class="btn btn-primary" @click="redirectToLogin">
        Try Again
      </button>
    </div>
  </div>
</template>

<script>
import AuthService from "@/services/auth-service";

export default {
  name: "Login",
  data() {
    return {
      loading: true,
      error: false,
      errorMessage: "",
    };
  },
  mounted() {
    // Redirect to OIDC login page automatically
    this.redirectToLogin();
  },
  methods: {
    async redirectToLogin() {
      try {
        this.loading = true;
        this.error = false;

        // Get the login URL (now asynchronous with PKCE)
        const loginUrl = await AuthService.login();

        // Redirect after a short delay to show the loading spinner
        setTimeout(() => {
          window.location.href = loginUrl;
        }, 800);
      } catch (error) {
        console.error("Error during login redirect:", error);
        this.loading = false;
        this.error = true;
        this.errorMessage = "Failed to initialize login. Please try again.";
      }
    },
  },
  head() {
    return {
      title: "Login",
      meta: [
        {
          hid: "description",
          name: "description",
          content: "Login to your account",
        },
      ],
    };
  },
};
</script>

<style scoped>
.login-container {
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
