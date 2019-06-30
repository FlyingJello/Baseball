import Vue from 'vue'
import Router from 'vue-router'

import Homepage from './views/Homepage.vue'
import Login from './views/Login.vue'

import Management from './views/management/Management.vue'
import Dashboard from './views/management/Dashboard.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/home',
      name: 'Homepage',
      component: Homepage
    },
    {
      path: '/login',
      name: 'Login',
      component: Login
    },
    {
      path: '/management',
      component: Management,
      children: [
        { 
          path: '',
          name: 'Dashboard',
          component: Dashboard
        }
      ]
    },
  ]
})
