//
// MyAdapter.cs
//
// Created by Thomas Dubiel on 15.06.2017
// Copyright 2017 Thomas Dubiel. All rights reserved.
//
using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace listViewDemo
{
	public class MyAdapter : BaseAdapter<string>, ISectionIndexer
	{
		List<string> items;
		Activity context;

		Dictionary<string, int> alphaIndex;
		string[] sections;
		Java.Lang.Object[] sectionObjects;

		public MyAdapter(Activity context, List<string> items)
		{
			this.items = items;
			this.context = context;

			alphaIndex = new Dictionary<string, int>();
			for (int i = 0; i < items.Count; i++)
			{
				var key = items[i][0].ToString();
				if (!alphaIndex.ContainsKey(key))
					alphaIndex.Add(key, i);
			}

			sections = new string[alphaIndex.Keys.Count];
			alphaIndex.Keys.CopyTo(sections, 0);
			sectionObjects = new Java.Lang.Object[sections.Length];
			for (int i = 0; i < sections.Length; i++)
			{
				sectionObjects[i] = new Java.Lang.String(sections[i]);
			}
		}

		// List View Methods

		public override string this[int position]
		{
			get
			{
				return items[position];
			}
		}

		public override int Count
		{
			get
			{
				return items.Count;
			}
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView;
			if (view == null)
				view = context.LayoutInflater.Inflate(Resource.Layout.CustomRow, null);

			var item = items[position];

			var clock = view.FindViewById<AnalogClock>(Resource.Id.analogClockCustomRow);
			if (position == 3)
			{
				item = "(Available for subscribers only)";
				clock.SetBackgroundColor(new Android.Graphics.Color(200, 55, 55));
			}
			else
			{
				clock.SetBackgroundColor(new Android.Graphics.Color(55, 55, 200));
			}


			view.FindViewById<TextView>(Resource.Id.textViewCustomRow).Text = item;
			return view;
		}

		// ISectionIndexer Methods

		public int GetPositionForSection(int sectionIndex)
		{
			return alphaIndex[sections[sectionIndex]];
		}

		public int GetSectionForPosition(int position)
		{
			int prevSection = 0;

			for (int i = 0; i < sections.Length; i++)
			{
				if (GetPositionForSection(i) > position)
					break;

				prevSection = i;
			}
			return prevSection;
		}

		public Java.Lang.Object[] GetSections()
		{
			return sectionObjects;
		}
	}


	// Sections in a ListView as is known in iOS see https://stackoverflow.com/questions/18302494/how-to-add-section-separators-dividers-to-a-listview
}