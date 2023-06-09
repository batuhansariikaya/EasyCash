using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.Domain.Entities.Identity
{
    public class AppRole:IdentityRole<int>
    {
    }
}
// bir kullanıcının birden fazla hesabı olabilir.
