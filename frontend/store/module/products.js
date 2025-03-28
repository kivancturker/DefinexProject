import ProductService from "@/services/product-service";

const state = {
  productslist: [],
  products: [],
  shuffleproducts: [],
  wishlist: [],
  compare: [],
  searchProduct: [],
  loading: false,
  error: null,
};

// getters
const getters = {
  getcollectionProduct: (state) => {
    return (collection = state.products.filter((product) => {
      return collection === product.collection;
    }));
  },
  getProductById: (state) => {
    return (id) =>
      state.products.find((product) => {
        return product.productId === +id;
      });
  },
  wishlistItems: (state) => {
    return state.wishlist;
  },
  compareItems: (state) => {
    return state.compare;
  },
};

// mutations
const mutations = {
  setProducts: (state, products) => {
    state.productslist = products;
    state.products = products;
    state.shuffleproducts = products;
    state.error = null;
  },
  setLoading: (state, loading) => {
    state.loading = loading;
  },
  setError: (state, error) => {
    state.error = error;
  },
  addToWishlist: (state, payload) => {
    const product = state.products.find(
      (item) => item.productId === payload.productId
    );
    const wishlistItems = state.wishlist.find(
      (item) => item.productId === payload.productId
    );
    if (wishlistItems) {
    } else {
      state.wishlist.push({
        ...product,
      });
    }
  },
  removeWishlistItem: (state, payload) => {
    const index = state.wishlist.indexOf(payload);
    state.wishlist.splice(index, 1);
  },
  addToCompare: (state, payload) => {
    const product = state.products.find(
      (item) => item.productId === payload.productId
    );
    const compareItems = state.compare.find(
      (item) => item.productId === payload.productId
    );
    if (compareItems) {
    } else {
      state.compare.push({
        ...product,
      });
    }
  },
  removeCompareItem: (state, payload) => {
    const index = state.compare.indexOf(payload);
    state.compare.splice(index, 1);
  },
  searchProduct: (state, payload) => {
    payload = payload.toLowerCase();
    state.searchProduct = [];
    if (payload.length) {
      state.products.filter((product) => {
        if (product.name.toLowerCase().includes(payload)) {
          state.searchProduct.push(product);
        }
      });
    }
  },
  shuffleProduct: (state, payload) => {
    state.shuffleproducts = payload;
  },
  getallProduct: (state, payload) => {
    state.shuffleproducts = products.data;
  },
};

// actions
const actions = {
  fetchProducts: async (context) => {
    try {
      console.log("Store: fetchProducts action started");
      context.commit("setLoading", true);
      context.commit("setError", null);

      const products = await ProductService.getAll();
      console.log("Store: Received products", products);

      // Check if products is an actual array
      if (!products || !Array.isArray(products)) {
        console.error("Store: Products data is not an array", products);
        context.commit("setError", "Invalid data received from server");
        context.commit("setProducts", []);
        return [];
      }

      if (products.length === 0) {
        // Handle empty products array - could be due to isSuccess: false
        console.warn("Store: Empty products array received");
        context.commit("setError", "No products available");
      } else {
        context.commit("setProducts", products);
      }

      return products;
    } catch (error) {
      console.error("Store: Error fetching products:", error);

      // Set appropriate error message based on error type
      let errorMessage = "Failed to load products";
      if (error.isNetworkError) {
        errorMessage = error.message;
      } else if (error.errors && error.errors.length > 0) {
        errorMessage = error.errors.join(", ");
      } else if (error.message) {
        errorMessage = error.message;
      }

      context.commit("setError", errorMessage);
      context.commit("setProducts", []);
      return [];
    } finally {
      context.commit("setLoading", false);
      console.log("Store: fetchProducts action completed");
    }
  },
  addToWishlist: (context, payload) => {
    context.commit("addToWishlist", payload);
  },
  removeWishlistItem: (context, payload) => {
    context.commit("removeWishlistItem", payload);
  },
  addToCompare: (context, payload) => {
    context.commit("addToCompare", payload);
  },
  removeCompareItem: (context, payload) => {
    context.commit("removeCompareItem", payload);
  },
  searchProduct: (context, payload) => {
    context.commit("searchProduct", payload);
  },
  shuffleProduct: (context, payload) => {
    context.commit("shuffleProduct", payload);
  },
  getallProduct: (context) => {
    context.commit("getallProduct");
  },
};

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
};
