import { APIServiceBase } from "@/services/APIServiceBase";

export class ContactAPIService extends APIServiceBase {
    constructor() {
        super("contacts/")
        this.intance;
    }

    static getInstance() {
        if (this.intance == null) {
            this.intance = new ContactAPIService();
        }

        return this.intance
    }

    addContact(contact) {
        this.Post("AddContact", contact)
    }

    updateContact(contact) {
        this.Post("UpdateContact", contact)
    }

    retriveContactsById(id) {
        return this.Get("RetriveContactsById", {
            params: {
                id: id
            }
        })
    }

    retriveContactsByFilter(filter) {
        return this.Post("RetriveContactsByFilter", filter)
    }

    deleteContact(contact) {
        this.Post("DeleteContact", contact)
    }

    retriveAllContacts(contact) {
        return this.Get("RetriveAllContacts", contact)
    }
}