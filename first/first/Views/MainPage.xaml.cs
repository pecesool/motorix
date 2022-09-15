using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using first.data;
using SQLite;
using first.models;
using Plugin.BluetoothClassic.Abstractions;

namespace first.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly IBluetoothAdapter _bluetoothAdapter;
        public MainPage()
        {
            _bluetoothAdapter = DependencyService.Resolve<IBluetoothAdapter>();
            InitializeComponent();                             
        }

        private void RefreshUI()
        {
            if (_bluetoothAdapter.Enabled)
            {
                btnDisableBluetooth.IsEnabled = true;
                btnEnableBluetooth.IsEnabled = false;
                lvBluetoothBoundedDevices.ItemsSource = _bluetoothAdapter.BondedDevices;
            }
            else
            {
                btnDisableBluetooth.IsEnabled = false;
                btnEnableBluetooth.IsEnabled = true;
                lvBluetoothBoundedDevices.ItemsSource = null;
            }
        }


        protected override async void OnAppearing()
        {
            RefreshUI();
            await DisconnectIfConnectedAsync();
            firstconn.Clicked += Firstconn_Clicked;
            btnDisableBluetooth.Clicked += BtnDisableBluetooth_Clicked;
            btnEnableBluetooth.Clicked += BtnEnableBluetooth_Clicked;
            lvBluetoothBoundedDevices.ItemSelected += LvBluetoothBoundedDevices_ItemSelected;
        }

        private async void LvBluetoothBoundedDevices_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            BluetoothDeviceModel bluetoothDeviceModel = e.SelectedItem as BluetoothDeviceModel;
            lvBluetoothBoundedDevices.SelectedItem = null;

            if (bluetoothDeviceModel != null)
            {
                var connected = await TryConnect(bluetoothDeviceModel);
                if (connected)
                {
                    await Navigation.PushAsync(new DigitPage());
                }
            }
        }

        private async Task<bool> TryConnect(BluetoothDeviceModel bluetoothDeviceModel)
        {
            const bool Connected = true;
            const bool NotConnected = false;


            var connection = _bluetoothAdapter.CreateManagedConnection(bluetoothDeviceModel);
            try
            {
                connection.Connect();
                App.CurrentBluetoothConnection = connection;

                return Connected;
            }
            catch (BluetoothConnectionException exception)
            {
                await DisplayAlert("Connection error",
                    $"Can not connect to the device: {bluetoothDeviceModel.Name}({bluetoothDeviceModel.Address}).\n" +
                        $"Exception: \"{exception.Message}\"\n" +
                        "Please, try another one.",
                    "Close");

                return NotConnected;
            }
            catch (Exception exception)
            {
                await DisplayAlert("Generic error", exception.Message, "Close");

                return NotConnected;
            }
        }

        private async Task DisconnectIfConnectedAsync()
        {
            if (App.CurrentBluetoothConnection != null)
            {
                try
                {
                    App.CurrentBluetoothConnection.Dispose();
                }
                catch (Exception exception)
                {
                    await DisplayAlert("Error", exception.Message, "Close");
                }
            }
        }

        private void BtnEnableBluetooth_Clicked(object sender, EventArgs e)
        {
            _bluetoothAdapter.Enable();
            RefreshUI();
        }

        private void BtnDisableBluetooth_Clicked(object sender, EventArgs e)
        {
            _bluetoothAdapter.Disable();
            RefreshUI();
        }

        private void Firstconn_Clicked(object sender, EventArgs e)
        {
            con.IsVisible = false;
            conn.IsVisible = true;
        }
        
    }
}
