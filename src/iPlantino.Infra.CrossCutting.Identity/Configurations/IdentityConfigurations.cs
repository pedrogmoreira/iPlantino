using Egl.Sit.Infra.CrossCutting.Identity.Configurations;

namespace iPlantino.Infra.CrossCutting.Identity.Configurations
{
    public static class IdentityConfigurations
    {
        public static string DB_DEFAULT_SCHEMA = "identidade";
        public static string DEFAULT_ROLE_CLAIM_TYPE = iPlantinoRegisteredClaimNames.Permission;
    }
}
