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
                        <v-text-field
                            v-model="user.address"
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
                            v-model="user.city"
                            label="City"
                            name="City"
                            type="text"/>
                    </v-col>
                    <v-col cols="4" md="3">
                        <v-text-field
                            v-model="user.state"
                            label="State"
                            name="State"
                            type="text"/>
                    </v-col>
                    <v-col cols="4" md="2">
                        <v-text-field
                            v-model="user.zipCode"
                            label="Zip"
                            name="Zip"
                            type="text"/>
                    </v-col>
                </v-row>
                <v-row justify="center">
                    <v-col cols="12" md="8" >
                        <v-text-field
                            v-model="user.phoneNumber"
                            label="Phone"
                            name="Phone"
                            type="tel"/>
                    </v-col>
                </v-row>
                <v-row justify="center">
                    <v-col cols="12" md="8" >
                        <v-text-field
                            v-model="user.emailAddress"
                            label="Email"
                            name="Email"
                            type="text"/>
                    </v-col>
                </v-row>
                <v-row justify="center">
                    <v-col cols="12" md="8" >
                        <v-text-field
                            v-model="user.password"
                            label="Password"
                            name="Password"
                            type="password"/>
                    </v-col>
                </v-row>
                 <v-row justify="center">
                    <v-col cols="12" md="8" >
                        <v-text-field
                            v-model="user.passwordConfirm"
                            label="Confirm Password"
                            name="Password"
                            type="password"/>
                    </v-col>
                </v-row>
        </v-container>
        <v-row align="center" justify="center">
            <v-btn  v-on:click="CreateNewUser(user)"  @click="lodaingDialog = true" form="signup-form">Create Account</v-btn>
            <v-dialog v-model="showDialog" max-width="290">
                <v-card>
                <v-card-title class="headline">{{dialogTitle}}</v-card-title>
                    <v-card-text>
                        <v-container>
                            {{dialogBody}}
                            <v-row v-if="userSuccess">                                
                                <v-col cols="12" sm="12" md="12">
                                    <v-text-field label="Verification Code" required></v-text-field>
                                </v-col>
                            </v-row>
                        </v-container>                    
                    </v-card-text>                
                    <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn color="green darken-1" text @click="showDialog = false">
                        Cancel
                    </v-btn>
                    <v-btn color="green darken-1" text @click="showDialog = false">
                        Verify
                    </v-btn>
                    </v-card-actions>
                </v-card>
            </v-dialog>
             <v-dialog v-model="lodaingDialog" hide-overlay persistent width="300">
                <v-card dark>
                    <v-card-text>
                        Loading...
                    <v-progress-linear indeterminate color="white" class="mb-0"></v-progress-linear>
                    </v-card-text>
                </v-card>
            </v-dialog>
        </v-row>
    </v-form>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator'
import LoginService from '../services/LoginService'

const loginService = new LoginService();

@Component({
    components: {
    }
})

export default class SignUpForm extends Vue {
    @Prop() public dialogTitle !: string;
    @Prop() public dialogBody !: string;
    public showDialog = false;
    public lodaingDialog = false;
    public userSuccess = false;

    data() {
        return {
            user: {
                emailAddress: "",
                firstName: "",
                lastName: "",
                address: "",
                city: "",
                state: "",
                zipCode: "",
                password: "",
                passwordConfirm: "",
                phoneNumber: ""                           
            },
            verifyCode: ""
        }
    }
    
   public async CreateNewUser(user: any) {   
        let response: any;
        try {
            this.lodaingDialog = false;
            response = await loginService.CreateNewUser(user);  
            this.dialogTitle = "Verify Account";
            this.dialogBody = "Please enter the verification code sent to your mobile phone:"
            this.userSuccess = true;
            this.showDialog = true;           
        } catch(error) {
            this.lodaingDialog = false;
            response = error.response;
            this.dialogTitle = "ERROR";
            this.dialogBody = response;            
            this.showDialog = true;
        }
    }

    public VerifyUser(verifyCode: any){
        let response: any;
        try {
            loginService.ValidateNewUser(verifyCode);
        } catch(error) {
            console.log(error.response);
        }
    }
}
</script>