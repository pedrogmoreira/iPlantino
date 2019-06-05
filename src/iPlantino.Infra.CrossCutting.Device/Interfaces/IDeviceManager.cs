using iPlantino.Domain.Device.Models;
using iPlantino.Infra.CrossCutting.Device.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iPlantino.Infra.CrossCutting.Device.Intefaces
{
    public interface IDeviceManager
    {
        Task Insert(Arduino arduino, Guid userId);
        IEnumerable<Arduino> GetAll();
        Task<ArduinoModel> GetById(Guid idDevice);
    }
}
