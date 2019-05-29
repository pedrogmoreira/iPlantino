using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.Exceptions;
using Xamarin.Forms;

namespace iPlantino.Mobile
{
    public partial class BLEListPage : ContentPage
    {
        private IAdapter adapter;
        private IBluetoothLE bluetoothBLE;
        private ObservableCollection<IDevice> list;

        public BLEListPage()
        {
            InitializeComponent();

            bluetoothBLE = CrossBluetoothLE.Current;
            adapter = CrossBluetoothLE.Current.Adapter;
            list = new ObservableCollection<IDevice>();
            DevicesList.ItemsSource = list;
            App.Device = null;
        }

        private async void SearchDevice(object sender, EventArgs e)
        {
            if (bluetoothBLE.State == BluetoothState.Off)
            {
                await DisplayAlert("Atenção", "Bluetooth desabilitado.", "OK");
            }
            else
            {
                list.Clear();
                adapter.ScanTimeout = 10000;
                adapter.ScanMode = ScanMode.Balanced;
                adapter.DeviceDiscovered += (obj, a) =>
                {
                    if (!list.Contains(a.Device))
                        list.Add(a.Device);
                };
                await adapter.StartScanningForDevicesAsync();
            }
        }

        private async void DevicesList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            App.Device = DevicesList.SelectedItem as IDevice;
            var result = await DisplayAlert("AVISO", "Deseja se conectar a esse dispositivo?", "Conectar", "Cancelar");
            if (!result)
                return;
            //Stop Scanner
            await adapter.StopScanningForDevicesAsync();
            try
            {
                await adapter.ConnectToDeviceAsync(App.Device);
                await DisplayAlert("Conectado", "Status:" + App.Device.State, "OK");
                System.Console.WriteLine("Connectado: " + BLEManager.connectedToDevice().ToString());
                await BLEManager.SendMessageAsync("Hello from Xamarin!!!");
            }
            catch (DeviceConnectionException ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}
