<template>
  <div>
    <p>dashboard page</p>
    <p>voici une liste des utilisateurs</p>
    <em v-if="users.loading">Loading users...</em>
    <span v-if="users.error" class="text-danger">ERROR: {{users.error}}</span>
    <ul v-if="users.items">
      <li v-for="user in users.items" :key="user.username">{{user.username}}</li>
    </ul>
  </div>
</template>

<script>
export default {
  computed: {
    user() {
      return this.$store.state.authentication.user;
    },
    users() {
      return this.$store.state.users.all;
    }
  },
  created() {
    this.$store.dispatch("users/getAll");
  }
};
</script>
