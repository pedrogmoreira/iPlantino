using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using iPlantino.Infra.Data.Context;
using iPlantino.Domain.Core.PagedList;
using iPlantino.Domain.Core.UnitOfWork;
using iPlantino.Domain.AggregatesModel.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace iPlantino.Infra.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository, IRepository<User>
    {
        public UserRepository(IdentityContext dbContext) : base(dbContext) { }

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
