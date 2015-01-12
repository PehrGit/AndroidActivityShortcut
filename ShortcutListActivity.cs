using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace AndroidActivityShortcut
{
    [Activity(Label = "ShortcutListActivity")]
    public class ShortcutListActivity : ListActivity
    {
        private List<string> _items;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ShortcutList);

            //ListView.ChoiceMode = ChoiceMode.Multiple;

            _items = new List<string>();

            GetInstalledPackagesList();

            _items.AddRange(new List<string> {"a", "a", "a", "a"});

            ListAdapter=new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItemMultipleChoice, _items);

        }

        private void GetInstalledPackagesList()
        {
            var installedPackages = PackageManager.GetInstalledPackages(PackageInfoFlags.Activities).ToList();
            var installedIntentFilters = PackageManager.GetInstalledPackages(PackageInfoFlags.IntentFilters).ToList();

            var a = 1 + 1;
        }

        public override View OnCreateView(View parent, string name, Context context, IAttributeSet attrs)
        {
            return base.OnCreateView(parent, name, context, attrs);
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
        }
    }
}