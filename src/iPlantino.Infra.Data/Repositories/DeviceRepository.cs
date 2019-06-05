using iPlantino.Domain.Core.UnitOfWork;
using iPlantino.Domain.Device.Models;
using iPlantino.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace iPlantino.Infra.Data.Repositories
{
    public class DeviceRepository : Repository<Arduino>, IRepository<Arduino>
    {
        public DeviceRepository(IdentityContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<TResult>> ListAll<TResult>(Expression<Func<Arduino, TResult>> selector)
        {
            return await GetAll(selector).ToListAsync();
        }

        public Task<TResult> Get<TResult>(Expression<Func<Arduino, TResult>> selector, Expression<Func<Arduino, bool>> predicate = null, params string[] includes)
        {
            return GetFirstOrDefaultAsync(selector, predicate, null, false, includes);
        }

        public Task Insert<TResult>(Arduino arduino)
        {
            return InsertAsync(arduino);
        }
    }
}
