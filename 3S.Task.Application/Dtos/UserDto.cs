﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Application.Dtos
{
	public class UserDto
	{


		public string FirstName { get; set; }

		public string MiddleName { get; set; }

		public string LastName { get; set; }

		public DateTime BirthDate { get; set; }

		public string MobileNumber { get; set; }

		public string Email { get; set; }

		public virtual ICollection<AddressDto> Addresses { get; set; } = new HashSet<AddressDto>();
	}
}
