﻿using EasyCash.Application.Repositories;
using EasyCash.Domain.Entities;
using EasyCash.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.Persistence.Repositories
{
    public class CustomerAccountReadRepository : ReadRepository<CustomerAccount>, ICustomerAccountReadRepository
    {
        public CustomerAccountReadRepository(EasyCashDbContext context) : base(context)
        {
        }
    }
}
