<template>
  <div>
    <NavBar></NavBar>
    <v-container fluid class="mt-5 pt-5">
      <v-layout column>
        <v-flex class="mt-4">
          <v-layout align-start justify-start row fill-height wrap>
            <v-flex md5 xs12>
              <v-text-field solo label="search" v-model="searchTerms"></v-text-field>
            </v-flex>
            <v-flex>
              <v-btn
                :loading="loading"
                :disabled="loading"
                color="secondary"
                @click="searchValueByFilter"
              >Search</v-btn>
              <v-btn :loading="loading2" :disabled="loading2" color="info" @click="refreshGrid">
                Refresh
                <template v-slot:loader>
                  <span class="custom-loader">
                    <v-icon light>cached</v-icon>
                  </span>
                </template>
              </v-btn>
            </v-flex>
          </v-layout>
        </v-flex>
        <v-flex>
          <v-data-table
            :headers="headers"
            :items="contacts"
            class="elevation-1"
            :class="{'mt-4':imageHeight}"
          >
            <template v-slot:items="props">
              <tr @click="saveSelectedContact(props.item)">
                <td>
                  <v-checkbox
                    color="primary"
                    :value="selectedContact != null && props.item.Id == selectedContact.Id"
                    hide-details
                    readonly
                  ></v-checkbox>
                </td>
                <td>{{ props.item.Id }}</td>
                <td class="text-xs-right">{{ props.item.Name }}</td>
                <td class="text-xs-right">{{ props.item.CompanyName }}</td>
                <td class="text-xs-right">{{ props.item.EmailAddress }}</td>
                <td class="text-xs-right">{{ props.item.Phone.Work }}</td>
                <td class="text-xs-right">{{ props.item.Phone.Mobile }}</td>
                <td class="text-xs-right">{{ props.item.Phone.Home }}</td>
              </tr>
            </template>
          </v-data-table>
        </v-flex>
        <ManagementActions
          add-component-name="contactEditor"
          add-title-modal="Create a new contact"
          :on-accept-click-add-modal="addContact"
          edit-component-name="contactEditor"
          edit-title-modal="Edit selected contact"
          :on-accept-click-edit-modal="updateContact"
          delete-component-name="deleteContact"
          delete-title-modal="Delete selected contact"
          :on-accept-click-delete-modal="deleteContact"
          :create-new-model-instance="instanceNewContact"
          :get-selected-model-async="getSelectedContactAsync"
          :get-selected-model="getSelectedContact"
          :have-selected-value="selectedContact != null"
        />
      </v-layout>
    </v-container>
  </div>
</template>


<script>
import NavBar from "@/components/shared/NavBar";
import ManagementActions from "@/components/shared/ManagementActions";
import { ContactModel } from "@/models/ContactModel";
import { ContactAPIService } from "@/services/ContactAPIService";
import { FilterContactModel } from "@/models/FilterContactModel";

export default {
  components: {
    ManagementActions,
    NavBar
  },
  data() {
    return {
      headers: [
        { text: "", value: "" },
        {
          text: "Id",
          align: "left",
          sortable: false,
          value: "Id"
        },
        { text: "Name", value: "Name" },
        { text: "Company Name", value: "CompanyName" },
        { text: "Email Address", value: "EmailAddress" },
        { text: "Work Phone", value: "Phone.Work" },
        { text: "Mobile Phone", value: "Phone.Mobile" },
        { text: "Home Phone", value: "Phone.Home" }
      ],
      contacts: [],
      selectedContact: null,
      loader: null,
      loading: false,
      loading2: false,
      searchTerms: "",
      checked: false
    };
  },
  methods: {
    objectToContact: function(object) {
      return new ContactModel(object);
    },

    addContact: function(contact) {
      ContactAPIService.getInstance().addContact(contact);
    },

    updateContact: function(contact) {
      ContactAPIService.getInstance().updateContact(contact);
    },

    deleteContact: function(contact) {
      ContactAPIService.getInstance().deleteContact(contact);
    },

    instanceNewContact: function() {
      return new ContactModel();
    },

    saveSelectedContact: function(contact) {
      this.selectedContact = contact;
    },

    getSelectedContactAsync: function() {
      this.retriveContactsByID(this.selectedContact.Id);
      return this.selectedContact;
    },

    getSelectedContact: function() {
      return this.selectedContact;
    },

    retriveContactsByID: function(id) {
      ContactAPIService.getInstance()
        .retriveContactsById(id)
        .then(response => {
          this.selectedContact = this.objectToContact(response.data);
        });
    },

    retriveContactsByFilter: async function(filter) {
      return ContactAPIService.getInstance()
        .retriveContactsByFilter(filter)
        .then(response => {
          this.contacts = response.data.map(x => this.objectToContact(x));
        });
    },

    searchValueByFilter: async function() {
      this.loader = "loading";
      const l = this.loader;
      this[l] = !this[l];

      await this.retriveContactsByFilter(
        new FilterContactModel(this.searchTerms, this.searchTerms)
      );
      this[l] = false;
    },

    retriveAllContacts: async function() {
      return ContactAPIService.getInstance()
        .retriveAllContacts()
        .then(response => {
          this.contacts = response.data.map(x => this.objectToContact(x));
        });
    },

    refreshGrid: async function() {
      this.loader = "loading2";
      const l = this.loader;
      this[l] = !this[l];
      await this.retriveAllContacts();

      this[l] = false;
    }
  },
  computed: {
    imageHeight() {
      let result = false;
      switch (this.$vuetify.breakpoint.name) {
        case "xs":
          result = true;
          break;
        default:
          result = false;
          break;
      }
      return result;
    }
  },
  mounted() {
    this.retriveAllContacts();
  }
};
</script>


<style lang="scss" scoped>
.custom-loader {
  animation: loader 1s infinite;
  display: flex;
}
@-moz-keyframes loader {
  from {
    transform: rotate(0);
  }
  to {
    transform: rotate(360deg);
  }
}
@-webkit-keyframes loader {
  from {
    transform: rotate(0);
  }
  to {
    transform: rotate(360deg);
  }
}
@-o-keyframes loader {
  from {
    transform: rotate(0);
  }
  to {
    transform: rotate(360deg);
  }
}
@keyframes loader {
  from {
    transform: rotate(0);
  }
  to {
    transform: rotate(360deg);
  }
}
</style>