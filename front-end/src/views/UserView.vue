<template>
  <div>
    <v-navigation-drawer app>
      <v-list dense>
        <v-list-item link>
          <v-list-item-action>
            <v-icon>mdi-account-box</v-icon>
          </v-list-item-action>
          <v-list-item-content @click="ShowComponent('account')">
            <v-list-item-title >My Account</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item link>
          <v-list-item-action>
            <v-icon>mdi-file</v-icon>
          </v-list-item-action>
          <v-list-item-content @click="ShowComponent('request')">
            <v-list-item-title >Requests</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item link>
          <v-list-item-action>
            <v-icon>mdi-archive</v-icon>
          </v-list-item-action>
          <v-list-item-content  @click="ShowComponent('donate')">
            <v-list-item-title>Donate</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item link>
          <v-list-item-action>
            <v-icon>mdi-city</v-icon>
          </v-list-item-action>
          <v-list-item-content @click="ShowComponent('community')">
            <v-list-item-title>My Community</v-list-item-title>
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
          <v-col align="center"><h1>Welcome Back, {{user.firstName}} {{user.lastName}}</h1></v-col>
        </v-row>
      </v-container>
      <Community v-show="showCommunity"/>
      <Account v-show="showAccount"/>
      <Request v-show="showRequests" v-model="order"/>
      <Donate v-show="showDonate"/>
    </v-content>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import UserService from "../services/UserService";
import RequestService from "../services/RequestService";
import Community from "../components/Community.vue";
import Account from "../components/MyAccount.vue";
import Request from "../components/Request.vue";
import Donate from "../components/Donate.vue";
import UserModel from "../models/UserModel";
import { RequestOrderModel } from "../models/RequestOrderModel";
import { IRequestModel } from "../models/RequestModel";
import LocationService from "../services/LocationService";

const userService = new UserService();
const requestService = new RequestService();
const locationService = new LocationService();

import { clearToken } from "../lib/appConfig";


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

  public user = { firstName: "Chad", lastName: "Not Smith"};
  public order = { id: 0, requestedUser: 0, locationId: 0, requests: [] };
  public requests: IRequestModel[] = [];
  public location: any;

  created(){
    this.GetUserDetails(+this.$route.params.userId).then(x => {
      this.user.firstName = x.name;
      this.user.lastName = x.surname;
    });

    this.GetRequestOrderByUser(+this.$route.params.userId).then(res => {
      res.data.result.requests.forEach(element => {
        this.requests.push(element);
      });

      this.order.id = res.data.result.id;
      this.order.requestedUser = res.data.result.orderRequestedByUserId;
      this.order.locationId =  res.data.result.orderForLocationId;
      this.order.requests = this.requests;    
    });

    console.log("Request Order", this.order);

    this.GetLocation(4).then(res => {
      this.location = res.data.result;
      console.log("Location", this.location );
    });

  }

  public ShowComponent(componentType: string) {
    this.showLanding = false;
    this.showCommunity = false;
    this.showDonate = false;
    this.showCommunity = false;
    this.showAccount = false;
    this.showRequests = false;

    switch (componentType.toLowerCase()) {
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
    this.$router.push("/Login");
    clearToken();
  }

  private GetUserDetails(id: number): any {
    return userService.GetUser(id);
  }

  private GetRequestOrderByUser(userId: any): any {
    return requestService.GetRequestOrderByUser(userId);
  }

  private GetLocation(locationId: any): any {
    return locationService.GetLocation(locationId);
  }
}
</script>
