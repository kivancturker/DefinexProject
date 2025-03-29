<template>
  <div class="signout-container">
    <div class="signout-content">
      <h2>You have been signed out</h2>
      <p>You have successfully signed out of the application.</p>
      <button class="btn btn-primary mt-3" @click="goToHome">
        Return to Home
      </button>
    </div>
  </div>
</template>

<script>
export default {
  name: "SignoutCallbackOidc",
  methods: {
    goToHome() {
      this.$router.push("/");
    },
  },
  head() {
    return {
      title: "Signed Out",
      meta: [
        {
          hid: "description",
          name: "description",
          content: "You have been signed out of the application",
        },
      ],
    };
  },
};
</script>

<style scoped>
.signout-container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  width: 100%;
}

.signout-content {
  text-align: center;
  max-width: 500px;
  padding: 20px;
}
</style>
