<template>
  <div>
    <div v-if="rating" class="reviews_rating">
      <i
        v-for="index in 5"
        :key="index"
        :class="['fas', 'fa-star', { active: index <= rating }]"
      ></i>
    </div>
    <div v-else class="product-review">
      <span>No Rating</span>
    </div>
  </div>
</template>

<script>
export default {
  name: "RatingStars",
  props: {
    rating: {
      type: Number,
      default: 0,
      validator: (value) => value >= 0 && value <= 5,
    },
  },
};
</script>

<style scoped>
.reviews_rating {
  display: flex;
  align-items: center;
  margin-bottom: 10px;
}

.fa-star {
  color: #ddd;
  margin-right: 2px;
}

.fa-star.active {
  color: #ffc107;
}
</style>
