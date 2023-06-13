﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.Application.DTOs
{
    public class UserEditDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string ImageUrl { get; set; }
        public string Password { get; set; }
    }
}