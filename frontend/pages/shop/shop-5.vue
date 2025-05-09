<template>
  <div>
    <!-- Banner Area -->
    <ShopBanner :title="title" :items="breadcrumbItems" />

    <!-- Shop Main Area -->
    <section id="shop_main_area" class="ptb-100">
      <div class="container">
        <!-- Filters and Sort -->
        <ShopFilters
          viewType="grid"
          @filter-changed="randomProduct"
          @sort-changed="randomProduct"
        />

        <div class="row">
          <div class="col-lg-9">
            <!-- Loading indicator -->
            <div class="row" v-if="loading">
              <ShopLoader message="Loading products..." />
            </div>

            <!-- Error message -->
            <div class="row" v-else-if="error">
              <ShopError :message="error" />
            </div>

            <!-- Product grid -->
            <div class="row" v-else>
              <div
                class="col-lg-4 col-md-4 col-sm-6 col-12"
                v-for="(product, index) in shuffleproducts"
                :key="index"
                v-show="setPaginate(index)"
              >
                <ProductBox1
                  :product="product"
                  :index="index"
                  @showalert="alert"
                  @alertseconds="alert"
                />
              </div>

              <!-- Pagination -->
              <div class="col-lg-12">
                <ShopPagination
                  :total-items="shuffleproducts.length"
                  :items-per-page="paginate"
                  :current-page="current"
                  :paginate-range="paginateRange"
                  @page-changed="onPageChanged"
                />
              </div>
            </div>
          </div>

          <ShopSidebar />
        </div>
      </div>
    </section>

    <!-- Instagram Area -->
    <InstagramArea />

    <!-- Alerts -->
    <ShopAlerts
      :show-alert="dismissCountDown"
      @dismissed="dismissCountDown = 0"
      @dismiss-count-down="alert"
    />
  </div>
</template>

<script>
import { mapState } from "vuex";
import ProductBox1 from "~/components/product-box/ProductBox1";
import InstagramArea from "~/components/instagram/InstagramArea";
import ShopSidebar from "~/components/widgets/ShopSidebar";
import ShopBanner from "~/components/shop/ShopBanner";
import ShopFilters from "~/components/shop/ShopFilters";
import ShopPagination from "~/components/shop/ShopPagination";
import ShopAlerts from "~/components/shop/ShopAlerts";
import ShopLoader from "~/components/shop/ShopLoader";
import ShopError from "~/components/shop/ShopError";

export default {
  name: "shop-right-sidebar",
  components: {
    ProductBox1,
    InstagramArea,
    ShopSidebar,
    ShopBanner,
    ShopFilters,
    ShopPagination,
    ShopAlerts,
    ShopLoader,
    ShopError,
  },
  data() {
    return {
      title: "Shop",
      dismissCountDown: 0,
      loading: false,
      error: null,

      // Breadcrumb Items Data
      breadcrumbItems: [
        {
          text: "Home",
          to: "/",
        },
        {
          text: "Shop",
          to: "/shop/shop-5",
        },
      ],

      //Pagination
      current: 1,
      paginate: 12,
      paginateRange: 3,
      pages: [],
      paginates: "",
    };
  },
  computed: {
    ...mapState({
      shuffleproducts: (state) => state.products.shuffleproducts,
      storeLoading: (state) => state.products.loading,
      storeError: (state) => state.products.error,
    }),
  },
  watch: {
    storeLoading(newVal) {
      this.loading = newVal;
    },
    storeError(newVal) {
      this.error = newVal;
    },
  },
  mounted() {
    // Fetch products from server first
    this.loading = true;
    try {
      this.$store.dispatch("products/fetchProducts").then(() => {
        console.log("Products fetched successfully");
        this.getPaginate();
        this.updatePaginate(1);
        this.loading = this.storeLoading;
        this.error = this.storeError;
      });
    } catch (error) {
      console.error("Error fetching products:", error);
      this.error = error.message || "Failed to load products";
    }

    // For scroll page top for every Route
    window.scrollTo(0, 0);
  },
  methods: {
    // Product added Alert / notification
    alert(item) {
      this.dismissCountDown = item;
    },

    // For Pagination
    getPaginate() {
      this.paginates = Math.round(this.shuffleproducts.length / this.paginate);
      this.page = [];
      for (let i = 0; i < this.paginates; i++) {
        this.pages.push(i + 1);
      }
    },
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
    updatePaginate(i) {
      this.current = i;
      let start = 0;
      let end = 0;
      if (this.current < this.paginateRange - 1) {
        start = 1;
        end = start + this.paginateRange - 1;
      } else {
        start = this.current - 1;
        end = this.current + 1;
      }
      if (start < 1) {
        start = 1;
      }
      if (end > this.paginates) {
        end = this.paginates;
      }
      this.pages = [];
      for (let i = start; i <= end; i++) {
        this.pages.push(i);
      }
      return this.pages;
    },
    // For Shop Left Shorting and Up Shorting
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
    getallProduct() {
      this.$store.dispatch("products/getallProduct");
    },
    // Handle pagination page change
    onPageChanged(page) {
      this.updatePaginate(page);
    },
  },

  // Page head() Title, description for SEO
  head() {
    return {
      title: this.title,
      meta: [
        {
          hid: "description",
          name: "description",
          content: "Shop page - AndShop Ecommerce Vue js, Nuxt js Template",
        },
      ],
    };
  },
};
</script>
