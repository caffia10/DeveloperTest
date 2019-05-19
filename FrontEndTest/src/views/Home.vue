
<template>
  <v-layout align-center column>
    <div class="background"></div>
    <div class="content mt-2 pa-5">
      <v-container fluid>
        <v-layout align-center column>
          <h1
            class="display-4 font-weight-black white--text text-xs-center"
          >Welcome to Solstice Dev Test</h1>
          <v-layout row>
            <router-link to="/contacts" class="ml-3 mr-3 mt-5 simple-text">
              <v-card class="v-card-selecteable" color="transparent">
                <v-layout class="mt-3" align-center justify-center column fill-height>
                  <v-img :src="editorImg" height="80" width="80"></v-img>
                  <v-card-title primary-title>
                    <h4 class="display-1">Front-End Test</h4>
                  </v-card-title>
                </v-layout>
              </v-card>
            </router-link>

            <router-link to="/contactsHandler" class="ml-3 mr-3 mt-5 simple-text">
              <v-card class="v-card-selecteable" color="transparent">
                <v-layout class="mt-3" align-center justify-center column fill-height>
                  <v-img :src="serverImg" height="80" width="80"></v-img>
                  <v-card-title primary-title>
                    <h4 class="display-1">Back-End Test</h4>
                  </v-card-title>
                </v-layout>
              </v-card>
            </router-link>
          </v-layout>
        </v-layout>
      </v-container>
    </div>
  </v-layout>
</template>

<script>
export default {
  data() {
    return {
      serverImg: require("@/assets/svg/server.svg"),
      editorImg: require("@/assets/svg/editor.svg")
    };
  }
};
</script>


<style lang="scss" scoped>
.simple-text {
  text-decoration: none !important;
}

.v-card-selecteable {
  border: solid 1.5px !important;
  border-color: transparent !important;
}

.v-card-selecteable:hover {
  border-color: #ffa000 !important;
  color: #ffa000 !important;
}

.transparent {
  background-color: white !important;
  opacity: 0.65;
  border-color: transparent !important;
}

.content {
  z-index: 1;
  position: fixed;
}

body {
  width: 100vw;
  height: 100vh;
  overflow: hidden;
  display: flex;
}

.background {
  position: absolute;
  width: 100%;
  height: 100%;
  background: url(https://lh4.googleusercontent.com/proxy/gdKMsKqzMFQ1xEVJf9lNNfL7pw_HG3DaHZij1yJPHGPLQYzY_FXqVrSsC0Q2VK49HPML25NGCls545UIGYmTs6y11TAXtLcKAv_HmKA=w3840-h2160-p-k-no-nd-mv);
  background-position: center center;
  background-size: cover;
  animation: zoom 100s infinite alternate;
  animation-timing-function: linear;
  /* 	filter: blur(2px); */
}

#app {
  z-index: 10;
  width: 250px;
  height: 250px;
  margin: auto;
  // box-shadow: 10px 10px 50px rgba(0,0,0,0.25);
  // filter: blur(10px);
  /* 	background:rgba(255,255,255,0.5); */
  border-radius: 8px;
  position: relative;
}

@keyframes zoom {
  from {
    transform: scale(1.01);
  }

  to {
    transform: scale(1.5);
  }
}
</style>
