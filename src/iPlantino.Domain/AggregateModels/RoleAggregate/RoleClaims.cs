using System;

namespace iPlantino.Domain.AggregatesModel.RoleAggregate
{
    public class RoleClaims
    {
        public int Id { get; set; }
        public Guid RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public virtual Role Role { get; set; }
    }
}
