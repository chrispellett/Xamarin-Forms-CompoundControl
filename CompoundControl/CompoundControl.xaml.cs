using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace CompoundControl
{
	public partial class CompoundControl : AbsoluteLayout
	{
//		public static readonly BindableProperty ZOrderProperty = BindableProperty.CreateAttached<CompoundControl,int> (
//			                                                         o => CompoundControl.GetZOrder (o),
//			                                                         0
//		                                                         );
//
		public CompoundControl ()
		{
			InitializeComponent ();
		}

//		public static int GetZOrder (BindableObject o)
//		{
//			return (int)o.GetValue (ZOrderProperty);
//		}

		protected override void OnChildAdded (Element child)
		{
			base.OnChildAdded (child);
//			var wr = child.GetValue (WidthRequestProperty);
//			var hr = child.GetValue (HeightRequestProperty);
			AbsoluteLayout.SetLayoutFlags (child, AbsoluteLayoutFlags.PositionProportional);
			AbsoluteLayout.SetLayoutBounds (child, new Rectangle (0.5, 0.5, -1, -1));
		}
	}
}