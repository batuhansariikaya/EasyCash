using EasyCash.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.Application.Abstractions.Services
{
    public interface IGetUserInfo
    {
        Task<AppUser> LoggedUserInfo(string name);
    }
}
