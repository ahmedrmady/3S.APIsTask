using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Application.Dtos
{
	public class AddressDto
	{
		public int GovernateId { get; set; }

		public int CityId { get; set; }
	
		public string Street { get; set; }

		public string BuildingNumber { get; set; }

		public int FlatNumber { get; set; }

	}
}
