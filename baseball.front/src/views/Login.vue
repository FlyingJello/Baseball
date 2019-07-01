<template>
  <div class="login-background">
    <div class="container">
      <div class="row h-75">
        <div class="col-12 my-sm-auto px-0">
          <div class="login-wrap bg-white mx-auto px-5 py-4">
            <h1 class="font-weight-light text-center pt-2 mb-0">Connexion</h1>
            <hr />
            <b-form @submit="userAuthentication">
              <b-form-invalid-feedback class="mb-2" :state="authenticationState">Nom d'utilisateur ou mot de passe invalide.</b-form-invalid-feedback>
              <b-form-group id="user-group" label="Nom d'utilisateur" label-for="username">
                <b-form-input
                  id="username"
                  type="text"
                  v-model="username"
                  :state="usernameState"
                  :disabled="loggingIn"
                />
                <b-form-invalid-feedback :state="usernameState">Le nom d'utilisateur est requis.</b-form-invalid-feedback>
              </b-form-group>
              <b-form-group id="password-group" class="mb-0" label="Mot de passe" label-for="password">
                <b-form-input
                  id="password"
                  type="password"
                  v-model="password"
                  :state="passwordState"
                  :disabled="loggingIn"
                />
                <b-form-invalid-feedback :state="passwordState">Le mot de passe est requis.</b-form-invalid-feedback>
              </b-form-group>
              <ForgotPassword />
              <div class="text-right mt-3">
                <b-button type="submit" squared variant="primary" :disabled="loggingIn">
                  <b-spinner v-show="loggingIn" small type="grow" />
                  {{connectionButtonName}}
                </b-button>
              </div>
            </b-form>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import ForgotPassword from "@/components/ForgotPassword";
import router from "@/router";

export default {
  name: "Login",
  components: {
    ForgotPassword
  },
  data() {
    return {
      username: "",
      password: "",
      submitted: null
    };
  },
  computed: {
    loggingIn() {
      return this.$store.state.authentication.status.loggingIn;
    },
    usernameState() {
      return this.submitted && this.username !== "";
    },
    passwordState() {
      return this.submitted && this.password !== "";
    },
    connectionButtonName() {
      return this.$store.state.authentication.status.loggingIn
        ? "Connexion en cours..."
        : "Se connecter";
    },
    authenticationState() {
      return this.$store.state.authentication.status.success;
    }
  },

  methods: {
    userAuthentication(event) {
      event.preventDefault();
      this.submitted = true;

      const { username, password } = this;

      if (username && password) {
        this.submitted = null;
        this.$store.dispatch("authentication/login", { username, password });
      }
    }
  }
};
</script>


