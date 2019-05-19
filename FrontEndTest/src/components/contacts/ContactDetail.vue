<template>
  <v-card v-if="contact" :width="width">
    <v-toolbar card height="35">
      <v-btn flat small color="primary" @click="backClick">
        <v-icon>keyboard_arrow_left</v-icon>Contacts
      </v-btn>
      <v-spacer></v-spacer>
      <v-btn
        flat
        icon
        v-if="contact.IsFavorite"
        color="yellow darken-2"
        @click="ChangeFavoriteStatus(contact, false)"
      >
        <v-icon>star</v-icon>
      </v-btn>
      <v-btn flat icon v-else color="grey lighten-1" @click="ChangeFavoriteStatus(contact, true)">
        <v-icon>star_border</v-icon>
      </v-btn>
    </v-toolbar>
    <v-layout column>
      <div class="ml-3 mr-3 mt-5 mb-4 pl-2 pr-2">
        <v-layout align-center justify-center column fill-height>
          <img
            :src="contact.LargeImageURL || haveErrorOnLoadImage"
            height="180"
            width="180"
            @error="OnErrorImage(contact)"
          >
          <h3 class="mt-2 display-2 text-xs-center">{{contact.Name}}</h3>
          <h5 class="headline grey--text text-xs-center">{{contact.CompanyName}}</h5>
        </v-layout>
      </div>
      <v-list v-if="contact.Phone != null">
        <div v-if="contact.Phone.Home != null">
          <v-divider></v-divider>
          <v-list-tile-content>
            <PhoneOfContact :number="contact.Phone.Home" type="Home"></PhoneOfContact>
          </v-list-tile-content>
        </div>
        <div v-if="contact.Phone.Mobile != null">
          <v-divider></v-divider>
          <v-list-tile-content>
            <PhoneOfContact :number="contact.Phone.Mobile" type="Mobile"></PhoneOfContact>
          </v-list-tile-content>
        </div>
        <div v-if="contact.Phone.Work != null">
          <v-divider></v-divider>
          <v-list-tile-content>
            <PhoneOfContact :number="contact.Phone.Work" type="Work"></PhoneOfContact>
          </v-list-tile-content>
        </div>
      </v-list>
    </v-layout>
  </v-card>
</template>


<script>
import { ContactModel } from "@/models/ContactModel";
import PhoneOfContact from "@/components/contacts/PhoneOfContact";

export default {
  components: {
    PhoneOfContact
  },
  props: {
    contact: new ContactModel(),
    backClick: { type: Function },
    width: null
  },
  data() {
    return {
      haveErrorOnLoadImage: require("@/assets/User Small/User Icon Small.png")
    };
  },
  methods: {
    ChangeFavoriteStatus: function(contact, isFavorite) {
      contact.IsFavorite = isFavorite;
    },

    OnErrorImage: function(contact) {
      contact.LargeImageURL = null;
    }
  }
};
</script>


<style lang="scss" scoped>
/* 
  ##Device = Desktops
  ##Screen = 1281px to higher resolution desktops
*/

@media (min-width: 1281px) {
  //CSS
}

/* 
  ##Device = Laptops, Desktops
  ##Screen = B/w 1025px to 1280px
*/

@media (min-width: 1025px) and (max-width: 1280px) {
  //CSS
}

/* 
  ##Device = Tablets, Ipads (portrait)
  ##Screen = B/w 768px to 1024px
*/

@media (min-width: 768px) and (max-width: 1024px) {
  //CSS
}

/* 
  ##Device = Tablets, Ipads (landscape)
  ##Screen = B/w 768px to 1024px
*/

@media (min-width: 768px) and (max-width: 1024px) and (orientation: landscape) {
  //CSS
}

/* 
  ##Device = Low Resolution Tablets, Mobiles (Landscape)
  ##Screen = B/w 481px to 767px
*/

@media (min-width: 481px) and (max-width: 767px) {
  //CSS
}

/* 
  ##Device = Most of the Smartphones Mobiles (Portrait)
  ##Screen = B/w 320px to 479px
*/

@media (min-width: 320px) and (max-width: 480px) {
  //CSS
}
</style>