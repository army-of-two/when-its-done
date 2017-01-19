using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhenItsDone.Models
{
    public class ContactInformation
    {
        public int Id { get; set; }

        public Address Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
