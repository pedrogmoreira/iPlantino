using System;

namespace iPlantino.Domain.Models.Authentication
{
    public class PermissionGroup
    {
        protected PermissionGroup()
        {
        }

        public PermissionGroup(Guid idPermission, Guid idGroup)
        {
            IdPermission = idPermission;
            IdGroup = idGroup;
        }

        public Guid IdPermission { get; set; }
        public Guid IdGroup { get; set; }
        public Group Group { get; set; }
        public Permission Permission { get; set; }
    }

}
