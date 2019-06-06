using System.Collections.Generic;

namespace iPlantino.Services.Api.Models.DeviceModels
{
    public class DeviceListModel
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string User { get; set; }
        public ICollection<DeviceDetailsModel> DeviceList { get; set; }
    }
}
