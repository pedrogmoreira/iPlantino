using iPlantino.Domain.Core.Aggregate;
using iPlantino.Domain.Core.Models;

namespace iPlantino.Domain.AggregatesModel.PermissionAggregate
{
    public class Permission : Enumeration, IAggregateRoot
    {
        public Permission(int id, string name) : base(id, name) { }

        public string Title { get; protected set; }
        public string Description { get; protected set; }
    }
}
