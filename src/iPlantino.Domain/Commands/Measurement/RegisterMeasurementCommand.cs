using MediatR;
using System;

namespace iPlantino.Domain.Commands.Measurement
{
    public class RegisterMeasurementCommand : MeasurementCommand, IRequest
    {
        public RegisterMeasurementCommand(string deviceId, double measurement)
        {
            Id = Guid.NewGuid();
            DeviceId = new Guid(deviceId);
            Measurement = measurement;
        }
    }
}
