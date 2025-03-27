<template>
  <section id="common_banner_one">
    <div class="container">
      <div class="row">
        <div class="col-lg-12">
          <div class="common_banner_text">
            <h2>{{ title }}</h2>
            <b-breadcrumb :items="items" class="bg-transparent"></b-breadcrumb>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
export default {
  name: "ShopBanner",
  props: {
    title: {
      type: String,
      default: "Shop",
    },
    items: {
      type: Array,
      default: () => [
        {
          text: "Home",
          to: "/",
        },
        {
          text: "Shop",
          to: "/shop",
        },
      ],
    },
  },
};
</script>
