using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;

namespace CompoundControl
{
	public partial class CompoundControl : AbsoluteLayout
	{
		public CompoundControl ()
		{
			InitializeComponent ();
		}

		protected override void OnChildAdded (Element child)
		{
			base.OnChildAdded (child);

			var pwr = this.GetValue (WidthRequestProperty);
			var phr = this.GetValue (HeightRequestProperty);
			var pb = AbsoluteLayout.GetLayoutBounds (this);

			var wr = (double)child.GetValue (WidthRequestProperty);
			var hr = (double)child.GetValue (HeightRequestProperty);


			AbsoluteLayout.SetLayoutFlags (child, AbsoluteLayoutFlags.PositionProportional);
//			AbsoluteLayout.SetLayoutFlags (child, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds (child, new Rectangle (0.5, 0.5, -1, -1));
//			AbsoluteLayout.SetLayoutBounds (child, new Rectangle (0.5, 0.5, wr, hr));

			var f = AbsoluteLayout.GetLayoutFlags (child);
			var flag = f.HasFlag (AbsoluteLayoutFlags.WidthProportional); // F
			var flag2 = f.HasFlag (AbsoluteLayoutFlags.HeightProportional); // F
			var flag3 = f.HasFlag (AbsoluteLayoutFlags.XProportional); // T
			var flag4 = f.HasFlag (AbsoluteLayoutFlags.YProportional); // T
			var b = AbsoluteLayout.GetLayoutBounds (child);

			var w = b.Width == AbsoluteLayout.AutoSize; // T
			var h = b.Height == AbsoluteLayout.AutoSize; // T
			var sr = ((View)child).GetSizeRequest (320,568); // Box=40x40; Image=100x-1; Label=-1x-1
		}

		protected override SizeRequest OnSizeRequest (double widthConstraint, double heightConstraint)
		{
			var s= base.OnSizeRequest (widthConstraint, heightConstraint);
			return s;
		}
		protected override void LayoutChildren (double x, double y, double width, double height)
		{
			var adjustedWidth = this.WidthRequest;
			var adjustedHeight = this.WidthRequest;
			base.LayoutChildren (x, y, width, height);
			foreach (var c in this.Children.Cast<View>()) {
				var x2 = c.X;
				var y2 = c.Y;
				var w2 = c.Width;
				var h2 = c.Height;
			}
		}
	}
}