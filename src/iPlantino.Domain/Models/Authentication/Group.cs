using iPlantino.Domain.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace iPlantino.Domain.Models.Authentication
{
    public class Group : Entity
    {
        public Group(string name, string observation)
        {
            Name = name;
            Observation = observation;
            PermissionsGroup = new HashSet<PermissionGroup>();
            UsersGroup = new HashSet<UserGroup>();
        }

        protected Group()
        {
        }

        public string Name { get; private set; }
        public string Observation { get; private set; }

        public IEnumerable<PermissionGroup> PermissionsGroup { get; set; }
        public IEnumerable<UserGroup> UsersGroup { get; set; }

        public IEnumerable<string> Permissions
        {
            get
            {
                return PermissionsGroup
                   ?.Select(x => x.Permission)
                   ?.Select(x => x.Name)
                   ?.Distinct();
            }
        }

        public void EditGroup(string observation)
        {
            Observation = observation;
        }

        public void AddPermissoes(IEnumerable<PermissionGroup> permissionsGroup)
        {
            PermissionsGroup = permissionsGroup;
        }
    }

}
