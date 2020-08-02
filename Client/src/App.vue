<template>
    <div id="app">

        <!--<router-link to="/">Home</router-link>
        <router-link to="/DataVersionA">Data A</router-link>
        <router-link to="/DataVersionB">Data B</router-link>
        <router-link to="/SearchA">SearchA</router-link>
        <router-link to="/SearchB">SearchB</router-link>-->

        <b-navbar toggleable="md"
                  type="dark"
                  variant="info">
            <b-navbar-brand :to="{ name: 'Home' }">Home</b-navbar-brand>
            <b-navbar-nav>
                <b-nav-item :to="{ name: 'DataVersionA' }">Data A</b-nav-item>
                <b-nav-item :to="{ name: 'DataVersionB' }">Data B</b-nav-item>
                <b-nav-item :to="{ name: 'SearchA' }">Search A</b-nav-item>
                <b-nav-item :to="{ name: 'SearchB' }">Search B</b-nav-item>
            </b-navbar-nav>
        </b-navbar>
        <router-view></router-view>
    </div>
</template>
<script>

    export default {
        name: 'app'        
    };
</script>

<style>
    
</style>

