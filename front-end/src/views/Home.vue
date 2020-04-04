<template>
  <div class="main">
    <Login msg="Welcome to Your Vue.js App"/>
  </div>
</template>

<script>
// @ is an alias to /src
import Login from '@/components/Login.vue'

export default {
  name: 'Login',
  components: {
    Login
  }
}
</script>

<style lang="less" scoped>

</style>
