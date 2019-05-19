using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Utils;

namespace WebApiTest.Models
{
    public class FilterContactModel
    {
        public string EmailAddress { get; set; }

        public string PhoneNumer { get; set; }


        public bool IsEmpty => EmailAddress.IsNullOrEmpty() || PhoneNumer.IsNullOrEmpty();
    }
}
