<template>
    <v-container class="fill-height" fluid>
        <v-row align="center" justify="center">
          <v-col align="center">
                <h1>Donate / Requests</h1>
                <h3>Please select which items you'd like to donate or request.</h3>
          </v-col>
        </v-row>
        <v-flex d-flex>
            <v-layout wrap>
                <v-flex md4 v-for="item in this.orderRequests.itemsByLocation" :key="item.itemId" style="padding-bottom: 30px;">
                    <v-card class="card-container" max-width="400">
                        <v-img height="50px"></v-img>
                        <v-card-subtitle>{{ item.itemName }}</v-card-subtitle>
                        <v-card-text>
                             <v-text-field label="Amount" name="Amount" type="number" />
                        </v-card-text>
                         <v-card-actions>
                            <v-btn color="green" text :disabled="item.itemByLocationQuantity === 0">Request</v-btn>
                            <v-btn color="blue" text>Donate</v-btn>
                        </v-card-actions>
                    </v-card>
                </v-flex>
            </v-layout>
        </v-flex>
    </v-container>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import RequestService from "../services/RequestService";

const requestSerivce = new RequestService();

@Component({
    components:{

    }
})

export default class Donate extends Vue {
    @Prop() public orderRequests!: any;

    // public CreateRequest(orderId: number, request: any){

    // }
}
</script>