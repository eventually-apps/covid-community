import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify';
import UserService from "@/services/UserService"
import { setAppConfig } from "@/lib/appConfig";

const userService = new UserService();

Vue.config.productionTip = false

userService.GetUserConfig().then(configData => {
  setAppConfig(configData);
  new Vue({
    router,
    store,
    vuetify,
    render: h => h(App)
  }).$mount('#app')
});


