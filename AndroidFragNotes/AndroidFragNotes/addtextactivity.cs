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
       
        Notes note = new Notes();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.edittext);
            base.OnCreate(savedInstanceState);
            note.CreateDataBase();

            var addbtn = FindViewById<Button>(Resource.Id.button1);
            addbtn.Click += Button_Click;


            
        }

        void Button_Click(object sender, EventArgs e)
        {

            NoteThings fck = new NoteThings();

            var fuck = FindViewById<EditText>(Resource.Id.textInputEditText1);
            var palun = FindViewById<EditText>(Resource.Id.textInputEditText2);

            fck.Noteheading = fuck.Text;
            fck.Notetext = palun.Text;
            
            note.Addnote(fck.Noteheading, fck.Notetext);
            

            
            StartActivity(typeof(MainActivity));
        }
    }
}