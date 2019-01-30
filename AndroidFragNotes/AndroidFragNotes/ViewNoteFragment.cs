using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace AndroidFragNotes
{
    public class ViewNoteFragment : Fragment 
    {

       // public static int StatViewId { get; set; }
        public int ViewId => Arguments.GetInt("current_note_id", 0);

        Notes note;

        public static ViewNoteFragment NewInstance(int viewId)
        {
            var bundel = new Bundle();
            bundel.PutInt("current_note_id", viewId);
            return new ViewNoteFragment{Arguments = bundel};
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            note = new Notes();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) // Notes.asi
        {
            
            if(container == null)
            {
                return null;
            }
            var view = inflater.Inflate(Resource.Layout.otheredit, null);

            var btn = view.FindViewById<Button>(Resource.Id.button1);
            var change = view.FindViewById<EditText>(Resource.Id.edittext);
            var editbtn = view.FindViewById<Button>(Resource.Id.editbtn);
            var add = new NoteThings();

            var intent = new Intent(Activity, typeof(MainActivity));

            editbtn.Click += delegate
            {
                note.edit(ViewId + 1, change.Text);
                StartActivity(intent);
            };

            btn.Click += delegate { note.DeleteNote(note.GetAllNotes().ToList()[ViewId].Id); StartActivity(intent); };

            var NoteList = note.GetAllNotes().ToList();
            change.Text = NoteList.ElementAt(ViewId).Notetext;
            return view;
        }
       
    }

}