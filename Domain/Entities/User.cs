using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string MobileNumber { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
    }
}
