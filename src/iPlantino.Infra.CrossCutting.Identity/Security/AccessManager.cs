using iPlantino.Infra.CrossCutting.Identity.Entities;
using iPlantino.Infra.CrossCutting.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace iPlantino.Infra.CrossCutting.Identity.Security
{
    public class AccessManager : IAcessManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccessManager(
                UserManager<ApplicationUser> userManager,
                SignInManager<ApplicationUser> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ApplicationUser> GetUserByUsername(string username)
        {
            return await _userManager
                .Users
                .Include("UserRoles.Role.RoleClaims")
                .FirstOrDefaultAsync(x => x.UserName == username);
            // return _userManager.FindByNameAsync(username);
        }

        public Task<SignInResult> ValidateCredentials(ApplicationUser user, string password)
        {
            return _signInManager.CheckPasswordSignInAsync(user, password, true);
        }
    }
}