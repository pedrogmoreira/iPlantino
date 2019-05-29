using iPlantino.Domain.Models.Authentication;
using Microsoft.EntityFrameworkCore;

namespace iPlantino.Authentication.Repository
{
    public interface IAuthenticationRepository : IRepository<User>
    {
    }
}