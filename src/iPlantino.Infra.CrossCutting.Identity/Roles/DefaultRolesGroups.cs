using System;
using System.Collections.Generic;
using System.Text;

namespace iPlantino.Infra.CrossCutting.Identity.Roles
{
    public class DefaultRolesGroups
    {
        public static readonly List<string> USER = new List<string>
        {
            Roles.USER,
            Roles.USER_DEVICE
        };

        public static readonly List<string> ADMINISTRATOR = new List<string>
        {
            Roles.ADMINISTRATOR,
            Roles.USER
        };
    }
}
