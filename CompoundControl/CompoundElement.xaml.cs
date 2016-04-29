using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CompoundControl
{
	public partial class CompoundElement : RelativeLayout
	{
		public CompoundElement ()
		{
			InitializeComponent ();
		}

		protected override void OnAdded (View child)
		{
			var ho = (LayoutOptions)child.GetValue (HorizontalOptionsProperty);
			var vo = (LayoutOptions)child.GetValue (VerticalOptionsProperty);

			if (ho.Alignment == LayoutAlignment.Center || ho.Alignment == LayoutAlignment.Fill) {
				child.SetValue (RelativeLayout.XConstraintProperty, Constraint.RelativeToParent (rl => rl.Width / 2 - child.Width / 2));
			} else if (ho.Alignment == LayoutAlignment.End) {
				child.SetValue (RelativeLayout.XConstraintProperty, Constraint.RelativeToParent (rl => {
					return rl.Width - child.Width;
				}));
			}

			if (vo.Alignment == LayoutAlignment.Center || vo.Alignment == LayoutAlignment.Fill) {
				child.SetValue (RelativeLayout.YConstraintProperty, Constraint.RelativeToParent (rl => rl.Height / 2 - child.Height / 2));
			} else if (vo.Alignment == LayoutAlignment.End) {
				child.SetValue (RelativeLayout.YConstraintProperty, Constraint.RelativeToParent (rl => {
					return rl.Height - child.Height;
				}));
			}

			child.SizeChanged += (sender, e) => {
				ForceLayout ();
			};

			base.OnAdded (child);
		}

		protected override void OnRemoved (View child)
		{
			base.OnRemoved (child);
		}
	}
}