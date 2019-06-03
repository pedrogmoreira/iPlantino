using iPlantino.Domain.Core.PagedList;
using iPlantino.Infra.CrossCutting.Identity.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace iPlantino.Domain.AggregatesModel.UserAggregate
{
    public interface IUserRepository
    {
        Task<IPagedList<TResult>> GetPagedList<TResult>(Expression<Func<ApplicationUser, TResult>> selector, int pageIndex = 0, int pageSize = 20) where TResult : class;
        Task<TResult> Get<TResult>(Expression<Func<ApplicationUser, TResult>> selector, Expression<Func<ApplicationUser, bool>> predicate = null, params string[] includes);
    }
}