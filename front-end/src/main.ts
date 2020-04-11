import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify';
import LoginService from "@/services/LoginService"
import { setAppConfig } from "@/lib/appConfig";

const loginService = new LoginService();

Vue.config.productionTip = false

loginService.GetUserConfig().then(configData => {
  setAppConfig(configData);
  new Vue({
    router,
    store,
    vuetify,
    render: h => h(App)
  }).$mount('#app')
});


