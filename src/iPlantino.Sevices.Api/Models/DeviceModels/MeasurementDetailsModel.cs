namespace iPlantino.Services.Api.Models.DeviceModels
{
    public class MeasurementDetailsModel
    {
        private readonly double SOIL_HUMIDITY_TRESSHOLD = 250.0;

        public double Measurement { get; set; }
        public string Message
        {
            get
            {
                if (Measurement > SOIL_HUMIDITY_TRESSHOLD)
                {
                    return "The soil is moist, there is no need to wet.";
                }

                return "The soil is dry, you need to wet immediately.";
            }
        }
    }
}
