using System;

namespace iPlantino.Domain.Device.Models
{
    public class ArduinoHumidity
    {
        public Arduino Arduino { get; set; }
        public Humidity Humidity { get; set; }

        public virtual Guid ArduinoId { get; set; }
        public virtual Guid HumidityId { get; set; }
    }
}
