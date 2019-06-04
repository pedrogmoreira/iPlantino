using iPlantino.Domain.Core.PagedList;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace iPlantino.Domain.AggregatesModel.UserAggregate
{
    public interface IUserRepository
    {
        Task<IPagedList<TResult>> GetPagedList<TResult>(Expression<Func<User, TResult>> selector, int pageIndex = 0, int pageSize = 20) where TResult : class;
        Task<TResult> Get<TResult>(Expression<Func<User, TResult>> selector, Expression<Func<User, bool>> predicate = null, params string[] includes);
    }
}