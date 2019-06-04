using iPlantino.Infra.CrossCutting.Identity.Entities;
using iPlantino.Infra.CrossCutting.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace iPlantino.Infra.CrossCutting.Identity.Security
{
    public class RoleManager : IRoleManager
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleManager(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public Task<IdentityResult> CreateRole(ApplicationRole applicationRole)
        {
            return _roleManager.CreateAsync(applicationRole);
        }

        public Task<IdentityResult> AddClaim(ApplicationRole applicationRole, Claim claim)
        {
            return _roleManager.AddClaimAsync(applicationRole, claim);
        }

        public Task<ApplicationRole> GetById(Guid id)
        {
            return _roleManager.FindByIdAsync(id.ToString());
        }

        public Task<IdentityResult> Update(ApplicationRole applicationRole)
        {
            return _roleManager.UpdateAsync(applicationRole);
        }

        public async Task ClearAllClaims(ApplicationRole applicationRole)
        {
            var claims = await _roleManager.GetClaimsAsync(applicationRole);

            foreach (var claim in claims)
            {
                await _roleManager.RemoveClaimAsync(applicationRole, claim);
            }
        }
    }
}
