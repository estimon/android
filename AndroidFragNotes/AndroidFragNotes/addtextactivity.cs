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

namespace AndroidFragNotes
{
    [Activity(Label = "addtextactivity")]
    public class addtextactivity : Activity
    {
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.edittext);
            base.OnCreate(savedInstanceState);

            var addbtn = FindViewById<Button>(Resource.Id.button1);
            addbtn.Click += Button_Click;


            
        }

        void Button_Click(object sender, EventArgs e)
        {
            var Database = new Notes();
            Database.CreateDataBase();

            var addHeading = FindViewById<EditText>(Resource.Id.textInputEditText1);
            var addContent = FindViewById<EditText>(Resource.Id.textInputEditText2);
            var table = Database.GetAllNotes();

            var heading = addHeading.Text;
            var content = addContent.Text;
            Database.AddNewNoteHeading(heading);
            Database.AddNewNoteContenxt(content);

            StartActivity(typeof(MainActivity));
        }
    }
}