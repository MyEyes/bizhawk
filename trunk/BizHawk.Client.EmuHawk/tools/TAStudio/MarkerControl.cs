﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BizHawk.Client.Common;

namespace BizHawk.Client.EmuHawk
{
	public partial class MarkerControl : UserControl
	{
		public TasMovieMarkerList Markers {get; set; }
		public Action AddCallback { get; set; }

		public MarkerControl()
		{
			InitializeComponent();
			MarkerView.QueryItemBkColor += MarkerView_QueryItemBkColor;
			MarkerView.QueryItemText += MarkerView_QueryItemText;
		}

		private void MarkerControl_Load(object sender, EventArgs e)
		{
			
		}

		public void UpdateValues()
		{
			Refresh();
		}

		private void MarkerView_QueryItemBkColor(int index, int column, ref Color color)
		{
			var prev = Markers.Previous(Global.Emulator.Frame);

			if (prev != null)
			{
				if (index == Markers.IndexOf(prev))
				{
					color = Color.LightGreen;
				}
			}
		}

		private void MarkerView_QueryItemText(int index, int column, out string text)
		{
			text = "";

			if (column == 0)
			{
				text = Markers[index].Frame.ToString();
			}
			else if (column == 1)
			{
				text = Markers[index].Message;
			}
		}

		private void AddBtn_Click(object sender, EventArgs e)
		{
			AddCallback();
		}

		public new void Refresh()
		{
			if (MarkerView != null && Markers != null)
			{
				MarkerView.ItemCount = Markers.Count;
			}

			base.Refresh();
		}
	}
}