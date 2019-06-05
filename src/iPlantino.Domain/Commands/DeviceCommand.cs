using System;
using System.Collections.Generic;
using System.Text;

namespace iPlantino.Domain.Commands
{
    public class DeviceCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Observation { get; set; }
        public string MacAddress { get; set; }
        public Guid UserId { get; set; }
    }
}
