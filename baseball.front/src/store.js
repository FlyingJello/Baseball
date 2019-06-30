import Vue from 'vue'
import Vuex from 'vuex'

import { authentication } from './stores/authentication'
import { users } from './stores/users'

Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    authentication,
    users
  }
})
