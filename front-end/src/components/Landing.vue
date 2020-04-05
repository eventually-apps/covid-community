<template>
<v-content>
    <v-container class="fill-height" fluid>
        <v-row  align="center" justify="center">
            <v-col cols="12" sm="8" md="4">
                <h1 align="center">Welcome to Covid Community</h1>
            </v-col>
        </v-row>
        <v-row  align="center" justify="center">
            <v-col cols="12" sm="8" md="4">
                <p align="center">Blah blah boiler plate put landing text here</p>
            </v-col>
        </v-row>
        <v-row align="center" justify="center">
            <v-col cols="6" md="2">
                <v-btn class="signUpBtn" color="primary" :to="{path: '/SignUp'}" align="center">Get Started</v-btn>     
            </v-col>
        </v-row>
    </v-container>
</v-content>
</template>