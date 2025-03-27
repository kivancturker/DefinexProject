<template>
  <div>
    <!-- Add to cart Alert / Notification  -->
    <b-alert
      :show="showAlert"
      dismissible
      fade
      variant="success"
      @dismissed="$emit('dismissed')"
      @dismiss-count-down="$emit('dismiss-count-down', $event)"
    >
      <p class="font-weight-normal">{{ message }}</p>
    </b-alert>
  </div>
</template>

<script>
export default {
  name: "ShopAlerts",
  props: {
    showAlert: {
      type: Number,
      default: 0,
    },
    message: {
      type: String,
      default: "Successfully added to your list",
    },
  },
};
</script>
