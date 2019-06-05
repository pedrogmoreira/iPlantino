using iPlantino.Domain.Core.Models;
using System.Collections.Generic;

namespace iPlantino.Domain.Device.Models
{
    public class Humidity : Entity
    {
        public double Measurement { get; set; }

        public ICollection<ArduinoHumidity> ArduinoHumidities { get; set; }
    }
}
