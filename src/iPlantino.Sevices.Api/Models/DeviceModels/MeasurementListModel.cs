using System.Collections.Generic;

namespace iPlantino.Services.Api.Models.DeviceModels
{
    public class MeasurementListModel
    {
        public string DeviceId { get; set; }
        public ICollection<MeasurementDetailsModel> MeasurementList { get; set; }
    }
}
