using MediatR;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Dtos;
using Task.Domain.Shared;

namespace Task.Application.Features
{
	public class CreateUserCommand:IRequest<ResponseModel>
	{
		public string FirstName { get; set; }

		public string MiddleName { get; set; }

		public string LastName { get; set; }

		public DateTime BirthDate { get; set; }

		public string MobileNumber { get; set; }

		public string Email { get; set; }

		public ICollection<AddressDto> Addresses { get; set; }

	}
}
