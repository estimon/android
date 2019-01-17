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
    [Activity(Label = "ViewNoteActivity")]
    public class ViewNoteActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            if (Resources.Configuration.Orientation == Android.Content.Res.Orientation.Landscape)
            {
                Finish();
            }


            var ViewId = Intent.Extras.GetInt("current_note_id", 0);

            var detailsFrag = ViewNoteFragment.NewInstance(ViewId);
            FragmentManager.BeginTransaction()
                .Add(Android.Resource.Id.Content, detailsFrag)
                .Commit();
        }

       


    }
}