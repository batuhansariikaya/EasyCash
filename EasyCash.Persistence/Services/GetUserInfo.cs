using EasyCash.Application.Abstractions.Services;
using EasyCash.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.Persistence.Services
{
    public class GetUserInfo : IGetUserInfo
    {
        UserManager<AppUser> _userManager;

        public GetUserInfo(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AppUser> LoggedUserInfo(string name)
        {
            AppUser user=await _userManager.FindByNameAsync(name);
            return user;
        }
    }
}
