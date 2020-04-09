<template>
    <v-form id="signup-form">
        <v-container class="fill-height" fluid>
                <v-row 
                justify="center">
                    <h2>Sign up for Covid Community</h2>
                </v-row>
                <v-row justify="center" align="center">
                    <v-col cols="6" md="4">
                        <v-text-field
                            v-model="user.FirstName"
                            label="First Name"
                            name="First Name"
                            type="text"/>
                    </v-col>
                    <v-col cols="6" md="4">
                        <v-text-field
                            v-model="user.LastName"
                            label="Last Name"
                            name="Last Name"
                            type="text"/>
                    </v-col>
                </v-row>
                <v-row justify="center">
                    <v-col cols="6" md="6">
                        <v-text-field
                            v-model="user.Address"
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
                            v-model="user.City"
                            label="City"
                            name="City"
                            type="text"/>
                    </v-col>
                    <v-col cols="4" md="3">
                        <v-text-field
                            v-model="user.State"
                            label="State"
                            name="State"
                            type="text"/>
                    </v-col>
                    <v-col cols="4" md="2">
                        <v-text-field
                            v-model="user.ZipCode"
                            label="Zip"
                            name="Zip"
                            type="text"/>
                    </v-col>
                </v-row>
                <v-row justify="center">
                    <v-col cols="12" md="8" >
                        <v-text-field
                            v-model="user.PhoneNumber"
                            label="Phone"
                            name="Phone"
                            type="tel"/>
                    </v-col>
                </v-row>
                <v-row justify="center">
                    <v-col cols="12" md="8" >
                        <v-text-field
                            v-model="user.EmailAddress"
                            label="Email"
                            name="Email"
                            type="text"/>
                    </v-col>
                </v-row>
                <v-row justify="center">
                    <v-col cols="12" md="8" >
                        <v-text-field
                            v-model="user.Password"
                            label="Password"
                            name="Password"
                            type="password"/>
                    </v-col>
                </v-row>
                 <v-row justify="center">
                    <v-col cols="12" md="8" >
                        <v-text-field
                            v-model="user.ConfirmPassword"
                            label="Confirm Password"
                            name="Password"
                            type="password"/>
                    </v-col>
                </v-row>
        </v-container>
        <v-row  align="center" justify="center">
            <v-btn  v-on:click="CreateNewUser(user)" form="signup-form">Create Account</v-btn>
        </v-row>
    </v-form>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator'
import LoginService from '../services/LoginService'
import UserModel from '../models/UserModel'

const loginService = new LoginService();

@Component({
    components: {

    }
})

export default class SignUpForm extends Vue {
    
    data() {
        return {
            user: {
                EmailAddress: "",
                FirstName: "",
                LastName: "",
                Address: "",
                City: "",
                State: "",
                ZipCode: "",
                Password: "",
                PasswordConfirm: "",
                PhoneNumber: ""                           
            }
        }
    }

    public CreateNewUser(user: any): void { 
        console.log("User Data", user);
        if(user.Password === user.ConfirmPassword){
            loginService.CreateNewUser(user);
        }               
    }

}
</script>