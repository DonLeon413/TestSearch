<template>
    <div class="SearchA control">
        <div style="margin:20px">
            <h1>Search Version A</h1>
            <form @submit.prevent="OnSubmit">
                <b-form-group label="Name (type String)"
                              label-for="name">
                    <b-form-input id="name"
                                  name="name"
                                  v-model="name"
                                  type="text"
                                  placeholder="Enter name"
                                  v-validate="'alpha'">
                    </b-form-input>
                    <i v-show="errors.has('name')"></i>
                    <span v-show="errors.has('name')">{{ errors.first('name') }}</span>
                </b-form-group>

                <b-form-group label="Phone (type String)"
                              label-for="phone">
                    <b-form-input id="phone"
                                  name="phone"
                                  v-model="phone"
                                  type="text"
                                  placeholder="Enter phone">
                    </b-form-input>
                    <i v-show="errors.has('phone')"></i>
                    <span v-show="errors.has('phone')">{{ errors.first('phone') }}</span>
                </b-form-group>

                <b-form-group label="Email ( type String )"
                              label-for="email">
                    <b-form-input id="email"
                                  name="email"
                                  v-model="email"
                                  type="text"
                                  placeholder="Enter e-mail"
                                  v-validate="'email'">
                    </b-form-input>
                    <i v-show="errors.has('email')"></i>
                    <span v-show="errors.has('email')">{{ errors.first('email') }}</span>
                </b-form-group>

                <b-form-group id="confirmed">
                    <b-form-checkbox v-model="confirmed">Confirmed( type Boolean )</b-form-checkbox>
                </b-form-group>

                <b-button type="submit" variant="primary">Find</b-button>

            </form>

        </div>
    </div>
</template>

<script>

    import API_URLS from '../urls';

    export default {
        name: 'SearchA',
        data: ()=> ( {

            name: "lev",
            phone: "+34700262398",
            email: "donleon314@gmail.com",
            confirmed: false,
            results: []
        } ),
        methods: {

            OnSubmit: function() {

                this.$validator.validateAll().then( ( result ) => {
                    if ( result ) {

                        let upload_obj = {
                            name: this.name,
                            phone: this.phpne,
                            email: this.email,
                            confirmed: this.confirmed
                        };


                        this.$http.post( API_URLS.SEARCH_URL, upload_obj )
                            .then( function( response ) {                                

                                var message = "Unknown message";

                                if ( response.status === 200 ) {
                                    message = "Search OK! id = " + response.data.ids;
                                }
                                else {
                                    message = "Status: " + response.status + " Msg: " + response.statusText;
                                }

                                alert( message );

                            } )
                            .catch( function( error ) {

                                alert( error );

                            } );
                    }
                } );
            }
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    .versionA {
        background-color:cadetblue
    }

    .control {
        margin: 10px
    }
</style>

