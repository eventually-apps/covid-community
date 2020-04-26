<template>
    <v-container class="fill-height" fluid>
        <v-row align="center" justify="center">
          <v-col align="center">
                <h1>Your Community</h1>
          </v-col>
        </v-row>
        <v-row justify="center">
            <v-col cols="12" md="8">
                <v-text-field v-model="location.name" label="Community Name" name="Community Name" type="text" readonly/>
            </v-col>
        </v-row>
        <v-row justify="center">
            <v-col cols="6" md="6">
                <v-text-field v-model="location.primaryAddress" label="Address" name="Address" type="text" readonly/>
            </v-col>
            <v-col cols="6" md="2">
                <v-text-field label="Apt/Suite/Room" v-model="location.secondaryAddress" name="Apt" type="text" readonly/>
            </v-col>
        </v-row>
        <v-row justify="center">
            <v-col cols="4" md="3">
                <v-text-field v-model="location.city" label="City" name="City" type="text" readonly/>
            </v-col>
            <v-col cols="4" md="3">
                <v-text-field v-model="location.state" label="State" name="State" type="text" readonly/>
            </v-col>
            <v-col cols="4" md="2">
                <v-text-field v-model="location.zip" label="Zip" name="Zip" type="text" readonly/>
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

export default class Community extends Vue {
    @Prop() public location!: any;
}
</script>