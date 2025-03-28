<template>
  <div class="rating-stars">
    <div class="stars">
      <i
        v-for="index in 5"
        :key="index"
        :class="['fas', 'fa-star', { active: index <= rating }]"
      ></i>
    </div>
    <span v-if="reviewCount !== undefined && reviewCount !== null">
      ({{ reviewCount }}
      {{ reviewCount === 1 ? "Customer Review" : "Customer Reviews" }})
    </span>
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
    reviewCount: {
      type: Number,
      default: null,
    },
  },
};
</script>

<style scoped>
.rating-stars {
  display: flex;
  align-items: center;
}

.stars {
  display: flex;
  margin-right: 5px;
}

.fa-star {
  color: #ddd;
  margin-right: 2px;
}

.fa-star.active {
  color: #ffc107;
}
</style>
