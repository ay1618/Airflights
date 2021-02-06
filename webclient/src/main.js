import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import { BootstrapVue, BootstrapVueIcons } from "bootstrap-vue";

Vue.config.productionTip = false;

import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
import Http from "./services/http.service";

Vue.use(BootstrapVue);
Vue.use(BootstrapVueIcons);

Vue.prototype.$http = new Http();
Vue.prototype.$httpauth = new Http({auth: true});

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount("#app");
