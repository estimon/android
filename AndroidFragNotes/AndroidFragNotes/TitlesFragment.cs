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
    public class TitlesFragment : ListFragment
    {
        bool showingTwoFragments;
         
        int selectViewId;

        public TitlesFragment()
        {

        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            ListAdapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleListItemActivated1);

            var notecontainer = Activity.FindViewById(Resource.Id.note_container);
            showingTwoFragments = notecontainer != null &&
                                  notecontainer.Visibility == ViewStates.Visible;
            if (showingTwoFragments)
            {
                ListView.ChoiceMode = ChoiceMode.Single;
                ShowNotes(selectViewId);
            }

            if (savedInstanceState != null)
            {
                selectViewId = savedInstanceState.GetInt("current_note_id", 0);
            }
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutInt("current_note_id", selectViewId);
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            ShowNotes(position);
        }

        //void ShowNote(int ViewId)
        //{
        //    var intent = new Intent(Activity, typeof(ViewNoteActivity));
        //    intent.PutExtra("current_note_id", ViewId);
        //    StartActivity(intent);
        //}

        void ShowNotes(int ViewId)
        {
            selectViewId = ViewId;
            if (showingTwoFragments)
            {
                ListView.SetItemChecked(selectViewId, true);

                var NoteFragment = FragmentManager.FindFragmentById(Resource.Id.note_container) as ViewNoteFragment;

                if (NoteFragment == null || NoteFragment.ViewId != ViewId)
                {
                    var container = Activity.FindViewById(Resource.Id.note_container);
                    var NoteFrag = ViewNoteFragment.NewInstance(selectViewId);

                    FragmentTransaction ft = FragmentManager.BeginTransaction();
                    ft.Replace(Resource.Id.note_container, NoteFrag);
                    ft.Commit();
                }
            }
            else
            {
                var intent = new Intent(Activity, typeof(ViewNoteActivity));
                intent.PutExtra("current_note_id", ViewId);
                StartActivity(intent);
            }
        }
    }
}