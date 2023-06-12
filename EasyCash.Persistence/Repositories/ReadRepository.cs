﻿using EasyCash.Application.Repositories;
using EasyCash.Domain.Entities.Common;
using EasyCash.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        readonly private EasyCashDbContext _context;

        public ReadRepository(EasyCashDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        => Table;

        public async Task<T> GetByIdAsync(int id, bool tracking = true)
        {
           return await Table.FirstOrDefaultAsync(x=>x.Id== id);

        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
           return await Table.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            return Table.Where(method);
        }
    }
}
