<template>
  <div class="product-pagination mb-0" v-if="totalItems > itemsPerPage">
    <nav aria-label="Page navigation">
      <ul class="pagination">
        <li class="page-item">
          <a
            class="page-link"
            href="javascript:void(0)"
            @click="updatePage(currentPage - 1)"
          >
            <span aria-hidden="true">
              <i
                class="fa fa-chevron-left"
                style="font-size: 10px"
                aria-hidden="true"
              ></i>
            </span>
          </a>
        </li>
        <li
          class="page-item"
          v-for="(page, index) in pages"
          :key="index"
          :class="{ active: page == currentPage }"
        >
          <a
            class="page-link"
            href="javascript:void(0)"
            @click.prevent="updatePage(page)"
            >{{ page }}</a
          >
        </li>
        <li class="page-item">
          <a
            class="page-link"
            href="javascript:void(0)"
            @click="updatePage(currentPage + 1)"
          >
            <span aria-hidden="true">
              <i
                class="fa fa-chevron-right"
                style="font-size: 10px"
                aria-hidden="true"
              ></i>
            </span>
          </a>
        </li>
      </ul>
    </nav>
  </div>
</template>

<script>
export default {
  name: "ShopPagination",
  props: {
    totalItems: {
      type: Number,
      required: true,
    },
    itemsPerPage: {
      type: Number,
      default: 12,
    },
    currentPage: {
      type: Number,
      default: 1,
    },
    paginateRange: {
      type: Number,
      default: 3,
    },
  },
  data() {
    return {
      pages: [],
    };
  },
  watch: {
    currentPage() {
      this.getPages();
    },
    totalItems() {
      this.getPages();
    },
  },
  mounted() {
    this.getPages();
  },
  methods: {
    getPages() {
      const totalPages = Math.ceil(this.totalItems / this.itemsPerPage);
      let start = 0;
      let end = 0;

      if (this.currentPage < this.paginateRange - 1) {
        start = 1;
        end = start + this.paginateRange - 1;
      } else {
        start = this.currentPage - 1;
        end = this.currentPage + 1;
      }

      if (start < 1) {
        start = 1;
      }
      if (end > totalPages) {
        end = totalPages;
      }

      this.pages = [];
      for (let i = start; i <= end; i++) {
        this.pages.push(i);
      }
    },
    updatePage(page) {
      if (page < 1 || page > Math.ceil(this.totalItems / this.itemsPerPage)) {
        return;
      }
      this.$emit("page-changed", page);
    },
  },
};
</script>
