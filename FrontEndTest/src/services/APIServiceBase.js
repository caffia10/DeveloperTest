export class APIServiceBase {

    constructor(path) {
        this.axios = require("axios")
        this.rootPath = "http://localhost/WebApiTest/api/" + path
    }

    Post(path, data) {
        return this.axios.post(this.rootPath + path, data)
    }

    Get(path, data) {
        return this.axios.get(this.rootPath + path, data)
    }
}