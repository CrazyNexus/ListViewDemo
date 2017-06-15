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

namespace listViewDemo
{
	public class MyAdapter : BaseAdapter<string>
	{
		List<string> items;
		Activity context;

		public MyAdapter(Activity context, List<string> items)
		{
			this.items = items;
			this.context = context;
		}

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
	}
}