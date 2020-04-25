<template>
    <v-container class="fill-height" fluid>
        <v-row align="center" justify="center">
          <v-col align="center">
                <h1>Your Requests</h1>
          </v-col>
        </v-row>
        <v-row align="center" justify="center">
            <v-col align="center" cols="12" sm="8" md="4">
                <v-card>
                    <v-card-title>Current Order Status</v-card-title>
                    <v-card-text style="font-size:30px;">Active</v-card-text>
                </v-card>
           </v-col>
           <v-col align="center" cols="12" sm="8" md="4">
                <v-card>
                    <v-card-title>Active Requests</v-card-title>
                    <v-card-text style="font-size:30px;">0</v-card-text>
                </v-card>
           </v-col>
        </v-row>
        <v-row align="center" justify="center">
          <v-col align="center" cols="12" sm="8" md="4">
                <v-card>
                    <v-card-title>Cancelled Requests</v-card-title>
                    <v-card-text style="font-size:30px;">0</v-card-text>
                </v-card>
          </v-col>
             <v-col align="center" cols="12" sm="8" md="4">
                <v-card>
                    <v-card-title>Fulfilled Requests</v-card-title>
                    <v-card-text style="font-size:30px;">0</v-card-text>
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

export default class Request extends Vue {

}
</script>