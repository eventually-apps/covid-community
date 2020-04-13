<template>
  <div>
    <v-navigation-drawer app>
      <v-list dense>
        <v-list-item link>
          <v-list-item-action>
            <v-icon>mdi-account-box</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title @click="ShowComponent('account')">My Account</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item link>
          <v-list-item-action>
            <v-icon>mdi-file</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title @click="ShowComponent('request')">Requests</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item link>
          <v-list-item-action>
            <v-icon>mdi-archive</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title @click="ShowComponent('donate')">Donate</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item link>
          <v-list-item-action>
            <v-icon>mdi-city</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title @click="ShowComponent('community')">My Community</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item link>
          <v-list-item-action>
            <v-icon>mdi-door-open</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title @click="Logout()">Logout</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-content>
      <v-container v-if="showLanding" class="fill-height" fluid>
        <v-row align="center" justify="center">
          <v-col align="center">
            Welcome Back, {{user.firstName}} {{user.lastName}}
          </v-col>
        </v-row>        
      </v-container>
      <Community v-if="showCommunity"/>
      <Account v-if="showAccount"/>
      <Request v-if="showRequests"/>
      <Donate v-if="showDonate"/>
    </v-content>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import Community from "../components/Community.vue";
import Account from "../components/MyAccount.vue";
import Request from "../components/Request.vue";
import Donate from "../components/Donate.vue";


@Component({
  components: {
    Community,
    Account,
    Request,
    Donate
  }
})

export default class UserView extends Vue {
  
  public showLanding = true;
  public showRequests = false;
  public showDonate = false;
  public showCommunity = false;
  public showAccount = false;


  data() {
    return {
      user: {
        firstName: "First Name Person",
        lastName: "Last Name Person",
      }
    }
  }

  public ShowComponent(componentType: string) {
    this.showLanding = false;
    this.showCommunity = false;
    this.showDonate = false;
    this.showCommunity = false;
    this.showAccount = false;
    this.showRequests = false;

    switch(componentType.toLowerCase()) {
      case "community":
        this.showCommunity = true;
        break;
      case "account":
        this.showAccount = true;
        break;
      case "request":
        this.showRequests = true;
        break;
      case "donate":
        this.showDonate = true;
        break;
    }
  }

  public Logout() {
    console.log("logout goes here");
  }
}
</script>