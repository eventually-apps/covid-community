<template>
  <v-app>
    <v-app-bar
      app
      color="primary"
      dark
    >
      Covid Community
      <v-spacer></v-spacer>
    </v-app-bar>

    <v-content>
      <Login/>
    </v-content>
  </v-app>
</template>

<script lang="ts">
import Vue from 'vue';
import Vuetify from 'vuetify/lib';
import Login from './components/Login.vue';

Vue.use(Vuetify, {
  theme: {
    dark: "true"
  }
})

export default Vue.extend({
  name: 'App',

  components: {
    Login,
  },

  data: () => ({
    //
  }),
});
</script>
