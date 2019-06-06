using iPlantino.Domain.Device.Models;

namespace iPlantino.Infra.CrossCutting.Identity.Entities
{
    public class ApplicationArduino : Arduino
    {
        public ApplicationUserArduino UserArduino { get; set; }
    }
}
