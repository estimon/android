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

namespace AndroidFragments
{
    public class PlayQuateFragment : Fragment
    {
        public int PlayId => Arguments.GetInt("current_play_id", 0);

        public static PlayQuateFragment newInstacne(int PlayId)
        {
            var bundel = new Bundle();
            bundel.PutInt("current_play_id", PlayId);
            return new PlayQuateFragment { Arguments = bundel };
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            if(container == null)
            {
                return null;
            }

            var textview = new TextView(Activity);
            var padding = Convert.ToInt32(TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, Activity.Resources.DisplayMetrics));
            textview.SetPadding(padding, padding, padding, padding);
            textview.TextSize = 24;
            textview.Text = shakespear.Dialogue[PlayId];

            var scroller = new ScrollView(Activity);
            scroller.AddView(textview);
            return scroller;


        }
    }
}