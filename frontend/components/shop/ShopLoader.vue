<template>
  <div class="col-12 text-center">
    <div class="spinner-border text-primary" role="status">
      <span class="sr-only">Loading...</span>
    </div>
    <p>{{ message }}</p>
  </div>
</template>

<script>
export default {
  name: "ShopLoader",
  props: {
    message: {
      type: String,
      default: "Loading products...",
    },
  },
};
</script>
