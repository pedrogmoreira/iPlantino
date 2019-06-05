using iPlantino.Domain.Commands.Device;
using iPlantino.Domain.Core.Bus;
using iPlantino.Domain.Core.Notifications;
using iPlantino.Domain.Core.UnitOfWork;
using iPlantino.Domain.Device.Models;
using iPlantino.Infra.CrossCutting.Identity.Entities;
using iPlantino.Infra.CrossCutting.Identity.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iPlantino.Domain.CommandHandlers.Device
{
    public class AddDeviceCommandHandler : Notifiable, IRequestHandler<AddDeviceCommand>
    {
        private readonly IUserManager _userManager;
        private readonly DbContext _context;

        public AddDeviceCommandHandler(IUserManager userManager, DbContext context, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(bus, notifications)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<Unit> Handle(AddDeviceCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetById(request.UserId);

            var arduino = new ApplicationArduino
            {
                Name = request.Name,
                Observation = request.Observation,
                MacAdrress = request.MacAddress
            };

            arduino.SetId(request.Id);

            _context.Add(arduino);

            var userArduino = new ApplicationUserArduino
            {
                UserId = user.Id,
                ArduinoId = arduino.Id
            };

            await _context.SaveChangesAsync();

            if (user.UserArduinos == null)
            {
                user.UserArduinos = new List<ApplicationUserArduino>();
            }

            user.UserArduinos.Add(
                userArduino
            );

            await _userManager.Update(user);

            return Unit.Value;
        }
    }
}
