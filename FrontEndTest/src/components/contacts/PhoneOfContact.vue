<template>
  <v-container fluid>
    <v-layout column>
      <v-flex xs12 class="grey--text">Phone:</v-flex>
      <v-flex xs12>
        <v-layout row class="mt-2">
          <v-flex xs6>{{number}}</v-flex>
          <v-flex offset-xs2 xs4 class="text-xs-right">{{type}}</v-flex>
        </v-layout>
      </v-flex>
    </v-layout>
  </v-container>
</template>


<script>
export default {
  props: {
    number: "",
    type: ""
  }
};
</script>
