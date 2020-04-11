<template>
  <v-content>
    <v-container class="fill-height" fluid>
      <v-row align="center" justify="center">
        <v-col cols="12" sm="8" md="4">
          <v-form>
            <v-text-field label="Login" v-model="username" name="login" type="text" />

            <v-text-field
              id="password"
              v-model="password"
              label="Password"
              name="password"
              type="password"
            />
          </v-form>
          <v-row>
            <v-btn color="primary" @click="Login">Login</v-btn>
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
import { Component, Vue } from "vue-property-decorator";
import LoginService from "../services/LoginService";
import { setToken, setAppConfig } from "@/lib/appConfig";

const loginSerivce = new LoginService();

@Component({
  components: {}
})
export default class Login extends Vue {
  username = "";
  password = "";

  public async Login() {
    let response: any;
    try {
      response = await loginSerivce.Login(this.username, this.password);
      setToken(response.accessToken);
      setAppConfig(await loginSerivce.GetUserConfig());
      this.$router.push("/User");
    } catch (error) {
      response = error.response;
    }
  }
}
</script>