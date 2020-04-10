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
            </v-row>
            <v-row style="margin-top: 10px;">
              <v-btn class="signUpBtn" color="primary" :to="{path: '/SignUp'}">Sign Up</v-btn>     
            </v-row>
          </v-col>
        </v-row>
      </v-container>
    </v-content>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator'
import LoginService from '../services/LoginService'

const loginSerivce = new LoginService();

@Component({
  components: {

  }
})

export default class Login extends Vue {
  public Login(userName: string, password: string) {
    let response: any;
    try {
      response = loginSerivce.Login(userName, password);
    } catch(error) {
      response = error.response;
    }
  }
}
</script>