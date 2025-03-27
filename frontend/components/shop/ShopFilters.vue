<template>
  <div class="row">
    <div class="col-lg-6 col-md-12">
      <div class="product_filter">
        <div class="customs_selects">
          <select
            name="product"
            class="customs_sel_box"
            @change="filterChanged"
          >
            <option value="Filter">Filter</option>
            <option value="most_popular">Most Popular</option>
            <option value="best_seller">Best Seller</option>
            <option value="tranding">Tranding</option>
            <option value="featured">Featured</option>
          </select>
        </div>
      </div>
    </div>
    <div class="col-lg-6 col-md-12">
      <div class="product_shot">
        <div class="product_shot_title">
          <p>Sort By:</p>
        </div>
        <div class="customs_selects">
          <select name="product" class="customs_sel_box" @change="sortChanged">
            <option value="popularity">Sort by Popularity</option>
            <option value="new">Sort by new</option>
            <option value="low">Price: low to high</option>
            <option value="high">Price: high to low</option>
          </select>
        </div>
        <div class="product_shot_view">
          <ul>
            <li>
              <nuxt-link
                :to="'/shop/shop-3'"
                :class="{ active: viewType === 'list' }"
              >
                <i class="fas fa-list"></i>
              </nuxt-link>
            </li>
            <li>
              <nuxt-link
                :to="'/shop/shop-2'"
                :class="{ active: viewType === 'grid-large' }"
              >
                <i class="fas fa-th-large"></i>
              </nuxt-link>
            </li>
            <li>
              <nuxt-link :to="'/shop'" :class="{ active: viewType === 'grid' }">
                <i class="fas fa-th"></i>
              </nuxt-link>
            </li>
          </ul>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "ShopFilters",
  props: {
    viewType: {
      type: String,
      default: "grid",
    },
  },
  methods: {
    filterChanged(event) {
      this.$emit("filter-changed", event.target.value);
    },
    sortChanged(event) {
      this.$emit("sort-changed", event.target.value);
    },
  },
};
</script>
