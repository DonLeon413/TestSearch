<template>
    <div class="versionB control">
        <div style="margin:20px">
            <h1>Data Version B</h1>
        <form @submit.prevent="OnSubmit">
            <b-form-group label="Name (type String)"
                          label-for="name">
                <b-form-input id="name"
                              name="name"
                              v-model="name"
                              type="text"
                              placeholder="Enter name (required)"
                              v-validate="'required|alpha'">
                </b-form-input>
                <i v-show="errors.has('name')"></i>
                <span v-show="errors.has('name')">{{ errors.first('name') }}</span>
            </b-form-group>

            <b-form-group label="Age (type Numeric)"
                          label-for="age">
                <b-form-input id="age"
                              name="age"
                              v-model.number="age"
                              type="text"
                              placeholder="Enter age (required)"
                              v-validate="'between:1,11'">
                </b-form-input>
                <i v-show="errors.has('age')"></i>
                <span v-show="errors.has('age')">{{ errors.first('age') }}</span>
            </b-form-group>

            <b-form-group label="Email1 ( type String[] index 0 )"
                          label-for="email1">
                <b-form-input id="email1"
                              name="email1"
                              v-model="email1"
                              type="text"
                              placeholder="Enter e-mail 1 (required)"
                              v-validate="'required|email'">
                </b-form-input>
                <i v-show="errors.has('email1')"></i>
                <span v-show="errors.has('email1')">{{ errors.first('email1') }}</span>
            </b-form-group>

            <b-form-group label="Email2 ( type String[] index 1 )"
                          label-for="email2">
                <b-form-input id="email2"
                              name="email2"
                              v-model="email2"
                              type="text"
                              placeholder="Enter e-mail 2"
                              v-validate="'email'">
                </b-form-input>
                <i v-show="errors.has('email2')"></i>
                <span v-show="errors.has('email2')">{{ errors.first('email2') }}</span>
            </b-form-group>

            <b-form-group id="confirmed">                
                <b-form-checkbox v-model="confirmed">Confirmed( type Boolean )</b-form-checkbox>                
            </b-form-group>

            <b-button type="submit" variant="primary">Add to BBDD</b-button>

        </form>
    
        </div>
    </div>
</template>

<script>

    import API_URLS from '../urls';

    export default {
        name: 'DataVersionB',
        props: {            
            service: String
        },
        data: ()=> ( 
            {
                name: "lev",
                email1: "donleon314@gmail.com",
                email2: "sbit007@mail.ru",
                confirmed: false,
                age: 11,
                submitted: true
            }
        ),  
        methods: {

            OnSubmit: function() {
                                
                this.$validator.validateAll().then( ( result ) => {
                    if ( result ) {
                        
                        let upload_obj = {
                            name: this.name,
                            age: this.age,
                            emails: [this.email1, this.email2 ],
                            confirmed: this.confirmed
                        };

                        window.console.log( upload_obj );
                        window.console.log( API_URLS );

                        this.$http.post( API_URLS.ADD_URL, upload_obj )
                            .then( function( response ) {                               

                                var message = "Unknown message";

                                if ( response.status === 200 ) {
                                    message = "Add OK! id = " + response.data.id;
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
    .versionB {
        background-color: burlywood;
    }
    .control{
        margin: 10px
    }
</style>

