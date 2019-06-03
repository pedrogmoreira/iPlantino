using iPlantino.Infra.CrossCutting.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iPlantino.Infra.CrossCutting.Identity.Interfaces
{
    public interface IUserManager
    {
        Task<IdentityResult> CreateUser(ApplicationUser user, string password);
        Task<IdentityResult> ChangePassword(ApplicationUser user, string password);
        Task<IdentityResult> AddToRoles(ApplicationUser user, IEnumerable<string> roles);
        Task<ApplicationUser> GetById(Guid idUser);
        Task<IdentityResult> Update(ApplicationUser user);
        Task<IdentityResult> RemoveRoles(ApplicationUser user, IEnumerable<string> roles);
        Task<IList<string>> GetRoles(ApplicationUser user);
    }
}
