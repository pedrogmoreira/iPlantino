using System;

namespace iPlantino.Domain.Commands
{
    public class MeasurementCommand
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public double Measurement { get; set; }
    }
}
