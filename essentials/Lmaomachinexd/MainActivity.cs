using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Xamarin.Essentials;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Lmaomachinexd
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            #region battery
            var level = Battery.ChargeLevel;
            FindViewById<TextView>(Resource.Id.textView1).Text = level.ToString();

            var state = Battery.State;
            FindViewById<TextView>(Resource.Id.textView2).Text = state.ToString();


            switch (state)
            {
                case BatteryState.Charging:
                    // Currently charging
                    break;
                case BatteryState.Full:
                    // Battery is full
                    break;
                case BatteryState.Discharging:
                case BatteryState.NotCharging:
                    // Currently discharging battery or not being charged
                    break;
                case BatteryState.NotPresent:
                // Battery doesn't exist in device (desktop computer)
                case BatteryState.Unknown:
                    // Unable to detect battery state
                    break;
            }

            var source = Battery.PowerSource;
            FindViewById<TextView>(Resource.Id.textView3).Text = source.ToString();
            switch (source)
            {
                case BatteryPowerSource.Battery:
                    // Being powered by the battery
                    break;
                case BatteryPowerSource.AC:
                    // Being powered by A/C unit
                    break;
                case BatteryPowerSource.Usb:
                    // Being powered by USB cable
                    break;
                case BatteryPowerSource.Wireless:
                    // Powered via wireless charging
                    break;
                case BatteryPowerSource.Unknown:
                    // Unable to detect power source
                    break;
            }
            #endregion battery

            #region DisplayInfo

            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            FindViewById<TextView>(Resource.Id.textView4).Text = mainDisplayInfo.Height.ToString();
            FindViewById<TextView>(Resource.Id.textView5).Text = mainDisplayInfo.Width.ToString();
            FindViewById<TextView>(Resource.Id.textView6).Text = mainDisplayInfo.Rotation.ToString();

            #endregion

            #region convert
            var celcius = UnitConverters.FahrenheitToCelsius(32.0);

            #endregion





        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
       



    }

}