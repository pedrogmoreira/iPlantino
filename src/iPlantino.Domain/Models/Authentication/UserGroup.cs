using System;

namespace iPlantino.Domain.Models.Authentication
{
    public class UserGroup
    {
        //EF Core
        protected UserGroup()
        {
        }

        public UserGroup(Guid idUser, Guid idGroup)
        {
            IdGroup = idGroup;
            IdUser = idUser;
        }

        public Guid IdGroup { get; set; }
        public Guid IdUser { get; set; }
        public Group Group { get; set; }
        public User User { get; set; }
    }

}
