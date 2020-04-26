<template>
    <v-container class="fill-height" fluid>
        <v-row align="center" justify="center">
          <v-col align="center">
                <h1>Your Request Order</h1>
          </v-col>
        </v-row>
        <v-row align="center" justify="center">
            <v-col align="center" cols="12" sm="8" md="4">
                <v-card>
                    <v-card-title>Current Order Status</v-card-title>
                    <v-card-text style="font-size:30px;" v-if="order.isActive">Active</v-card-text>
                    <v-card-text style="font-size:30px;" v-if="!order.isActive">Inactive</v-card-text>
                </v-card>
           </v-col>
           <v-col align="center" cols="12" sm="8" md="4">
                <v-card>
                    <v-card-title>Active Requests</v-card-title>
                    <v-card-text style="font-size:30px;">{{this.activeRequests.length}}</v-card-text>
                </v-card>
           </v-col>
        </v-row>
        <v-row align="center" justify="center">
          <v-col align="center" cols="12" sm="8" md="4">
                <v-card>
                    <v-card-title>Cancelled Requests</v-card-title>
                    <v-card-text style="font-size:30px;">{{this.cancelledRequests.length}}</v-card-text>
                </v-card>
          </v-col>
             <v-col align="center" cols="12" sm="8" md="4">
                <v-card>
                    <v-card-title>Fulfilled Requests</v-card-title>
                    <v-card-text style="font-size:30px;">{{this.fulfiledRequests.length}}</v-card-text>
                </v-card>
          </v-col>
        </v-row>
    </v-container>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";

@Component({
    components:{
        
    }
})

export default class RequestOrder extends Vue {
@Prop() public order!: any;

public activeRequests: any[] = [];
public cancelledRequests: any[] = [];
public fulfiledRequests: any[] = [];

    created(){
        this.order.requests.forEach(x => {
            if(x.isActive){
                this.activeRequests.push(x);
            }

            if(!x.isActive && x.fulfilledDate){
                this.fulfiledRequests.push(x);
            }

            if(!x.isActive && !x.fulfilledDate){
                this.cancelledRequests.push(x);
            }
        });
    }

}
</script>