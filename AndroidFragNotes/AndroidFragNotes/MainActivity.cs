using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;

namespace AndroidFragNotes
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
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