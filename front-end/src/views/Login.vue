<template>
  <v-content>
    <v-container class="fill-height" fluid>
      <v-row align="center" justify="center">
        <v-col cols="12" sm="8" md="4">
          <v-form @keypress.native.enter="Login">
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
            <v-btn type="submit" color="primary" @click="Login">Login</v-btn>
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
import UserService from "../services/UserService";
import { setToken, setAppConfig } from "@/lib/appConfig";

const userSerivce = new UserService();

@Component({
  components: {}
})
export default class Login extends Vue {
  username = "";
  password = "";

  public async Login() {
    let response: any;

    try {
      response = await userSerivce.Login(this.username, this.password);
      const userId = response.userId;
      setAppConfig(await userSerivce.GetUserConfig());
      //this.$router.push("/User");
      this.$router.push({ name: "User", params: { userId }});
    } catch (error) {
      response = error.response;
      console.log("ERROR", response);
    }
  }
}
</script>