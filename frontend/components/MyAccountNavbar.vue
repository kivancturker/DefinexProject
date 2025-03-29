<template>
  <div class="dashboard_tab_button">
    <b-navbar-nav>
      <b-nav-item to="/my-account"
        ><i class="fas fa-tachometer-alt"></i>Dashboard</b-nav-item
      >
      <b-nav-item to="/my-account/orders"
        ><i class="fas fa-cart-arrow-down"></i>Orders</b-nav-item
      >
      <b-nav-item to="/my-account/downloads"
        ><i class="fas fa-cloud-download-alt"></i>Downloads</b-nav-item
      >
      <b-nav-item to="/my-account/addresses"
        ><i class="fas fa-map-marker-alt"></i>Addresses</b-nav-item
      >
      <b-nav-item to="/my-account/account-details"
        ><i class="fas fa-user"></i>Account details</b-nav-item
      >
      <b-nav-item @click="logout"
        ><i class="fas fa-sign-out-alt"></i>Logout</b-nav-item
      >
    </b-navbar-nav>
  </div>
</template>

<script>
export default {
  name: "MyAccountNavbar",
  methods: {
    logout() {
      this.$router.push("/logout");
    },
  },
};
</script>
