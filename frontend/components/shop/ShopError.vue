<template>
  <div class="col-12 text-center">
    <div class="alert" :class="alertClass">
      {{ message }}
    </div>
  </div>
</template>

<script>
export default {
  name: "ShopError",
  props: {
    message: {
      type: String,
      required: true,
    },
    type: {
      type: String,
      default: "danger",
      validator: (value) =>
        ["danger", "warning", "info", "success"].includes(value),
    },
  },
  computed: {
    alertClass() {
      return `alert-${this.type}`;
    },
  },
};
</script>
