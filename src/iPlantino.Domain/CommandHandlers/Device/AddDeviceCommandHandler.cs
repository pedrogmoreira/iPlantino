using iPlantino.Domain.Commands.Device;
using iPlantino.Domain.Commands.Registration;
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
        private readonly IRepository<Arduino> _deviceRepository;

        public AddDeviceCommandHandler(IUserManager userManager, IRepository<Arduino> deviceRepository, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(bus, notifications)
        {
            _userManager = userManager;
            _deviceRepository = deviceRepository;
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

            await _deviceRepository.InsertAsync(arduino);

            user.UserArduinos.Add(
                new ApplicationUserArduino
                {
                    User = user,
                    Arduino = arduino
                }
            );

            await _userManager.Update(user);

            return Unit.Value;
        }
    }
}
