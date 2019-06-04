using System;
using System.Collections.Generic;

namespace iPlantino.Services.Api.V1.Usuarios.Models
{
    public class UserDetailsModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public String PhoneNumber { get; set; }
        public string Login { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public int AccessFailedCount { get; set; }
        public IEnumerable<string> Groups { get; set; }
    }
}
