﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.Domain.Entities.Identity
{
    public class AppUser:IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public int ConfirmCode { get; set; }
        ICollection<CustomerAccount> CustomerAccounts { get; set; }
    }
}
// bir kullanıcının birden fazla hesabı olabilir.
// 