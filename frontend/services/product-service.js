import http from "@/utils/http-common";

class ProductService {
  getAll() {
    return http.get("/products").then((response) => response.data.result);
  }

  getById(id) {
    return http.get(`/products/${id}`).then((response) => response.data.result);
  }

  create(data) {
    return http.post("/products", data).then((response) => response.data);
  }

  update(data) {
    return http.put("/products", data).then((response) => response.data);
  }

  delete(id) {
    return http.delete(`/products/${id}`).then((response) => response.data);
  }
}

export default new ProductService();
