using System;

namespace WebApiTest.Models
{
    public class ContactModel : IEquatable<ContactModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CompanyName { get; set; }

        public bool IsFavorite { get; set; }

        public string SmallImageURL { get; set; }

        public string LargeImageURL { get; set; }

        public string EmailAddress { get; set; }

        public DateTime? Birthdate { get; set; }

        public PhoneModel Phone { get; set; }

        public AddressModel Address { get; set; }

        public bool Equals(ContactModel other)
        {
            return Id == other.Id;
        }
    }
}