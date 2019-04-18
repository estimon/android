using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

namespace Lmaomachinexd
{
    public class batteryinfo
    {

        public batteryinfo()
        {
            // Register for battery changes, be sure to unsubscribe when needed
            Battery.BatteryInfoChanged += Battery_BatteryInfoChanged;
        }

        public void Battery_BatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
            var level = e.ChargeLevel;
            var state = e.State;
            var source = e.PowerSource;
            Console.WriteLine($"Reading: Level: {level}, State: {state}, Source: {source}");
        }
    }
}