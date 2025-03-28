<template>
  <div>
    <div class="product_wrappers_list">
      <div class="row">
        <div class="col-lg-3">
          <div class="thumb">
            <nuxt-link
              :to="{ path: '/product/' + product.productId }"
              class="image"
            >
              <img :src="product.imageUrl" :alt="product.name" />
            </nuxt-link>
          </div>
        </div>
        <div class="col-lg-9">
          <div class="content">
            <div class="product_para_top">
              <h4 class="title text-capitalize">
                <nuxt-link :to="{ path: '/product/' + product.productId }">{{
                  product.name
                }}</nuxt-link>
              </h4>
              <p>{{ product.description }}</p>
              <span class="price">
                <span class="new" v-if="false"
                  >${{ discountedPrice(product) }}</span
                >
                <span class="new" v-else>${{ product.price }}</span>
              </span>
            </div>

            <div class="actions">
              <button
                @click="addToWishlist(product)"
                class="action wishlist bg-transparent"
                title="Wishlist"
              >
                <i class="far fa-heart"></i>
              </button>
              <button
                id="toggle-btn"
                @click="toggleModal"
                class="action quickview bg-transparent"
                title="Quick view"
              >
                <i class="fas fa-expand"></i>
              </button>
              <button
                @click="addToCompare(product)"
                class="action compare bg-transparent"
                title="Compare"
              >
                <i class="fas fa-exchange-alt"></i>
              </button>
            </div>
            <button
              @click="addToCart(product)"
              class="add-to-cart offcanvas-toggle btn btn_sm theme-btn-one btn-black-overlay mt-3"
              title="Add To Cart"
            >
              Add To Cart
            </button>
          </div>
        </div>
      </div>

      <!-- Modal Area Start-->
      <div>
        <b-modal
          ref="product-details-popup"
          centered
          hide-footer
          title="Using Component Methods"
          class="product_one_modal_top"
          id="product_slider_one"
        >
          <template #modal-header="{ close }">
            <button
              type="button"
              class="close close_modal_icon"
              @click="close()"
            >
              <span aria-hidden="true"><i class="fas fa-times"></i></span>
            </button>
          </template>

          <div>
            <div class="row">
              <div class="col-lg-5 col-md-6 col-sm-12 col-12">
                <div class="products_modal_sliders">
                  <div v-swiper:mySwiper="swiperOption" ref="mySwiper">
                    <div class="swiper-wrapper">
                      <div
                        class="swiper-slide"
                        v-for="(imag, index) in []"
                        :key="index"
                      >
                        <img
                          :src="product.imageUrl"
                          :id="index"
                          class="img-fluid bg-img"
                          alt="product image"
                        />
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-lg-7 col-md-6 col-sm-12 col-12">
                <div class="modal_product_content_one">
                  <h3 class="text-capitalize">{{ product.name }}</h3>
                  <RatingStars :rating="product.rating" />
                  <div v-if="false">
                    ${{ discountedPrice(product) }}
                    <del>${{ product.price }}</del>
                  </div>
                  <div v-else>${{ product.price }}</div>
                  <p>{{ product.description }}</p>
                  <div class="variable-single-item">
                    <span>Color</span>
                    <ul class="color-variant d-flex">
                      <li
                        v-bind:class="{ active: activeColor == variant }"
                        v-for="(variant, variantIndex) in []"
                        :key="variantIndex"
                      >
                        <a
                          :class="[variant]"
                          v-bind:style="{ 'background-color': variant }"
                          @click="
                            sizeVariant(variantIndex, variantIndex, variant)
                          "
                        ></a>
                      </li>
                    </ul>
                  </div>
                  <form id="product_count_form_one">
                    <div class="product_count_one">
                      <b-form-spinbutton
                        id="sb-inline"
                        min="1"
                        max="100"
                        v-model="quantity"
                        inline
                        class="border-0"
                      ></b-form-spinbutton>
                      <a
                        href="javascript:void(0)"
                        @click="addToCart(product)"
                        class="theme-btn-one btn-black-overlay btn_sm"
                        >Add To Cart</a
                      >
                    </div>
                  </form>
                  <div class="modal_share_icons_one">
                    <h4>SHARE THIS PRODUCT</h4>
                    <div class="posted_icons_one">
                      <a href="#!"><i class="fab fa-facebook-f"></i></a>
                      <a href="#!"><i class="fab fa-instagram"></i></a>
                      <a href="#!"><i class="fab fa-twitter"></i></a>
                      <a href="#!"><i class="fab fa-linkedin-in"></i></a>
                      <a href="#!"><i class="fab fa-google-plus-g"></i></a>
                      <a href="#!"><i class="fab fa-pinterest-p"></i></a>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </b-modal>
      </div>
      <!-- Modal Area End-->
    </div>
  </div>
