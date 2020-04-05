<template>
   <v-content>
      <v-container
        class="fill-height"
        fluid
      >
        <v-row
          align="center"
          justify="center"
        >
          <v-col
            cols="12"
            sm="8"
            md="4"
          >

          <v-form>
            <v-text-field
              label="Login"
              name="login"
              type="text"
            />

            <v-text-field
              id="password"
              label="Password"
              name="password"
              type="password"
            />
          </v-form>
            <v-row>
              <v-btn color="primary">Login</v-btn>
              <v-btn class="signUpBtn" color="primary" :to="{path: '/SignUp'}">Sign Up</v-btn>     
            </v-row>
          </v-col>
        </v-row>
      </v-container>
    </v-content>
</template>

<script lang="ts">
  import Vue from 'vue'

  export default Vue.extend({
    name: 'Login',

    data: () => ({
      
    })
  })
</script>

<style lang="scss">
.signUpBtn {
  margin-left: 10px !important;
}
</style>
