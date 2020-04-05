<template>
    <v-container class="fill-height" fluid justify="center" align="center">
        <v-row 
        justify="center">
            <h2>Sign up for Covid Community</h2>
        </v-row>
        <v-row justify="center">
            <v-col cols="6" md="4">
                <v-text-field
                    label="First Name"
                    name="First Name"
                    type="text"/>
            </v-col>
             <v-col cols="6" md="4">
                <v-text-field
                    label="Last Name"
                    name="Last Name"
                    type="text"/>
            </v-col>
        </v-row>
        <v-row justify="center">
            <v-col cols="6" md="6">
                <v-text-field
                    label="Address"
                    name="Address"
                    type="text"/>
            </v-col>
             <v-col cols="6" md="2">
                <v-text-field
                    label="Apt/Suite/Room"
                    name="Apt"
                    type="text"/>
            </v-col>
        </v-row>
              <v-row justify="center">
            <v-col cols="4" md="3">
                <v-text-field
                    label="City"
                    name="City"
                    type="text"/>
            </v-col>
             <v-col cols="4" md="3">
                <v-text-field
                    label="State"
                    name="State"
                    type="text"/>
            </v-col>
             <v-col cols="4" md="2">
                <v-text-field
                    label="Zip"
                    name="Zip"
                    type="text"/>
            </v-col>
        </v-row>
        <v-row justify="center">
            <v-col cols="12" md="8" >
                <v-text-field
                    label="Phone"
                    name="Phone"
                    type="tel"/>
            </v-col>
        </v-row>
        <v-row justify="center">
            <v-col cols="12" md="8" >
                <v-text-field
                    label="Email"
                    name="Email"
                    type="text"/>
            </v-col>
        </v-row>
          <v-row justify="center">
            <v-col cols="12" md="8" >
                <v-text-field
                    label="Password"
                    name="Password"
                    type="text"/>
            </v-col>
        </v-row>
        <v-row  
        align="center"
        justify="center">
          <v-btn>Submit</v-btn>
        </v-row>
    </v-container>
</template>

<script lang="ts">
import Vue from 'vue'

export default Vue.extend({
    name: 'SignUpForm'
})
</script>