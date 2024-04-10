using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Domain.Entities
{
	public class UsersGovsCount
	{
        public int Id { get; set; }
        public string GovName { get; set; }
        public int GovernateId { get; set; }
        public int Count { get; set; }
    }
}
