<template>
  <v-toolbar fixed color="primary">
    <h6 class="title white--text">Solstice Dev. Test</h6>
    <v-spacer></v-spacer>

    <v-toolbar-items v-show="imageHeight" v-for="item in items" :key="item.title">
      <v-btn flat @click="$router.push(item.path)" class="white--text">{{item.title}}</v-btn>
    </v-toolbar-items>
    <div v-show="!imageHeight">
      <v-menu :nudge-width="100">
        <template v-slot:activator="{ on }">
          <v-toolbar-title v-on="on">
            <v-icon class="white--text">more_vert</v-icon>
          </v-toolbar-title>
        </template>

        <v-list>
          <v-list-tile v-for="item in items" :key="item.title">
            <v-list-tile-title v-text="item.title" @click="$router.push(item.path)"></v-list-tile-title>
          </v-list-tile>
        </v-list>
      </v-menu>
    </div>
  </v-toolbar>
</template>


<script>
export default {
  data() {
    return {
      items: [
        { title: "Home", path: "/" },
        { title: "Back-End Test", path: "/contactsHandler" },
        { title: "Front-End Test", path: "/contacts" }
      ]
    };
  },
  computed: {
    imageHeight() {
      switch (this.$vuetify.breakpoint.name) {
        case "xs":
          return false;
        default:
          return true;
      }
    }
  }
};
</script>


<style lang="scss" scoped>
.simple-text {
  text-decoration: none !important;
}
</style>
