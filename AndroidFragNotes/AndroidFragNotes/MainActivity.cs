using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;
using System.IO;
using System.Collections.Generic;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;


namespace AndroidFragNotes
{
    [Activity(Label = "Note 2000", Icon = "@drawable/splash")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            AppCenter.Start("6ee3a54a-14ec-41c6-8961-2fdfb73d4dba",
                   typeof(Analytics), typeof(Crashes));
            AppCenter.Start("6ee3a54a-14ec-41c6-8961-2fdfb73d4dba", typeof(Distribute));
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Notes notes = new Notes();

           
            notes.SampleData();
            

            var firstbtn = FindViewById<Button>(Resource.Id.buttonfromhell);
            firstbtn.Click += Button_Click;
           
        }


        private void Button_Click(object sender, EventArgs e)
        {
            var newact = new Intent(this, typeof(addtextactivity));
            StartActivity(newact);
        }

       
    }
}