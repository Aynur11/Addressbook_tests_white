using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_white
{
    public class ContactData
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public ContactData(string lastName, string firstName)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
        }
    }
}
