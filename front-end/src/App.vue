<template>
  <v-app>
    <v-app-bar app color="primary" dark>
      <v-btn to="/" text>Covid Community</v-btn>
      <v-spacer></v-spacer>
      <v-btn to="/About" text>About</v-btn>
      <v-btn @click="onLoginClick" text>{{loginText}}</v-btn>
    </v-app-bar>
    <v-content>
      <router-view />
    </v-content>
  </v-app>
</template>

<script lang="ts">
import Vue from "vue";
import { getToken, clearToken } from "./lib/appConfig";

export default Vue.extend({
  name: "App",

  data: () => ({
    token: getToken()
  }),
  computed: {
    isLoggedIn() {
      return this.token !== "";
    },
    loginText() {
      if (this.isLoggedIn) {
        return "Logout";
      }

      return "Login";
    }
  },
  methods: {
    onLoginClick() {
      if (this.isLoggedIn) {
        clearToken();
      }
      this.$router.push("/Login");
    }
  }
});
</script>
