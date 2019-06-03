using iPlantino.Domain.Core.PagedList;
using iPlantino.Domain.SeedWork;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace iPlantino.Domain.AggregatesModel.RoleAggregate
{
    public interface IRoleRepository : IAggregateRootReposity<Role>
    {
        Task<IPagedList<TResult>> GetPagedList<TResult>(Expression<Func<Role, TResult>> selector,
            int pageIndex = 0, int pageSize = 20) where TResult : class;

        Task<TResult> Get<TResult>(Expression<Func<Role, TResult>> selector, Expression<Func<Role, bool>> predicate = null, params string[] includes);
    }
}
