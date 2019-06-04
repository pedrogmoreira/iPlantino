using iPlantino.Domain.Core.UnitOfWork;
using iPlantino.Infra.CrossCutting.Identity.Entities;

namespace iPlantino.Authentication.Repository
{
    public interface IAuthenticationRepository : IRepository<ApplicationUser>
    {
    }
}