</template>

<script>
import { mapState } from "vuex";
import RatingStars from "@/components/ui/RatingStars.vue";

export default {
  name: "ProductBox2",
  components: {
    RatingStars,
  },
  props: ["product", "index"],

  data() {
    return {
      // Product Quanity Increment/ Decrement Data
      quantity: 1,

      imageSrc: "",
      cartProduct: {},
      compareProduct: {},
      dismissSecs: 3,
      dismissCountDown: 0,

      quantity: 1,

      activeColor: "",
      selectedSize: "",
      qty: "",
      size: [],
      swiperOption: {
        slidesPerView: 1,
        spaceBetween: 20,
        freeMode: true,
      },
    };
  },
  computed: {
    ...mapState({
      productslist: (state) => state.products.productslist,
    }),

    swiper() {
      return this.$refs.mySwiper.swiper;
    },
  },
  mounted() {
    // Commented out for the refactored version
    // this.uniqColor = this.product.variants[0].color;
    // this.sizeVariant(this.product.variants[0].image_id);
    // Active default color
    // this.activeColor = this.uniqColor;
    // this.changeSizeVariant(this.product.variants[0].size);
  },

  methods: {
    // Product details Popup id Methods
    toggleModal() {
      this.$refs["product-details-popup"].toggle("#toggle-btn");
    },

    // Image Url
    getImageUrl(path) {
      return require("@/assets/img/product-image/" + path);
    },

    // Product Add To Cart realted methods
    addToCart: function (product) {
      this.dismissCountDown = this.dismissSecs;
      this.cartProduct = product;
      this.$emit("showalert", this.dismissCountDown);
      this.$store.dispatch("cart/addToCart", product);
    },

    // After Add to cart Alert
    countDownChanged(dismissCountDown) {
      this.dismissCountDown = dismissCountDown;
      this.$emit("alertseconds", this.dismissCountDown);
    },

    // Discount Price
    discountedPrice(product) {
      const price = product.price - (product.price * product.discount) / 100;
      return price;
    },
    addToWishlist: function (product) {
      this.dismissCountDown = this.dismissSecs;
      this.$emit("showalert", this.dismissCountDown);
      this.$store.dispatch("products/addToWishlist", product);
    },
    addToCompare: function (product) {
      this.dismissCountDown = this.dismissSecs;
      this.$emit("showalert", this.dismissCountDown);
      this.$store.dispatch("products/addToCompare", product);
    },

    // Display Unique color
    Color(variants) {
      const uniqColor = [];
      for (let i = 0; i < Object.keys(variants).length; i++) {
        if (uniqColor.indexOf(variants[i].color) === -1) {
          uniqColor.push(variants[i].color);
        }
      }
      return uniqColor;
    },
    // Change Size Variant
    changeSizeVariant(variant) {
      this.selectedSize = variant;
    },
    slideTo(id) {
      this.swiper.slideTo(id, 1000, false);
    },
    sizeVariant(id, slideId, color) {
      // this.swiper.slideTo(slideId, 1000, false)
      this.size = [];
      this.activeColor = color;
      // Adjusted for the new structure
      // this.product.variants.filter((item) => {
      //   if (id === item.image_id) {
      //     this.size.push(item.size);
      //   }
      // });
    },
  },
};
</script>
