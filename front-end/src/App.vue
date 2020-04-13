<template>
  <v-app>
    <v-app-bar app color="primary" dark>
      <v-btn to="/" text>
        Covid Community
      </v-btn>
      <v-spacer></v-spacer>
      <v-btn to ="/About" text>About</v-btn>
      <v-btn to="/Login" text>Login</v-btn>
    </v-app-bar>
    <v-content>
      <router-view/>
    </v-content>
  </v-app>
</template>

<script lang="ts">
import Vue from 'vue';

export default Vue.extend({
  name: 'App',

  data: () => ({
    //
  }),
});
</script>
