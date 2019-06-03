using iPlantino.Infra.CrossCutting.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace iPlantino.Infra.CrossCutting.Identity.Interfaces
{
    public interface IAcessManager
    {
        Task<ApplicationUser> GetUserByUsername(string username);
        Task<SignInResult> ValidateCredentials(ApplicationUser user, string password);
    }
}