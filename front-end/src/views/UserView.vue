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
            <v-list-item-title >Your Request Order</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item link>
          <v-list-item-action>
            <v-icon>mdi-archive</v-icon>
          </v-list-item-action>
          <v-list-item-content  @click="ShowComponent('donate')">
            <v-list-item-title>Donate/Request</v-list-item-title>
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
      <Community v-show="showCommunity" :location="location" v-if="dataLoaded"/>
      <Account v-show="showAccount" :user="user" v-if="dataLoaded"/>
      <RequestOrder v-show="showRequests" :order="order" v-if="dataLoaded"/>
      <Donate v-show="showDonate" :orderRequests="orderRequests" v-if="dataLoaded"/>
    </v-content>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import UserService from "../services/UserService";
import RequestService from "../services/RequestService";
import Community from "../components/Community.vue";
import Account from "../components/MyAccount.vue";
import RequestOrder from "../components/RequestOrder.vue";
import Donate from "../components/Donate.vue";
import { IRequestModel } from "../models/RequestModel";
import LocationService from "../services/LocationService";
import ItemService from "../services/ItemService";

const userService = new UserService();
const requestService = new RequestService();
const locationService = new LocationService();
const itemService = new ItemService();

import { clearToken } from "../lib/appConfig";


@Component({
  components: {
    Community,
    Account,
    RequestOrder,
    Donate
  }
})

export default class UserView extends Vue {
  public showLanding = true;
  public showRequests = false;
  public showDonate = false;
  public showCommunity = false;
  public showAccount = false;

  public user = { firstName: "Chad", lastName: "Not Smith", email: "", primaryAddress: "", secondaryAddress: "", phone: "", city: "", state: "", zip: 1111111 };
  public order = { id: 0, requestedUser: 0, locationId: 0, requests: [], isActive: false };
  public location = {id: 0, name: "", primaryAddress: "", secondaryAddress: "", state: "", city: "", zip: 123456};
  public requests: IRequestModel[] = [];
  public itemsByLocation: any[] = [];
  public orderRequests = { requestOrder: this.order, itemsByLocation: []};
  public dataLoaded = false;


  async created(){
    this.GetUserDetails(+this.$route.params.userId).then(x => {
      this.user.firstName = x.name;
      this.user.lastName = x.surname;
      this.user.primaryAddress = x.address;
      this.user.email = x.emailAddress;
      this.user.phone = x.phoneNumber;
      this.user.zip = x.zipCode;
      this.user.state = x.state;
      this.user.city = x.city;
    });

    this.GetRequestOrderByUser(+this.$route.params.userId).then(res => {
      res.data.result.requests.forEach(element => {
        this.requests.push(element);
      });

      this.order.id = res.data.result.id;
      this.order.requestedUser = res.data.result.orderRequestedByUserId;
      this.order.locationId =  res.data.result.orderForLocationId;
      this.order.requests = this.requests;    
      this.order.isActive = res.data.result.isActive;      
        
      this.GetLocation(this.order.locationId).then(res => {
        this.location.id = res.data.result.locationId;
        this.location.name = res.data.result.locationName;
        this.location.primaryAddress = res.data.result.primaryAddress;
        this.location.secondaryAddress = res.data.result.secondaryAddress;
        this.location.city = res.data.result.city;
        this.location.state = res.data.result.state;
        this.location.zip = res.data.result.zip;
      });

      this.GetItemsByLocation(this.order.locationId).then(res => {
        res.data.result.forEach(element => {
          this.itemsByLocation.push(element);
        });
      });
      
      this.orderRequests.itemsByLocation = this.itemsByLocation;
      this.orderRequests.requestOrder = this.order;
      this.dataLoaded = true;
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

  private GetItemsByLocation(locationId: number): any {
    return itemService.GetItemsByLocation(locationId);
  }
}
</script>
