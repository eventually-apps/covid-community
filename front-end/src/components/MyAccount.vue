<template>
    <v-container class="fill-height" fluid>
        <v-row align="center" justify="center">
          <v-col align="center">
                <h1>Your Account</h1>
          </v-col>
        </v-row>
      <v-row justify="center" align="center">
        <v-col cols="6" md="4">
          <v-text-field
            v-model="user.firstName"
            label="First Name"
            name="First Name"
            type="text"/>
        </v-col>
        <v-col cols="6" md="4">
          <v-text-field
            v-model="user.lastName"
            label="Last Name"
            name="Last Name"
            type="text"/>
        </v-col>
      </v-row>
      <v-row justify="center">
        <v-col cols="6" md="6">
          <v-text-field v-model="user.primaryAddress" label="Address" name="Address" type="text" />
        </v-col>
        <v-col cols="6" md="2">
          <v-text-field label="Apt/Suite/Room" name="Apt" type="text" />
        </v-col>
      </v-row>
      <v-row justify="center">
        <v-col cols="4" md="3">
          <v-text-field v-model="user.city" label="City" name="City" type="text"/>
        </v-col>
        <v-col cols="4" md="3">
          <v-text-field v-model="user.state" label="State" name="State" type="text" />
        </v-col>
        <v-col cols="4" md="2">
          <v-text-field v-model="user.zip" label="Zip" name="Zip" type="text" />
        </v-col>
      </v-row>
      <v-row justify="center">
        <v-col cols="12" md="8">
          <v-text-field v-model="user.phone" label="Phone" name="Phone" type="tel"/>
        </v-col>
      </v-row>
      <v-row justify="center">
        <v-col cols="12" md="8">
          <v-text-field v-model="user.email" label="Email" name="Email" type="text"/>
        </v-col>
      </v-row>
       <v-row justify="center">
        <v-col cols="12" md="8">
          <v-btn>Update Account</v-btn>
        </v-col>
      </v-row>
    </v-container>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";

@Component({
    components: {

    }
})

export default class MyAccount extends Vue{
    @Prop() public user: any;
}
</script>