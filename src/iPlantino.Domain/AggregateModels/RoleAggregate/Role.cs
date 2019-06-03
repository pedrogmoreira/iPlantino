using iPlantino.Domain.Core.Aggregate;
using iPlantino.Domain.AggregatesModel.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iPlantino.Domain.AggregatesModel.RoleAggregate
{
    public class Role : IAggregateRoot
    {
        public Role()
        {
            //RoleClaims = new HashSet<RoleClaims>();
            //UserRole = new HashSet<UserRole>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<string> Permissions { get { return RoleClaims?.Select(s => s.ClaimValue); } }
        public virtual ICollection<RoleClaims> RoleClaims { get; protected set; }
        public virtual ICollection<UserRole> UserRole { get; protected set; }
    }
}
