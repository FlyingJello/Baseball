<template>
  <div>
    <b-link
      class="text-primary-color"
      @click="formForgotPass.modalForgotPassword = !formForgotPass.modalForgotPassword" 
    >Mot de passe oublié ?</b-link>
    <b-modal
      v-model="formForgotPass.modalForgotPassword"
      title="Mot de passe oublié ?"
      @ok="userForgotPassword"
      ok-title="Envoyer"
      cancel-title="Annuler"
    >
      <b-alert
        class="my-0"
        :variant="formForgotPass.alertVariant"
        :show="formForgotPass.showDismissibleAlert"
        @dismissed="formForgotPass.showDismissibleAlert=false"
      >{{formForgotPass.alertMessage}}</b-alert>

      <b-form @submit.stop.prevent="handleSubmitForgotPassword">
        <b-form-group
          :state="formForgotPass.emailState"
          label="Veuillez saisir votre adresse courriel :"
          label-for="email"
          :invalid-feedback="formForgotPass.emailErrorMessage"
        >
          <b-form-input
            id="email"
            v-model="formForgotPass.email"
            :state="formForgotPass.emailState"
          />
        </b-form-group>
      </b-form>
    </b-modal>
  </div>
</template>


<script>
import router from "@/router";

export default {
  name: "ForgotPassword",
  data() {
    return {
      formForgotPass: {
        modalForgotPassword: false,
        showDismissibleAlert: false,
        alertVariant: "",
        alertMessage: "",
        email: "",
        emailState: null,
        emailErrorMessage: ""
      }
    };
  },
  methods: {
    checkForgotPasswordFormValidity() {
      const valid =
        this.formForgotPass.email !== "" &&
        this.validEmail(this.formForgotPass.email);
      this.formForgotPass.emailState = !valid ? "invalid" : null;
      this.formForgotPass.emailErrorMessage =
        "L'adresse courriel est invalide.";
      return valid;
    },
    userForgotPassword(bvModalForgotPass) {
      bvModalForgotPass.preventDefault();
      this.handleSubmitForgotPassword(bvModalForgotPass);
    },
    handleSubmitForgotPassword() {
      if (this.checkForgotPasswordFormValidity()) {
        this.formForgotPass.modalForgotPassword = false;
        this.$parent.showModalMessage(
          "Un courriel vous a été envoyé à l'adresse courriel suivante : " +
            this.formForgotPass.email,
          "info"
        );
        this.resetModalForgotPassword();
      }
    },
    resetModalForgotPassword() {
      this.formForgotPass.email = "";
      this.formForgotPass.emailState = null;
      this.formForgotPass.showDismissibleAlert = false;
    },
    validEmail: (email) => {
      const emailReg = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
      return emailReg.test(email);
    }
  }
};
</script>
