using AutoMapper;
using EasyCash.Application.DTOs;
using EasyCash.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.Application.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser,UserRegisterDTO>().ReverseMap();
        }
    }
}
