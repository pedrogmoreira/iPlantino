using iPlantino.Domain.Core.Models;
using System.Collections.Generic;

namespace iPlantino.Domain.Models.Authentication
{
    public class Permission : Entity
    {
        public Permission(string name)
        {
            Name = name;
        }

        //EF
        protected Permission() { }

        public string Name { get; private set; }

        public ICollection<PermissionGroup> PermissionGroup { get; set; }
    }

}
