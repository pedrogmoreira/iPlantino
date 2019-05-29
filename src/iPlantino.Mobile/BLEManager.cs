using System;
using System.Text;

namespace iPlantino.Mobile
{
    public static class BLEManager
    {
        public static async System.Threading.Tasks.Task SendMessageAsync(string message)
        {
            var service = await App.Device.GetServiceAsync(Guid.Parse("0000ffe0-0000-1000-8000-00805f9b34fb"));
            var characteristic = await service.GetCharacteristicAsync(Guid.Parse("0000ffe1-0000-1000-8000-00805f9b34fb"));
            await characteristic.WriteAsync(Encoding.UTF8.GetBytes(message));
        }

        public static bool connectedToDevice()
        {
            return Plugin.BLE.CrossBluetoothLE.Current.IsAvailable;
        }
    }
}
