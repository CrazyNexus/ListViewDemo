using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Util;

namespace listViewDemo
{
	[Activity(Label = "listViewDemo", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			var data = new List<string>();
			for (var i = 0; i < 100; i++)
			{
				data.Add("Item number: " + i.ToString());
			}

			var listView = FindViewById<ListView>(Resource.Id.listView1);
			listView.FastScrollEnabled = true;

			// Simple Adapter using with standard stuff
			// var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, data);

			var adapter = new MyAdapter(this, data);

			listView.Adapter = adapter;
			listView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
			{
				Log.Debug("ITEM CLICKED", "Number: " + e.Position);
			};
		}
	}
}

