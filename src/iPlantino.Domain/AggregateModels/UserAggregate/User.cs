using iPlantino.Domain.Core.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iPlantino.Domain.AggregatesModel.UserAggregate
{
    public class User : IAggregateRoot
    {
        protected User()
        {
            //UserClaim = new HashSet<UserClaim>();
            //UserRole = new HashSet<UserRole>();
        }

        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string UserName { get; protected set; }
        public string Email { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public DateTime? LockoutEnd { get; protected set; }
        public int AccessFailedCount { get; protected set; }
        public virtual ICollection<UserClaim> UserClaim { get; protected set; }
        public virtual ICollection<UserRole> UserRole { get; protected set; }
    }
}