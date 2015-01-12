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
        private List<PackageInfo> _installedPackages;
        private List<string> _packageNames;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ShortcutList);

            //ListView.ChoiceMode = ChoiceMode.Multiple;

            GetInstalledPackagesList();

            ListAdapter=new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItemMultipleChoice, _packageNames);

            var button = FindViewById<Button>(Resource.Id.TestButton);
            button.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var selectedItemIds = ListView.GetCheckItemIds();

            var intents = new List<Intent>();

            foreach (var selectedItemId in selectedItemIds)
            {
                var packagename = ((ArrayAdapter<string>) ListAdapter).GetItem((int)selectedItemId);
                var intent = PackageManager.GetLaunchIntentForPackage(packagename);
                intents.Add(intent);
            }

            StartActivities(intents.ToArray());
        }

        private void GetInstalledPackagesList()
        {
            _installedPackages = PackageManager.GetInstalledPackages(PackageInfoFlags.Activities).ToList();
            _packageNames = new List<string>();

            foreach (var installedPackage in _installedPackages)
            {
                _packageNames.Add(installedPackage.PackageName);
            }
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