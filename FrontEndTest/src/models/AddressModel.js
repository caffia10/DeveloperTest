export class AddressModel {

    constructor(street, city, state, country, zipCode) {
        this.street = street
        this.city = city
        this.state = state
        this.country = country
        this.zipCode = zipCode
    }

    get Street() {
        return this.street
    }

    set Street(value) {
        this.street = value
    }

    get City() {
        return this.city
    }

    set City(value) {
        this.city = value
    }

    get State() {
        return this.state
    }

    set State(value) {
        this.state = value
    }

    get Country() {
        return this.country
    }

    set Country(value) {
        this.country = value
    }

    get ZipCode() {
        return this.zipCode
    }

    set ZipCode(value) {
        this.zipCode = value
    }
}