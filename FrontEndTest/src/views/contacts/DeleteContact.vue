<template>
  <v-layout align-center justify-center column>
    <v-flex>
      <v-icon class="icon" color="orange">warning</v-icon>
    </v-flex>
    <v-flex>
      <h5 class="headline text-xs-center">Are you sure want to deleted this contact?</h5>
    </v-flex>
  </v-layout>
</template>

<script>
export default {
  props: {
    model: null,
    isEdit: false,
    getSelectedModel: { type: Function },
    isOpenModal: false,
    isSaving: false,
    isInvalid: false
  },
  methods: {
    onOpen: function() {
      if (this.isEdit) {
        this.contact = this.getSelectedModel();
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
      this.$emit("update:isInvalid", newValue);
    }
  }
};
</script>

<style lang="scss" scoped>
.icon {
  font-size: 100px;
}
</style>
