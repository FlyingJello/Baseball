import router from '@/router';
import { api } from '@/api';

const user = JSON.parse(localStorage.getItem('user'));
const initialState = user
  ? { status: { loggedIn: true }, user }
  : { status: {}, user: null };

export const authentication = {
  namespaced: true,
  state: initialState,
  actions: {
    login({ commit }, { username, password }) {
      commit('loginRequest', { username });

      api.post('/authentication', { username, password })
        .then( ({ data }) => {
          if (data.token) {
            localStorage.setItem('user', JSON.stringify(data));
          }
          commit('loginSuccess', data);
          router.push('/management');
        })
        .catch(error => {
          console.error(error)
          commit('loginFailure', error)
        })
    },
    logout({ commit }) {
      localStorage.removeItem('user');
      commit('logout');
    }
  },
  mutations: {
    loginRequest(state, user) {
      state.status = { loggingIn: true };
      state.user = user;
    },
    loginSuccess(state, user) {
      state.status = { loggedIn: true };
      state.user = user;
    },
    loginFailure(state) {
      state.status = { success: false };
      state.user = null;
    },
    logout(state) {
      state.status = {};
      state.user = null;
    }
  }
}
