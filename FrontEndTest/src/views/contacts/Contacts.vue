<template>
  <div>
    <NavBar></NavBar>
    <v-layout justify-center class="mt-5 pt-5">
      <v-card>
        <v-toolbar card prominent>
          <v-layout align-center justify-center column fill-height>
            <v-toolbar-title>Contacts</v-toolbar-title>
          </v-layout>
        </v-toolbar>

        <div v-if="favoriteContacts.length > 0">
          <v-toolbar card :height="heightSubToolbar" :color="colorSubToolbar">
            <v-toolbar-title class="body-2">Favorite Contacts</v-toolbar-title>
          </v-toolbar>
          <ContactsList :contacts="favoriteContacts" :click-item="selectContact"></ContactsList>
        </div>
        <div v-if="contacts.length > 0">
          <v-toolbar card :height="heightSubToolbar" :color="colorSubToolbar">
            <v-toolbar-title class="body-2">Other Contacts</v-toolbar-title>
          </v-toolbar>
          <ContactsList :contacts="contacts" :click-item="selectContact"></ContactsList>
        </div>
      </v-card>
      <v-flex v-if="imageHeight && selectionEnable" xs1></v-flex>
      <v-expand-x-transition v-if="imageHeight">
        <div v-show="selectionEnable">
          <ContactDetail :contact="contactSelected" :back-click="backToContacts" :width="400"></ContactDetail>
        </div>
      </v-expand-x-transition>
      <div v-else>
        <v-dialog v-model="selectionEnable" :max-width="maxDialogWidth">
          <ContactDetail :contact="contactSelected" :back-click="backToContacts"></ContactDetail>
        </v-dialog>
      </div>
    </v-layout>
  </div>
</template>



<script>
import { ContactModel } from "@/models/ContactModel";
import ContactsList from "@/components/contacts/ContactsList";
import ContactDetail from "@/components/contacts/ContactDetail";
import NavBar from "@/components/shared/NavBar";

export default {
  components: {
    ContactsList,
    ContactDetail,
    NavBar
  },
  data() {
    return {
      allcontacts: [],
      heightSubToolbar: 25,
      colorSubToolbar: "#e1e1e1",
      selectionEnable: false,
      contactSelected: new ContactModel()
    };
  },
  methods: {
    objectToContact: function(object) {
      return new ContactModel(object);
    },

    filterByFavorite: function(contact) {
      return contact.IsFavorite;
    },

    filterByNotFavorite: function(contact) {
      return !contact.IsFavorite;
    },

    orderByName: function(contactA, contactB) {
      if (contactA.Name < contactB.Name) {
        return -1;
      }
      if (contactA.Name > contactB.Name) {
        return 1;
      }
      return 0;
    },

    selectContact: function(contact) {
      this.selectionEnable = true;
      this.contactSelected = contact;
    },

    backToContacts: function() {
      this.selectionEnable = false;
      this.contactSelected = null;
    }
  },
  mounted() {
    const axios = require("axios");
    axios
      .get("https://s3.amazonaws.com/technical-challenge/v3/contacts.json")
      .then(response => {
        let allDisorderedContacts = response.data.map(x =>
          this.objectToContact(x)
        );
        this.allcontacts = allDisorderedContacts.sort(this.orderByName);
      });
  },
  computed: {
    favoriteContacts: function() {
      return this.allcontacts
        ? this.allcontacts.filter(this.filterByFavorite)
        : null;
    },

    contacts: function() {
      return this.allcontacts
        ? this.allcontacts.filter(this.filterByNotFavorite)
        : null;
    },

    imageHeight() {
      let result = false;
      switch (this.$vuetify.breakpoint.name) {
        case "xs":
          result = false;
          break;
        case "sm":
          result = false;
          break;
        case "md":
          result = true;
          break;
        case "lg":
          result = true;
          break;
        case "xl":
          result = true;
          break;
      }
      return result;
    },

    maxDialogWidth() {
      let result = 0;
      switch (this.$vuetify.breakpoint.name) {
        case "xs":
          result = 300;
          break;
        case "sm":
          result = 500;
          break;
      }

      return result;
    }
  }
};
</script>

