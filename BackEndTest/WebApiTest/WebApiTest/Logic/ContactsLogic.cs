using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Interface;
using WebApiTest.Models;

namespace WebApiTest.Logic
{
    public class ContactsLogic : IContactsLogic
    {
        private int lastGeneratedID;
        private readonly ConcurrentDictionary<int,ContactModel> allContacts = new ConcurrentDictionary<int, ContactModel>();

        public void AddOrUpdateContact(ContactModel contact)
        {
            allContacts.AddOrUpdate(contact.Id, contact,(key, existingContact) => {
                if (contact != existingContact)
                    throw new ArgumentException("Duplicate contact are not allowed: {0}.", contact.Name);

                existingContact = contact;

                return existingContact;
            });
        }

        public ContactModel RetriveContactById(int id)
        {
            return RetriveAllContacts().SingleOrDefault(x => x.Id == id);
        }

        public void DeleteContact(ContactModel contact)
        {
            allContacts.Remove(contact.Id,out contact);
        }

        public IEnumerable<ContactModel> RetriveAllContacts()
        {
            return allContacts.Values;
        }

        public IEnumerable<ContactModel> RetriveContactsByFilter(FilterContactModel filter)
        {
            return RetriveAllContacts().Where(x => ContactCompliesWithTheFilter(x, filter));
        }

        private bool ContactCompliesWithTheFilter(ContactModel contact, FilterContactModel filter)
        {
            return PhoneContactCompliesWithTheFilter(contact.Phone, filter.PhoneNumer) || contact.EmailAddress == filter.EmailAddress;
        }

        private bool PhoneContactCompliesWithTheFilter(PhoneModel phone, string phoneNumer)
        {
            return phone.Home == phoneNumer || phone.Work == phoneNumer || phone.Mobile == phoneNumer;
        }

        public int GenerateID()
        {
            return ++lastGeneratedID;
        }
    }
}
