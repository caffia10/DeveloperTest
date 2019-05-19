using System.Collections.Generic;
using WebApiTest.Models;

namespace WebApiTest.Interface
{
    public interface IContactsLogic
    {
        void AddOrUpdateContact(ContactModel contact);

        ContactModel RetriveContactById(int id);

        IEnumerable<ContactModel> RetriveContactsByFilter(FilterContactModel filter);

        void DeleteContact(ContactModel contact);

        IEnumerable<ContactModel> RetriveAllContacts();

        int GenerateID();
    }
}