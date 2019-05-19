import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'
import Contacts from './views/contacts/Contacts.vue'
import ContactsHandler from './views/contacts/ContactsHandler.vue'
import ContactEditor from './views/contacts/ContactEditor.vue'
import DeleteContact from './views/contacts/DeleteContact.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/contacts',
      name: 'contacts',
      component: Contacts
    },
    {
      path: '/contactsHandler',
      name: 'contactsHandler',
      component: ContactsHandler
    },
    {
      path: '/contactEditor-unpublic-path',
      name: 'contactEditor',
      component: ContactEditor
    },
    {
      path: '/deleteContact-unpublic-path',
      name: 'deleteContact',
      component: DeleteContact
    }
  ]
})
