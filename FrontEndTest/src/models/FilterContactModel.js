export class FilterContactModel{

    constructor(emailAddress, phoneNumer){
        this.emailAddress = emailAddress
        this.phoneNumer = phoneNumer;
    }

    get EmailAddress() {
        return this.emailAddress
    }

    set EmailAddress(value) {
        this.emailAddress = value
    }

    get PhoneNumer() {
        return this.phoneNumer
    }

    set PhoneNumer(value) {
        this.phoneNumer = value
    }

}