using iPlantino.Domain.Device.Models;
using iPlantino.Infra.CrossCutting.Device.Intefaces;
using iPlantino.Infra.CrossCutting.Device.Models;
using iPlantino.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace iPlantino.Infra.CrossCutting.Device.Security
{
    public class DeviceManager : IDeviceManager
    {
        private readonly DeviceRepository _deviceRepository;

        public DeviceManager(DeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public IEnumerable<Arduino> GetAll()
        {
            return _deviceRepository.GetAll();
        }

        public async Task<ArduinoModel> GetById(Guid idDevice)
        {

            Expression<Func<Arduino, bool>> predicate = p => p.Id == idDevice;

            Expression<Func<Arduino, ArduinoModel>> selector = arduino => new ArduinoModel
            {
                Id = arduino.Id,
                Name = arduino.Name,
                Observation = arduino.Observation,
                MacAddress = arduino.MacAdrress
            };

            return await _deviceRepository.Get(selector, predicate);
        }

        public Task Insert(Arduino arduino, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
