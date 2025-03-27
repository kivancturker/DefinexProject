import { mapState } from "vuex";

export default {
  data() {
    return {
      dismissCountDown: 0,
      // Pagination data
      current: 1,
      paginate: 12,
      paginateRange: 3,
    };
  },
  computed: {
    ...mapState({
      shuffleproducts: (state) => state.products.shuffleproducts,
    }),
  },
  mounted() {
    // Scroll to top when page loads
    window.scrollTo(0, 0);
  },
  methods: {
    // Alert handling
    alert(item) {
      this.dismissCountDown = item;
    },

    // Product filtering methods
    randomProduct() {
      let array = this.shuffleproducts;
      for (var i = array.length - 1; i > 0; i--) {
        var j = Math.floor(Math.random() * (i + 1));
        var temp = array[i];
        array[i] = array[j];
        array[j] = temp;
      }
      this.$store.dispatch("products/shuffleProduct", array.slice(0, 30));
    },

    // Pagination methods
    setPaginate(i) {
      if (this.current === 1) {
        return i < this.paginate;
      } else {
        return (
          i >= this.paginate * (this.current - 1) &&
          i < this.current * this.paginate
        );
      }
    },

    // Handle page change from pagination component
    onPageChanged(page) {
      this.current = page;
    },
  },
};
