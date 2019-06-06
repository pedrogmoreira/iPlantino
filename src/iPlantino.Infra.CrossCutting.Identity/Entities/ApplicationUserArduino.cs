using System;

namespace iPlantino.Infra.CrossCutting.Identity.Entities
{
    public class ApplicationUserArduino
    {
        public virtual int Id { get; set; }
        public ApplicationUser User { get; set; }
        public Guid UserId { get; set; }
        public ApplicationArduino Arduino { get; set; }
        public Guid ArduinoId { get; set; }

    }
}
