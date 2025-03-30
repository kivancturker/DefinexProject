<template>
  <div v-if="isVisible" class="auth-debugger">
    <div class="auth-debugger-header">
      <h3>Auth Debugger</h3>
      <button @click="toggleCollapse" class="toggle-btn">
        {{ isCollapsed ? "+" : "-" }}
      </button>
    </div>

    <div v-if="!isCollapsed" class="auth-debugger-content">
      <div class="status-row">
        <div class="status-label">Authenticated:</div>
        <div
          :class="[
            'status-value',
            isAuthenticated ? 'status-success' : 'status-error',
          ]"
        >
          {{ isAuthenticated ? "Yes" : "No" }}
        </div>
      </div>

      <div v-if="isAuthenticated" class="status-row">
        <div class="status-label">Roles:</div>
        <div class="status-value">
          <ul v-if="authInfo.roles.length">
            <li v-for="(role, index) in authInfo.roles" :key="index">
              {{ role }}
            </li>
          </ul>
          <span v-else>No roles found</span>
        </div>
      </div>

      <div v-if="isAuthenticated" class="status-row">
        <div class="status-label">Is Admin:</div>
        <div
          :class="[
            'status-value',
            authInfo.isAdmin ? 'status-success' : 'status-normal',
          ]"
        >
          {{ authInfo.isAdmin ? "Yes" : "No" }}
        </div>
      </div>

      <div v-if="isAuthenticated" class="status-row">
        <div class="status-label">Is Customer:</div>
        <div
          :class="[
            'status-value',
            authInfo.isCustomer ? 'status-success' : 'status-normal',
          ]"
        >
          {{ authInfo.isCustomer ? "Yes" : "No" }}
        </div>
      </div>

      <div v-if="isAuthenticated" class="status-row">
        <div class="status-label">Token Expires:</div>
        <div class="status-value">{{ authInfo.expiresAt }}</div>
      </div>

      <div v-if="isAuthenticated">
        <details>
          <summary>Token Claims (Click to expand)</summary>
          <pre class="token-claims">{{
            JSON.stringify(authInfo.claims, null, 2)
          }}</pre>
        </details>
      </div>

      <div class="actions">
        <button @click="refreshDebugInfo" class="debug-btn">Refresh</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "AuthDebugger",
  props: {
    // Set to false to hide in production
    visible: {
      type: Boolean,
      default: process.env.NODE_ENV !== "production",
    },
  },
  data() {
    return {
      isCollapsed: false,
      authInfo: {
        isValid: false,
        roles: [],
        isAdmin: false,
        isCustomer: false,
        claims: {},
        expiresAt: "N/A",
      },
    };
  },
  computed: {
    isVisible() {
      return this.visible;
    },
    isAuthenticated() {
      return this.$auth && this.$auth.isAuthenticated();
    },
  },
  mounted() {
    this.refreshDebugInfo();
  },
  methods: {
    toggleCollapse() {
      this.isCollapsed = !this.isCollapsed;
    },
    refreshDebugInfo() {
      if (this.isAuthenticated) {
        try {
          this.authInfo = this.$auth.debug();
        } catch (err) {
          console.error("Error getting auth debug info:", err);
          this.authInfo = {
            isValid: false,
            roles: [],
            isAdmin: false,
            isCustomer: false,
            claims: {},
            expiresAt: "N/A",
            error: err.message,
          };
        }
      }
    },
  },
};
</script>

<style scoped>
.auth-debugger {
  position: fixed;
  bottom: 20px;
  right: 20px;
  width: 350px;
  background: rgba(0, 0, 0, 0.8);
  color: #fff;
  border-radius: 5px;
  font-family: monospace;
  z-index: 9999;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.3);
}

.auth-debugger-header {
  padding: 10px 15px;
  background: #333;
  border-radius: 5px 5px 0 0;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.auth-debugger-header h3 {
  margin: 0;
  font-size: 14px;
}

.toggle-btn {
  background: transparent;
  border: 1px solid #666;
  color: #fff;
  width: 24px;
  height: 24px;
  border-radius: 3px;
  display: flex;
  align-items: center;
  justify-content: center;
  cursor: pointer;
  font-size: 16px;
  line-height: 1;
}

.auth-debugger-content {
  padding: 15px;
  font-size: 12px;
}

.status-row {
  display: flex;
  margin-bottom: 10px;
}

.status-label {
  width: 120px;
  font-weight: bold;
}

.status-success {
  color: #4caf50;
}

.status-error {
  color: #f44336;
}

.status-normal {
  color: #ccc;
}

.token-claims {
  background: #222;
  padding: 10px;
  border-radius: 3px;
  overflow: auto;
  max-height: 200px;
  font-size: 11px;
}

.actions {
  margin-top: 15px;
  display: flex;
  justify-content: flex-end;
}

.debug-btn {
  background: #444;
  color: #fff;
  border: none;
  padding: 6px 12px;
  border-radius: 3px;
  font-size: 12px;
  cursor: pointer;
}

.debug-btn:hover {
  background: #555;
}

details {
  margin-top: 10px;
}

summary {
  cursor: pointer;
  margin-bottom: 5px;
}

ul {
  list-style-type: none;
  padding: 0;
  margin: 0;
}
</style>
