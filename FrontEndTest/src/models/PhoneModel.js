export class PhoneModel {

    constructor(work, home, mobile) {
        this.work = work
        this.home = home
        this.mobile = mobile
    }

    get Work() {
        return this.work
    }

    set Work(value) {
        this.work = value
    }

    get Home() {
        return this.home
    }

    set Home(value) {
        this.home = value
    }

    get Mobile() {
        return this.mobile
    }

    set Mobile(value) {
        this.mobile = value
    }

}