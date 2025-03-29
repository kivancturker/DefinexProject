<template>
  <div>
    <!-- Banner Area -->
    <section id="common_banner_one">
      <div class="container">
        <div class="row">
          <div class="col-lg-12">
            <div class="common_banner_text">
              <h2>{{ this.title }}</h2>
              <b-breadcrumb
                :items="breadcrumbItems"
                class="bg-transparent"
              ></b-breadcrumb>
            </div>
          </div>
        </div>
      </div>
    </section>

    <!-- My Account-Area -->
    <section id="my-account_area" class="ptb-100">
      <div class="container">
        <div class="row">
          <div class="col-sm-12 col-md-3 col-lg-3">
            <!-- Nav tabs -->
            <MyAccountNavbar />
          </div>
          <div class="col-sm-12 col-md-9 col-lg-9">
            <div class="dashboard_content">
              <div class="myaccount-content">
                <h4 class="title">Dashboard</h4>
                <p>
                  From your account dashboard. you can easily check &amp; view
                  your
                  <nuxt-link to="/my-account/orders">recent orders</nuxt-link>,
                  manage your
                  <nuxt-link to="/my-account/addresses"
                    >shipping and billing addresses</nuxt-link
                  >
                  and
                  <nuxt-link to="/my-account/account-details"
                    >Edit your password and account details.</nuxt-link
                  >
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>

<script>
import MyAccountNavbar from "@/components/MyAccountNavbar.vue";

export default {
  name: "Dashboard",
  components: {
    MyAccountNavbar,
  },
  data() {
    return {
      title: "My Account",

      // Breadcrumb Items Data
      breadcrumbItems: [
        {
          text: "Home",
          to: "/",
        },
        {
          text: "Dashboard",
        },
      ],
    };
  },
  mounted() {
    // For scroll page top for every Route
    window.scrollTo(0, 0);
  },
  // Page head() Title, description for SEO
  head() {
    return {
      title: this.title,
      meta: [
        {
          hid: "description",
          name: "description",
          content:
            "My Account page - AndShop Ecommerce Vue js, Nuxt js Template",
        },
      ],
    };
  },
};
</script>
