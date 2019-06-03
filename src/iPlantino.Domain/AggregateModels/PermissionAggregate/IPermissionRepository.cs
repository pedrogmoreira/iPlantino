using iPlantino.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace iPlantino.Domain.AggregatesModel.PermissionAggregate
{
    public interface IPermissionRepository : IAggregateRootReposity<Permission>
    {
        Task<IEnumerable<TResult>> ListAll<TResult>(Expression<Func<Permission, TResult>> selector);
    }
}
