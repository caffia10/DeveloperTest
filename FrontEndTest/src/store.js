import Vue from 'vue'
import Vuex from 'vuex'
import ContactEditor from './views/contacts/ContactEditor.vue'
import DeleteContact from './views/contacts/DeleteContact.vue'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    routes: {
      'contactEditor': ContactEditor,
      'deleteContact': DeleteContact
    }
  },
  mutations: {

  },
  actions: {

  },
  getters: {
    routes: state => state.routes
  }
})
