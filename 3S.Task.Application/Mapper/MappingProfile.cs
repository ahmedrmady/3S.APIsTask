using Task.Application.Dtos;
using Task.Application;
using AutoMapper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Features;
using Task.Application.Dtos;

namespace Task.Application.Mapper
{
	public class MappingProfile:Profile
	{
        public MappingProfile()
        {
			CreateMap<User, CreateUserCommand>().ReverseMap();
			CreateMap<Address, AddressDto>().ReverseMap();

		}
	}
}
