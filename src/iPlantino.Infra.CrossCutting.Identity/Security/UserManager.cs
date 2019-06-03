using iPlantino.Infra.CrossCutting.Identity.Entities;
using iPlantino.Infra.CrossCutting.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace iPlantino.Infra.CrossCutting.Identity.Security
{
    public class UserManager : IUserManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserPasswordStore<ApplicationUser> userPasswordStore;

        public UserManager(UserManager<ApplicationUser> userManager)
        {
            
            _userManager = userManager;
        }

        public Task<IdentityResult> CreateUser(ApplicationUser user, string password)
        {
            return _userManager.CreateAsync(user, password);
        }

        public Task<IdentityResult> ChangePassword(ApplicationUser user, string password)
        {
            var hash = _userManager.PasswordHasher.HashPassword(user,password);
            user.PasswordHash = hash;
            return Update(user);
        }

        public Task<IdentityResult> AddToRoles(ApplicationUser user, IEnumerable<string> roles)
        {
            return _userManager.AddToRolesAsync(user, roles);
        }

        public Task<IdentityResult> Update(ApplicationUser user)
        {
            return _userManager.UpdateAsync(user);
        }

        public Task<ApplicationUser> GetById(Guid idUser)
        {

            return _userManager.FindByIdAsync(idUser.ToString());
        }

        public Task<IdentityResult> RemoveRoles(ApplicationUser user, IEnumerable<string> roles)
        {
            return _userManager.RemoveFromRolesAsync(user, roles);
        }

        public Task<IList<string>> GetRoles(ApplicationUser user)
        {
            return _userManager.GetRolesAsync(user);
        }
    }
}
