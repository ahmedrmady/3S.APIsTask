using _3S.Task.Application.Dtos;
using _3S.Task.Application;
using AutoMapper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Features;

namespace Task.Application.Mapper
{
	public class MappingProfile:Profile
	{
        public MappingProfile()
        {
			CreateMap<User, CreateUserCommand>().ReverseMap();

		}
	}
}
