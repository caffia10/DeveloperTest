<template>
  <v-list two-line v-if="contacts">
    <template v-for="(contact, index) in contacts">
      <v-list-tile :key="contact.Id" avatar @click="clickItem(contact)">
        <v-list-tile-avatar :tile="title" size="50">
          <img :src="contact.SmallImageURL || haveErrorOnLoadImage" @error="OnErrorImage(contact)">
        </v-list-tile-avatar>

        <v-list-tile-content>
          <v-layout align-center justify-start row>
            <v-btn
              flat
              icon
              v-if="contact.IsFavorite"
              color="yellow darken-2"
              @click="ChangeFavoriteStatus(contact, false)"
            >
              <v-icon>star</v-icon>
            </v-btn>
            <v-btn
              flat
              icon
              v-else
              color="grey lighten-1"
              @click="ChangeFavoriteStatus(contact, true)"
            >
              <v-icon>star_border</v-icon>
            </v-btn>
            <v-layout column>
              <v-list-tile-title>{{contact.Name}}</v-list-tile-title>
              <v-list-tile-sub-title>{{contact.CompanyName}}</v-list-tile-sub-title>
            </v-layout>
          </v-layout>
        </v-list-tile-content>
      </v-list-tile>
      <v-divider class="ml-2 mr-2" :key="'divider-id'+index" v-if="index + 1 < contacts.length"></v-divider>
    </template>
  </v-list>
</template>


<script>
export default {
  props: {
    contacts: null,
    clickItem: { type: Function }
  },
  data() {
    return {
      title: true,
      haveErrorOnLoadImage: require("@/assets/User Small/User Icon Small.png")
    };
  },
  methods: {
    ChangeFavoriteStatus: function(contact, isFavorite) {
      contact.IsFavorite = isFavorite;
    },
    OnErrorImage: function(contact) {
      contact.SmallImageURL = null;
    }
  }
};
</script>



