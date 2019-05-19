<template>
  <v-speed-dial bottom fixed right>
    <v-btn slot="activator" color="blue darken-2" dark fab>
      <v-icon>account_circle</v-icon>
      <v-icon>close</v-icon>
    </v-btn>
    <OpenModalButton
      fab
      icon="add"
      color="green"
      :component-name="addComponentName"
      :title-modal="addTitleModal"
      :on-accept-click="onAcceptClickAddModal"
      :model="model"
      :is-edit="false"
      :instance-model="createNewModelInstance"
    />
    <OpenModalButton
      fab
      icon="edit"
      color="indigo"
      :component-name="editComponentName"
      :title-modal="editTitleModal"
      :on-accept-click="onAcceptClickEditModal"
      :model="model"
      :is-edit="true"
      :get-selected-model="getSelectedModelAsync"
      :enable-action="haveSelectedValue"
    />
    <OpenModalButton
      fab
      icon="delete"
      color="red"
      :component-name="deleteComponentName"
      :title-modal="deleteTitleModal"
      :on-accept-click="onAcceptClickDeleteModal"
      :model="model"
      :is-edit="true"
      :get-selected-model="getSelectedModel"
      :enable-action="haveSelectedValue"
    />
  </v-speed-dial>
</template>


<script>
import OpenModalButton from "@/components/shared/OpenModalButton";

export default {
  components: {
    OpenModalButton
  },
  props: {
    addComponentName: {
      type: String,
      required: true
    },
    addTitleModal: {
      type: String,
      required: true
    },
    onAcceptClickAddModal: {
      type: Function,
      required: true
    },
    editComponentName: {
      type: String,
      required: true
    },
    editTitleModal: {
      type: String,
      required: true
    },
    onAcceptClickEditModal: {
      type: Function,
      required: true
    },
    deleteComponentName: {
      type: String,
      required: true
    },
    deleteTitleModal: {
      type: String,
      required: true
    },
    onAcceptClickDeleteModal: {
      type: Function,
      required: true
    },
    createNewModelInstance: {
      type: Function,
      required: true
    },
    getSelectedModelAsync: {
      type: Function,
      required: true
    },
    getSelectedModel: {
      type: Function,
      required: true
    },
    haveSelectedValue: Boolean
  },
  data() {
    return {
      modelContainer: null
    };
  },
  computed: {
    model: function() {
      return this.modelContainer;
    }
  }
};
</script>

<style lang="scss" scoped>
.v-btn--floating {
  position: relative;
}

v-btn {
  z-index: 99999;
}
</style>