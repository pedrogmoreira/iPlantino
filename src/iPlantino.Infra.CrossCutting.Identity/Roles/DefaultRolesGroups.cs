using System.Collections.Generic;

namespace iPlantino.Infra.CrossCutting.Identity.Roles
{
    public class DefaultRolesGroups
    {
        public static readonly List<string> USER = new List<string>
        {
            Roles.USER
        };

        public static readonly List<string> ADMINISTRATOR = new List<string>
        {
            Roles.ADMINISTRATOR,
            Roles.USER
        };
    }
}
