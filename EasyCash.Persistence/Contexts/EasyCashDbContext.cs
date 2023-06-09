using EasyCash.Domain.Entities;
using EasyCash.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.Persistence.Contexts
{
    public class EasyCashDbContext:IdentityDbContext
    {
        public EasyCashDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<CustomerAccountProcess> CustomerAccountProcesses { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        { 
            //ChangeTracker : Entityler üzerinden yapılan değişiklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir. Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar.

            var datas = ChangeTracker
                 .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now,
                    _ => DateTime.UtcNow
                };
            }

           return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
