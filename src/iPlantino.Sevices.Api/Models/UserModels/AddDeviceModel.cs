using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iPlantino.Services.Api.Models.UserModels
{
    public class AddDeviceModel
    {
        public string Name { get; set; }
        public string Observation { get; set; }
        public string MacAddress { get; set; }
        public string UserId { get; set; }
    }
}
