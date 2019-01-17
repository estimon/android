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

            var Database = new Notes();
            Database.CreateDataBase();
            Database.CreateTable();
            

            var addHeading = FindViewById<EditText>(Resource.Id.textInputEditText1);
            var addContent = FindViewById<EditText>(Resource.Id.textInputEditText2);
            var addbtn = FindViewById<Button>(Resource.Id.button1);
            var table = Database.GetAllNotes();


            addbtn.Click += delegate
            {
                var heading = addHeading.Text;
                var content = addContent.Text;
                Database.AddNewNote(heading);
                Database.AddNewNote(content);
            };
        }
    }
}