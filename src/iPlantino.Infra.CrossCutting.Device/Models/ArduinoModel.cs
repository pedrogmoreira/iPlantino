using iPlantino.Infra.CrossCutting.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace iPlantino.Infra.CrossCutting.Device.Models
{
    public class ArduinoModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Observation { get; set; }
        public string MacAddress { get; set; }
    }
}
