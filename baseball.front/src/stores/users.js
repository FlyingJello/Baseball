import { api } from '@/api';

export const users = {
  namespaced: true,
  state: {
    all: {}
  },
  actions: {
    getAll({ commit }) {
      commit('getAllRequest')

      api.get('/users')
      .then(({ data }) => commit('getAllSuccess', data))
      .catch(error => commit('getAllFailure', error))
    }
  },
  mutations: {
    getAllRequest(state) {
      state.all = { loading: true }
    },
    getAllSuccess(state, users) {
      state.all = { items: users }
    },
    getAllFailure(state, error) {
      state.all = { error }
    }
  }
}
