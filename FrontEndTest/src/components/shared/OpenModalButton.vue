<template>
  <v-layout row justify-center>
    <v-dialog v-model="dialog" scrollable persistent max-width="600">
      <template v-slot:activator="{ on }">
        <v-btn fab dark small v-on="on" :color="color" v-if="enableAction == null || enableAction">
          <v-icon>{{icon}}</v-icon>
        </v-btn>
      </template>
      <v-card v-cloak>
        <v-card-title>
          <h5 class="headline primary--text">{{titleModal}}</h5>
        </v-card-title>
        <v-divider></v-divider>
        <v-card-text>
          <component
            :is="routedComponent"
            :isEdit="isEdit"
            :model.sync="modelChanged"
            :instanceModel="instanceModel"
            :getSelectedModel="getSelectedModel"
            :isOpenModal="dialog"
            :isSaving="isSaving"
            :isInvalid.sync="valid"
          ></component>
        </v-card-text>
        <v-divider></v-divider>

        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="red darken-1" flat @click="dialog = false">Cancel</v-btn>
          <v-btn
            color="green darken-1"
            flat
            @click="acceptClick"
            :disabled="valid != null && !valid"
          >Accept</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-layout>
</template>

<script>
import store from "@/store";

export default {
  props: {
    icon: {
      type: String,
      required: true
    },
    color: {
      type: String,
      required: true
    },
    componentName: {
      type: String,
      required: true
    },
    titleModal: null,
    onAcceptClick: { type: Function },
    model: null,
    isEdit: false,
    instanceModel: { type: Function },
    getSelectedModel: { type: Function },
    enableAction: null
  },
  data() {
    return {
      dialog: false,
      isSaving: false,
      modelChanged: this.model,
      valid: null
    };
  },
  methods: {
    acceptClick: async function() {
      this.isSaving = true;
      this.$nextTick(() => {
        console.log(this.modelChanged);
        this.onAcceptClick(this.modelChanged);
        this.dialog = false;
      });
    }
  },
  computed: {
    routedComponent() {
      return store.getters.routes[this.componentName];
    }
  }
};
</script>

