import Vue from 'vue';
import App from './App.vue';
import axios from 'axios';
import VueRouter from 'vue-router';
import routes from './routes';

import BootstrapVue from "bootstrap-vue"
import "bootstrap/dist/css/bootstrap.min.css"
import "bootstrap-vue/dist/bootstrap-vue.css"

import VeeValidate from "vee-validate";

Vue.use( VeeValidate );
Vue.use( BootstrapVue )

Vue.use( VueRouter )

Vue.prototype.$http = axios

Vue.config.productionTip = true;

const router = new VueRouter( { routes } );

new Vue({
    render: h => h( App ),
    router
}).$mount('#app');
