import { AddressModel } from "@/models/AddressModel";
import { PhoneModel } from "@/models/PhoneModel";

export class ContactModel {
    constructor(data) {
        Object.assign(this, data)
        this.phone = Object.assign(new PhoneModel(), this.phone)
        this.address = Object.assign(new AddressModel(), this.address)
    }

    get Id() {
        return this.id
    }

    set Id(value) {
        this.id = value
    }

    get Name() {
        return this.name
    }

    set Name(value) {
        this.name = value
    }

    get CompanyName() {
        return this.companyName
    }

    set CompanyName(value) {
        this.companyName = value
    }


    get IsFavorite() {
        return this.isFavorite
    }

    set IsFavorite(value) {
        this.isFavorite = value
    }


    get SmallImageURL() {
        return this.smallImageURL
    }

    set SmallImageURL(value) {
        this.smallImageURL = value
    }


    get LargeImageURL() {
        return this.largeImageURL
    }

    set LargeImageURL(value) {
        this.largeImageURL = value
    }


    get EmailAddress() {
        return this.emailAddress
    }

    set EmailAddress(value) {
        this.emailAddress = value
    }


    get Birthdate() {
        return this.birthdate
    }

    set Birthdate(value) {
        this.birthdate = value
    }

    get Phone() {
        if (this.phone == null) {
            this.phone = new PhoneModel();
        }

        return this.phone
    }

    set Phone(value) {
        this.phone = Object.assign(new PhoneModel(), value);
    }

    get Address() {
        if (this.address == null) {
            this.address = new AddressModel();
        }

        return this.address
    }

    set Address(value) {
        this.address = Object.assign(new AddressModel(), value);
    }
}