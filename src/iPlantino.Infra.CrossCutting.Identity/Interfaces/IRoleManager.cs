using iPlantino.Infra.CrossCutting.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace iPlantino.Infra.CrossCutting.Identity.Interfaces
{
    public interface IRoleManager
    {
        Task<IdentityResult> CreateRole(ApplicationRole applicationRole);
        Task<IdentityResult> AddClaim(ApplicationRole applicationRole, Claim claim);
        Task<ApplicationRole> GetById(Guid id);
        Task<IdentityResult> Update(ApplicationRole applicationRole);
        Task ClearAllClaims(ApplicationRole applicationRole);
    }
}
