using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using iPlantino.Domain.AggregatesModel.RoleAggregate;
using iPlantino.Domain.Core.PagedList;
using iPlantino.Domain.Core.UnitOfWork;
using iPlantino.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace iPlantino.Infra.Data.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository, IRepository<Role>
    {
        public RoleRepository(IdentityContext dbContext) : base(dbContext) { }

        public Task<TResult> Get<TResult>(Expression<Func<Role, TResult>> selector, Expression<Func<Role, bool>> predicate = null, params string[] includes)
        {
            return GetFirstOrDefaultAsync(selector, predicate, null, false, includes);
        }

        public Task<IPagedList<TResult>> GetPagedList<TResult>(Expression<Func<Role, TResult>> selector, int pageIndex = 0, int pageSize = 20) where TResult : class
        {
            return GetPagedListAsync(selector: selector, pageIndex: pageIndex, pageSize: pageSize);
        }
    }
}
