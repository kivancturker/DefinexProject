<template>
  <div class="logout-container">
    <div class="spinner-container" v-if="loading">
      <div class="spinner-border text-primary" role="status">
        <span class="sr-only">Loading...</span>
      </div>
      <p class="mt-3">Signing you out...</p>
    </div>
    <div v-if="error" class="error-container">
      <div class="alert alert-danger" role="alert">
        {{ errorMessage }}
      </div>
      <button class="btn btn-primary" @click="retryLogout">Try Again</button>
    </div>
  </div>
</template>

<script>
import AuthService from "@/services/auth-service";

export default {
  name: "Logout",
  data() {
    return {
      loading: true,
      error: false,
      errorMessage: "",
    };
  },
  mounted() {
    // Perform logout automatically when the page loads
    this.performLogout();
  },
  methods: {
    performLogout() {
      try {
        this.loading = true;
        this.error = false;

        // Get the logout URL
        const logoutUrl = AuthService.logout();

        // Redirect after a short delay to show the loading spinner
        setTimeout(() => {
          window.location.href = logoutUrl;
        }, 800);
      } catch (error) {
        console.error("Error during logout:", error);
        this.loading = false;
        this.error = true;
        this.errorMessage = "Failed to log out. Please try again.";
      }
    },
    retryLogout() {
      this.performLogout();
    },
  },
  head() {
    return {
      title: "Logout",
      meta: [
        {
          hid: "description",
          name: "description",
          content: "Signing out of your account",
        },
      ],
    };
  },
};
</script>

<style scoped>
.logout-container {
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
