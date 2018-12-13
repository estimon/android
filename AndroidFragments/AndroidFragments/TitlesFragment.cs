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
    public class TitlesFragment : ListFragment
    {
        int selectedPlayId;
        bool showingTwoFragments;

        public TitlesFragment()
        {

        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);


            var quoteContainer = Activity.FindViewById(Resource.Id.playquote_container);
            showingTwoFragments = quoteContainer != null &&
                                  quoteContainer.Visibility == ViewStates.Visible;
            if (showingTwoFragments)
            {
                ListView.ChoiceMode = ChoiceMode.Single;
                ShowPlayQuote(selectedPlayId);
            }
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutInt("current_play_id", selectedPlayId);
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            ShowPlayQuote(position);
        }

        void ShowPlayQuote(int playId)
        {
            selectedPlayId = playId;
            if (showingTwoFragments)
            {
                ListView.SetItemChecked(selectedPlayId, true);

                var playQuoteFragment = FragmentManager.FindFragmentById(Resource.Id.playquote_container) as PlayQuateFragment;

                if (playQuoteFragment == null || playQuoteFragment.PlayId != playId)
                {
                    var container = Activity.FindViewById(Resource.Id.playquote_container);
                    var quoteFrag = PlayQuateFragment.newInstacne(selectedPlayId);

                    FragmentTransaction ft = FragmentManager.BeginTransaction();
                    ft.Replace(Resource.Id.playquote_container, quoteFrag);
                    ft.Commit();
                }
            }
            else
            {
                var intent = new Intent(Activity, typeof(PlayQuateAct));
                intent.PutExtra("current_play_id", playId);
                StartActivity(intent);
            }
        }




    }
}