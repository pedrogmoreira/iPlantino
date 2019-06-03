using iPlantino.Infra.CrossCutting.Identity.Entities;
using Microsoft.EntityFrameworkCore;

namespace iPlantino.Authentication.Repository
{
    public interface IAuthenticationRepository : IRepository<ApplicationUser>
    {
    }
}