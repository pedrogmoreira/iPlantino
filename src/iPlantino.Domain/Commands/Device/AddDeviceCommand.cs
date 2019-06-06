using MediatR;
using System;

namespace iPlantino.Domain.Commands.Device
{
    public class AddDeviceCommand: DeviceCommand, IRequest
    {
        public AddDeviceCommand(string name, string observation, string macAddress, string userId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Observation = observation;
            MacAddress = macAddress;
            UserId = new Guid(userId);
        }
    }
}
