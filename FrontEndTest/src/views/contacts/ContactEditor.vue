
<template>
  <v-form v-model="valid">
    <v-container>
      <v-layout column v-if="contact != null">
        <v-flex>
          <v-layout row>
            <v-flex>
              <v-text-field
                v-model="contact.Name"
                :rules="nameRules"
                :counter="50"
                label="Full Name"
                required
              ></v-text-field>
            </v-flex>
          </v-layout>
        </v-flex>
        <v-flex>
          <v-text-field v-model="contact.CompanyName" label="Company Name"></v-text-field>
        </v-flex>
        <v-flex>
          <v-layout row wrap>
            <v-flex xs7>
              <v-text-field
                v-model="contact.EmailAddress"
                :rules="emailRules"
                label="E-mail"
                required
              ></v-text-field>
            </v-flex>
            <v-flex offset-xs1 xs4>
              <v-menu
                v-model="menu2"
                :close-on-content-click="false"
                :nudge-right="40"
                lazy
                transition="scale-transition"
                offset-y
                full-width
                min-width="290px"
              >
                <template v-slot:activator="{ on }">
                  <v-text-field
                    v-model="contact.Birthdate"
                    label="Birthdate"
                    prepend-icon="event"
                    readonly
                    v-on="on"
                  ></v-text-field>
                </template>
                <v-date-picker v-model="contact.Birthdate" @input="menu2 = false"></v-date-picker>
              </v-menu>
            </v-flex>
          </v-layout>
        </v-flex>
        <v-flex>
          <v-text-field v-model="contact.SmallImageURL" label="Small Image URL"></v-text-field>
        </v-flex>
        <v-flex>
          <v-text-field v-model="contact.LargeImageURL" label="Large Image URL"></v-text-field>
        </v-flex>
        <v-flex>
          <v-layout row>
            <v-flex xs3>
              <v-text-field v-model="contact.Phone.Work" label="Work Phone"></v-text-field>
            </v-flex>
            <v-flex offset-xs1 xs3>
              <v-text-field v-model="contact.Phone.Home" label="Home Phone"></v-text-field>
            </v-flex>
            <v-flex offset-xs1 xs3>
              <v-text-field v-model="contact.Phone.Mobile" label="Mobile Phone"></v-text-field>
            </v-flex>
          </v-layout>
        </v-flex>
        <v-flex>
          <v-layout row>
            <v-flex xs5>
              <v-text-field v-model="contact.Address.Street" label="Street"></v-text-field>
            </v-flex>
            <v-flex offset-xs2 xs5>
              <v-text-field v-model="contact.Address.City" label="City"></v-text-field>
            </v-flex>
          </v-layout>
        </v-flex>
        <v-flex>
          <v-layout row>
            <v-flex xs5>
              <v-text-field v-model="contact.Address.State" label="State"></v-text-field>
            </v-flex>
            <v-flex offset-xs2 xs5>
              <v-text-field v-model="contact.Address.Country" label="Country"></v-text-field>
            </v-flex>
          </v-layout>
        </v-flex>
        <v-flex>
          <v-layout row>
            <v-flex xs4>
              <v-text-field v-model="contact.Address.ZipCode" label="ZipCode"></v-text-field>
            </v-flex>
          </v-layout>
        </v-flex>
      </v-layout>
    </v-container>
  </v-form>
</template>


<script>
import { ContactModel } from "@/models/ContactModel";

export default {
  props: {
    model: null,
    isEdit: false,
    instanceModel: { type: Function },
    getSelectedModel: { type: Function },
    isOpenModal: false,
    isSaving: false,
    isInvalid: false
  },
  data() {
    return {
      valid: false,
      nameRules: [
        v => !!v || "Name is required",
        v =>
          (v != null && v.length <= 50) ||
          "Name must be less than 50 characters"
      ],
      email: "",
      emailRules: [
        v => !!v || "E-mail is required",
        v => /.+@.+/.test(v) || "E-mail must be valid"
      ],
      menu2: false,
      date: new Date().toISOString().substr(0, 10),
      contact: this.model
    };
  },
  methods: {
    onOpen: function() {
      if (this.isEdit) {
        this.contact = this.getSelectedModel();
      } else {
        this.contact = this.instanceModel();
      }
    }
  },
  watch: {
    isOpenModal: function(newValue) {
      if (newValue) {
        this.onOpen();
      }
    },
    isSaving: function(newValue) {
      if (newValue) {
        this.$emit("update:model", this.contact);
      }
    },
    valid: function(newValue) {
      console.log(newValue);
      this.$emit("update:isInvalid", newValue);
    }
  }
};
</script>
