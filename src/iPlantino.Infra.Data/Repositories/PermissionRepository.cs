using iPlantino.Domain.AggregatesModel.PermissionAggregate;
using iPlantino.Domain.Core.UnitOfWork;
using iPlantino.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace iPlantino.Infra.Data.Repositories
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository, IRepository<Permission>
    {
        public PermissionRepository(IdentityContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<TResult>> ListAll<TResult>(Expression<Func<Permission, TResult>> selector)
        {
             return await GetAll(selector).ToListAsync();
        }
    }
}
