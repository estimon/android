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
        

        public int ViewId => Arguments.GetInt("current_note_id", 0);

        public static ViewNoteFragment NewInstance(int viewId)
        {
            var bundel = new Bundle();
            bundel.PutInt("current_note_id", viewId);
            return new ViewNoteFragment{Arguments = bundel};
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) // Notes.asi
        {
            
            if(container == null)
            {
                return null;
            }
            var add = new NoteThings();
            var Textview = new TextView(Activity);
            var padding = Convert.ToInt32(TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, Activity.Resources.DisplayMetrics));
            Textview.SetPadding(padding, padding, padding, padding);
            Textview.TextSize = 24;

            //Textview.Text = add.notetext;

            var scroller = new ScrollView(Activity);
            scroller.AddView(Textview);


            return scroller;
        }
    }
}