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
            <v-btn color="primary">Login</v-btn>
            <v-spacer />
            <v-btn color="primary">Sign Up</v-btn>          
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
