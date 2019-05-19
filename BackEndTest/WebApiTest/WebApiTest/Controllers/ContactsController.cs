using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTest.Interface;
using WebApiTest.Models;

namespace WebApiTest.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsLogic contactsLogic;

        public ContactsController(IContactsLogic contactsLogic)
        {
            this.contactsLogic = contactsLogic;
        }

        [HttpPost]
        [Route("AddContact")]
        public void AddContact([FromBody] ContactModel contact)
        {
            contact.Id = contactsLogic.GenerateID();
            contactsLogic.AddOrUpdateContact(contact);
        }

        [HttpPost]
        [Route("UpdateContact")]
        public void UpdateContact([FromBody] ContactModel contact)
        {
            contactsLogic.AddOrUpdateContact(contact);
        }

        [HttpGet]
        [Route("RetriveContactsById")]
        public ContactModel RetriveContactsById(int id)
        {
            return contactsLogic.RetriveContactById(id);
        }

        [HttpGet]
        [HttpPost]
        [Route("RetriveContactsByFilter")]
        public IEnumerable<ContactModel> RetriveContactsByFilter(FilterContactModel filter)
        {
            if (!filter.IsEmpty)
            {
                return contactsLogic.RetriveContactsByFilter(filter);
            }
            else
            {
                return contactsLogic.RetriveAllContacts();
            }
        }

        [HttpPost]
        [Route("DeleteContact")]
        public void DeleteContact([FromBody]ContactModel contact)
        {
            contactsLogic.DeleteContact(contact);
        }

        [HttpGet]
        [Route("RetriveAllContacts")]
        public IEnumerable<ContactModel> RetriveAllContacts()
        {
            return contactsLogic.RetriveAllContacts();
        }
    }
}