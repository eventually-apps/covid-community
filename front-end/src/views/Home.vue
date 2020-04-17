<template>
  <div class="main">
    <Landing />
  </div>
</template>

<script>
// @ is an alias to /src
import Landing from "@/components/Landing.vue";
import { getToken } from "../lib/appConfig";

export default {
  components: {
    Landing
  },
  mounted() {
    if (getToken() !== "") {
      this.$router.replace("/User");
    }
  }
};
</script>
