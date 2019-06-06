using iPlantino.Domain.Commands.Measurement;
using iPlantino.Domain.Core.Bus;
using iPlantino.Domain.Core.Notifications;
using iPlantino.Domain.Device.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace iPlantino.Domain.CommandHandlers.Measurement
{
    public class RegisterMeasurementCommandHandler : Notifiable, IRequestHandler<RegisterMeasurementCommand>
    {
        private readonly DbContext _context;

        public RegisterMeasurementCommandHandler(DbContext context, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(bus, notifications)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RegisterMeasurementCommand request, CancellationToken cancellationToken)
        {
            var humidity = new Humidity
            {
                Measurement = request.Measurement
            };

            _context.Add(humidity);

            var arduinoHumidity = new ArduinoHumidity
            {
                ArduinoId = request.DeviceId,
                HumidityId = humidity.Id
            };

            _context.Add(arduinoHumidity);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
