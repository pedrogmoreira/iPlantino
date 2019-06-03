using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Egl.Sit.AdministracaoUsuario.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository, IRepository<User>
    {
        public UserRepository(AdministracaoUsuarioContext dbContext) : base(dbContext) { }

        public Task<IPagedList<TResult>> GetPagedList<TResult>(Expression<Func<User, TResult>> selector, int pageIndex = 0, int pageSize = 20) where TResult : class
        {
            return GetPagedListAsync(selector: selector, pageIndex: pageIndex, pageSize: pageSize);
        }

        public Task<TResult> Get<TResult>(Expression<Func<User, TResult>> selector,
                Expression<Func<User, bool>> predicate = null, params string[] includes)
        {
            return GetFirstOrDefaultAsync(selector, predicate, null, true, includes);
        }
    }
}
