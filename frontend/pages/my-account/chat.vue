<template>
  <div>
    <!-- Banner Area -->
    <section id="common_banner_one">
      <div class="container">
        <div class="row">
          <div class="col-lg-12">
            <div class="common_banner_text">
              <h2>{{ this.title }}</h2>
              <b-breadcrumb
                :items="breadcrumbItems"
                class="bg-transparent"
              ></b-breadcrumb>
            </div>
          </div>
        </div>
      </div>
    </section>

    <!-- Chat Area -->
    <section id="chat_area" class="ptb-100">
      <div class="container">
        <div class="row">
          <div class="col-sm-12 col-md-3 col-lg-3">
            <!-- Nav tabs -->
            <MyAccountNavbar />
          </div>
          <div class="col-sm-12 col-md-9 col-lg-9">
            <div class="dashboard_content">
              <div class="myaccount-content">
                <h4 class="title">Chat</h4>

                <div class="chat-container">
                  <div class="chat-messages" ref="chatMessages">
                    <div
                      v-for="(message, index) in messages"
                      :key="index"
                      class="message"
                    >
                      <p>{{ message }}</p>
                    </div>
                  </div>
                  <div class="chat-input">
                    <b-form @submit.prevent="sendMessage">
                      <b-input-group>
                        <b-form-input
                          v-model="newMessage"
                          placeholder="Type your message..."
                          :disabled="!isConnected"
                        ></b-form-input>
                        <b-input-group-append>
                          <b-button
                            type="submit"
                            variant="primary"
                            :disabled="!isConnected || !newMessage"
                          >
                            Send
                          </b-button>
                        </b-input-group-append>
                      </b-input-group>
                    </b-form>
                  </div>
                </div>

                <div class="connection-status mt-3">
                  <span :class="isConnected ? 'text-success' : 'text-danger'">
                    <i
                      :class="isConnected ? 'fas fa-circle' : 'far fa-circle'"
                    ></i>
                    {{ isConnected ? "Connected" : "Disconnected" }}
                  </span>
                  <b-button
                    v-if="!isConnected"
                    size="sm"
                    @click="startConnection"
                    class="ml-2"
                  >
                    Connect
                  </b-button>
                </div>

                <!-- User Role Display -->
                <div class="user-info mt-3" v-if="isConnected">
                  <small>
                    Connected as:
                    <span class="font-weight-bold">{{ userDisplayName }}</span>
                    <span
                      class="badge"
                      :class="$auth.isAdmin() ? 'badge-danger' : 'badge-info'"
                    >
                      {{ $auth.isAdmin() ? "Admin" : "Customer" }}
                    </span>
                  </small>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>

<script>
import MyAccountNavbar from "@/components/MyAccountNavbar.vue";
import * as signalR from "@microsoft/signalr";

export default {
  name: "Chat",
  components: {
    MyAccountNavbar,
  },
  data() {
    return {
      title: "My Chat",
      connection: null,
      isConnected: false,
      messages: [],
      newMessage: "",

      // Breadcrumb Items Data
      breadcrumbItems: [
        {
          text: "Home",
          to: "/",
        },
        {
          text: "My Account",
          to: "/my-account",
        },
        {
          text: "Chat",
        },
      ],
    };
  },
  mounted() {
    // For scroll page top for every Route
    window.scrollTo(0, 0);
    this.createConnection();
  },
  beforeDestroy() {
    this.stopConnection();
  },
  methods: {
    createConnection() {
      this.connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5224/chat")
        .configureLogging(signalR.LogLevel.Information)
        .build();

      this.connection.on("ReceiveMessage", (message) => {
        this.messages.push(message);
        this.$nextTick(() => {
          this.scrollToBottom();
        });
      });

      this.connection.onclose(() => {
        this.isConnected = false;
      });
    },
    async startConnection() {
      if (this.connection) {
        try {
          await this.connection.start();
          this.isConnected = true;
          console.log("SignalR Connected");
        } catch (err) {
          console.error("SignalR Connection Error: ", err);
          setTimeout(() => this.startConnection(), 5000);
        }
      }
    },
    async stopConnection() {
      if (this.connection) {
        try {
          await this.connection.stop();
          this.isConnected = false;
        } catch (err) {
          console.error("SignalR Disconnect Error: ", err);
        }
      }
    },
    async sendMessage() {
      if (this.connection && this.isConnected && this.newMessage) {
        try {
          // Simplify role check to either Admin or Customer
          const userRole = this.$auth.isAdmin() ? "Admin" : "Customer";

          // Call the updated SendMessage method with role parameter
          await this.connection.invoke(
            "SendMessage",
            this.newMessage,
            userRole
          );
          this.newMessage = "";
        } catch (err) {
          console.error("Error sending message: ", err);
        }
      }
    },
    scrollToBottom() {
      const chatContainer = this.$refs.chatMessages;
      if (chatContainer) {
        chatContainer.scrollTop = chatContainer.scrollHeight;
      }
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
          content: "Chat with us - AndShop Ecommerce",
        },
      ],
    };
  },
};
</script>

<style scoped>
.chat-container {
  display: flex;
  flex-direction: column;
  border: 1px solid #ddd;
  border-radius: 4px;
  overflow: hidden;
}

.chat-messages {
  height: 400px;
  overflow-y: auto;
  padding: 15px;
  background-color: #f9f9f9;
}

.message {
  margin-bottom: 10px;
  background-color: #fff;
  padding: 10px 15px;
  border-radius: 4px;
  box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
}

.chat-input {
  padding: 15px;
  background-color: #fff;
  border-top: 1px solid #ddd;
}

.connection-status {
  font-size: 14px;
}

.connection-status i {
  margin-right: 5px;
}
</style>
