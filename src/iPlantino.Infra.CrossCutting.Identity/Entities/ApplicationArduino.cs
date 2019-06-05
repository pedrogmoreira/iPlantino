using iPlantino.Domain.Device.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace iPlantino.Infra.CrossCutting.Identity.Entities
{
    public class ApplicationArduino : Arduino
    {
        public ApplicationUserArduino UserArduino { get; set; }
    }
}
