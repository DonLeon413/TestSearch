import Home from './components/Home.vue';
import DataVersionA from './components/DataVersionA.vue';
import DataVersionB from './components/DataVersionB.vue';
import SearchA from './components/SearchA.vue';
import SearchB from './components/SearchB.vue';

const routes = [
    { path: '/', name: "Home", component: Home },
    { path: '/dataa', name: "DataVersionA", component: DataVersionA },
    { path: '/datab', name: "DataVersionB", component: DataVersionB },
    { path: '/searcha', name: "SearchA", component: SearchA },
    { path: '/searchb', name: "SearchB", component: SearchB }
];

export default routes;