using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iPlantino.Domain.Commands.Device;
using iPlantino.Domain.Commands.Measurement;
using iPlantino.Domain.Core.Bus;
using iPlantino.Domain.Core.Notifications;
using iPlantino.Domain.Core.UnitOfWork;
using iPlantino.Infra.CrossCutting.Identity.Entities;
using iPlantino.Services.Api.Infrastructure.Filters;
using iPlantino.Services.Api.Models.DeviceModels;
using iPlantino.Services.Api.Models.UserModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iPlantino.Services.Api.Controllers
{
    /// <summary>
    /// Controller for device actions
    /// </summary>
    [Produces("application/json")]
    public class DeviceController : ApiController
    {
        private readonly IRepository<ApplicationArduino> _deviceRepository;
        private readonly IRepository<ApplicationUser> _userRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="notifications"></param>
        public DeviceController(IUnitOfWork unitOfWork, INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _deviceRepository = unitOfWork.GetRepository<ApplicationArduino>();
            _userRepository = unitOfWork.GetRepository<ApplicationUser>();
        }

        /// <summary>
        /// Lists all devices for a user
        /// Roles: [device-user]
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet("api/device/{username}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserDetailsModel), 200)]
        [ProducesResponseType(typeof(IDictionary<string, IEnumerable<string>>), 400)]
        [ProducesResponseType(typeof(JsonErrorResponse), 500)]
        public async Task<IActionResult> Get([FromRoute] string username)
        {
            var user = await _userRepository.GetFirstOrDefaultAsync(
               predicate: x => x.UserName == username,
                disableTracking: true,
                include: "UserArduinos.Arduino");

            var devices = new List<DeviceDetailsModel>();

            foreach (var device in user.UserArduinos)
            {
                devices.Add(new DeviceDetailsModel
                {
                    Id = device.Arduino.Id.ToString(),
                    Name = device.Arduino.Name,
                    Observation = device.Arduino.Observation,
                    MacAddress = device.Arduino.MacAdrress
                });
            }

            var deviceList = new DeviceListModel
            {
                UserId = user.Id.ToString(),
                Username = user.UserName,
                User = user.Name,
                DeviceList = devices
            };

            return Response(deviceList);
        }

        /// <summary>
        /// Lists all measurements for a device
        /// Roles: [device-measurement-details]
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        [HttpGet("api/device/measurement/{deviceId}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserDetailsModel), 200)]
        [ProducesResponseType(typeof(IDictionary<string, IEnumerable<string>>), 400)]
        [ProducesResponseType(typeof(JsonErrorResponse), 500)]
        public async Task<IActionResult> GetAlltMeasurement([FromRoute] string deviceId)
        {
            var arduino = await _deviceRepository.GetFirstOrDefaultAsync(
               predicate: x => x.Id == new Guid( deviceId),
                disableTracking: true,
                include: "ArduinoHumidities.Humidity");

            var measurementList = new List<MeasurementDetailsModel>();

            foreach (var humidity in arduino.ArduinoHumidities.OrderBy(x => x.Humidity.CreatedAt))
            {
                measurementList.Add(new MeasurementDetailsModel
                {
                    Measurement = humidity.Humidity.Measurement
                });
            }

            return Response(new MeasurementListModel { MeasurementList = measurementList, DeviceId = deviceId });
        }

        /// <summary>
        /// Details the last measurement for a device
        /// Roles: [device-measurement-details]
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        [HttpGet("api/device/measurement/{deviceId}/last")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserDetailsModel), 200)]
        [ProducesResponseType(typeof(IDictionary<string, IEnumerable<string>>), 400)]
        [ProducesResponseType(typeof(JsonErrorResponse), 500)]
        public async Task<IActionResult> GetLastMeasurement([FromRoute] string deviceId)
        {
            var arduino = await _deviceRepository.GetFirstOrDefaultAsync(
               predicate: x => x.Id == new Guid(deviceId),
                disableTracking: true,
                include: "ArduinoHumidities.Humidity");

            var lastMeasurement = arduino.ArduinoHumidities.OrderByDescending(x => x.Humidity.CreatedAt).FirstOrDefault().Humidity.Measurement;

            return Response(new MeasurementDetailsModel { Measurement = lastMeasurement });
        }

        /// <summary>
        /// Details a device
        /// Roles: [device-details]
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        [HttpGet("api/device/details/{deviceId}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserDetailsModel), 200)]
        [ProducesResponseType(typeof(IDictionary<string, IEnumerable<string>>), 400)]
        [ProducesResponseType(typeof(JsonErrorResponse), 500)]
        public async Task<IActionResult> DeviceDetails([FromRoute] string deviceId)
        {
            var arduino = await _deviceRepository.GetFirstOrDefaultAsync(
               predicate: x => x.Id == new Guid(deviceId),
                disableTracking: true,
                include: "ArduinoHumidities.Humidity");

            var details = new DeviceDetailsModel
            {
                Id = arduino.Id.ToString(),
                Name = arduino.Name,
                MacAddress = arduino.MacAdrress,
                Observation = arduino.Observation
            };

            return Response(details);
        }

        /// <summary>
        /// Register a measure for a device
        /// Roles: [device-measurement-registration]
        /// </summary>  
        /// <param name="bus"></param>
        /// <param name="registerMeasurementModel"></param>
        /// <returns>Id do Usuário Criado <see cref="UserRegisteredModel"/></returns>
        [HttpPost]
        [Route("api/device/measure")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserRegisteredModel), 201)]
        [ProducesResponseType(typeof(IDictionary<string, IEnumerable<string>>), 400)]
        [ProducesResponseType(typeof(JsonErrorResponse), 500)]
        public async Task<IActionResult> Measure([FromServices]IMediatorHandler bus, [FromBody] RegisterMeasurementModel registerMeasurementModel)
        {
            var command = new RegisterMeasurementCommand(registerMeasurementModel.DeviceId, registerMeasurementModel.Measurement);

            await bus.SendCommand(command);

            return ResponseCreated($"api/device/measurement/{command.DeviceId}", new MeasurementDetailsModel { Measurement = command.Measurement });
        }

        /// <summary>
        /// Register a device for a user
        /// Roles: [device-registration]
        /// </summary>  
        /// <param name="bus"></param>
        /// <param name="addDeviceModel"></param>
        /// <returns>Id do Usuário Criado <see cref="UserRegisteredModel"/></returns>
        [HttpPost]
        [Route("api/device/register")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserRegisteredModel), 201)]
        [ProducesResponseType(typeof(IDictionary<string, IEnumerable<string>>), 400)]
        [ProducesResponseType(typeof(JsonErrorResponse), 500)]
        public async Task<IActionResult> RegisterDevice([FromServices]IMediatorHandler bus, [FromBody] AddDeviceModel addDeviceModel)
        {
            var command = new AddDeviceCommand(addDeviceModel.Name, addDeviceModel.Observation,
                                                         addDeviceModel.MacAddress, addDeviceModel.UserId);
            await bus.SendCommand(command);
            return ResponseCreated($"api/device/{command.Id}", new DeviceDetailsModel
            {
                Id = command.Id.ToString(),
                Name = command.Name,
                MacAddress = command.MacAddress,
                Observation = command.Observation
            });
        }
    }
}