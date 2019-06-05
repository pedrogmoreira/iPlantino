
using iPlantino.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace iPlantino.Domain.Device.Models
{
    public class Arduino : Entity
    {
        public Arduino()
        {

        }
        public string Name { get; set; }
        public string Observation { get; set; }
        public string MacAdrress { get; set; }

        public void SetId(Guid id)
        {
            Id = id;
        }

        public ICollection<ArduinoHumidity> ArduinoHumidities { get; set; }
    }
}
