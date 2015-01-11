using System;
using Xamarin.Forms;

namespace CompoundControl
{
	public class CompoundElement : RelativeLayout
	{
		//		public static readonly BindableProperty PaddingProperty = BindableProperty.Create<CompoundElement, Thickness> (s => s.Padding, default(Thickness));
		//
		//		public static readonly BindableProperty ChildHorizontalOptionsProperty = BindableProperty.Create<CompoundElement, LayoutOptions> (s => s.ChildHorizontalOptions, LayoutOptions.CenterAndExpand);
		//		public static readonly BindableProperty ChildVerticalOptionsProperty = BindableProperty.Create<CompoundElement, LayoutOptions> (s => s.ChildVerticalOptions, LayoutOptions.CenterAndExpand);
		//
		//		public Thickness Padding {
		//			get { return (Thickness)GetValue (PaddingProperty); }
		//			set { SetValue (PaddingProperty, value); }
		//		}
		//
		//		public LayoutOptions ChildHorizontalOptions {
		//			get{ return (LayoutOptions)GetValue (ChildHorizontalOptionsProperty); }
		//			set{ SetValue (ChildHorizontalOptionsProperty, value); }
		//		}
		//
		//		public LayoutOptions ChildVerticalOptions {
		//			get{ return (LayoutOptions)GetValue (ChildVerticalOptionsProperty); }
		//			set{ SetValue (ChildVerticalOptionsProperty, value); }
		//		}

		public CompoundElement ()
		{
		}

		protected override void OnChildAdded (Element child)
		{
			base.OnChildAdded (child);

			var v = child as View;

			var ho = (LayoutOptions)child.GetValue (HorizontalOptionsProperty);
			var vo = (LayoutOptions)child.GetValue (VerticalOptionsProperty);

//			if (Padding.HorizontalThickness > 0 || Padding.VerticalThickness > 0) {
//				RelativeLayout.SetBoundsConstraint (child, BoundsConstraint.FromExpression (() => new Rectangle (this.X + Padding.Left, this.Y + Padding.Top, this.Width - Padding.HorizontalThickness, this.Height - Padding.VerticalThickness)));
//			}

			if (v.WidthRequest == -1) { // Autosize
//				child.SetValue (RelativeLayout.XConstraintProperty, Constraint.RelativeToParent (rl => rl.X + Padding.Left));
				child.SetValue (RelativeLayout.WidthConstraintProperty, Constraint.RelativeToParent (rl => rl.Width - Padding.HorizontalThickness));
				child.SetValue (HorizontalOptionsProperty, LayoutOptions.CenterAndExpand);
			} else {
				if (ho.Alignment == LayoutAlignment.Center) {
					child.SetValue (RelativeLayout.XConstraintProperty, Constraint.RelativeToParent (rl => rl.Width / 2 - v.WidthRequest / 2));
				} else if (ho.Alignment == LayoutAlignment.End) {
					child.SetValue (RelativeLayout.XConstraintProperty, Constraint.RelativeToParent (rl => rl.Width - v.WidthRequest));
				}
			}

			if (v.HeightRequest == -1) { // Autosize
//				child.SetValue (RelativeLayout.YConstraintProperty, Constraint.RelativeToParent (rl => rl.Y + Padding.Top));
				child.SetValue (RelativeLayout.HeightConstraintProperty, Constraint.RelativeToParent (rl => rl.Height));
				child.SetValue (VerticalOptionsProperty, LayoutOptions.CenterAndExpand);
			} else {
				if (vo.Alignment == LayoutAlignment.Center) {
					child.SetValue (RelativeLayout.YConstraintProperty, Constraint.RelativeToParent (rl => rl.Height / 2 - v.HeightRequest / 2));
				} else if (vo.Alignment == LayoutAlignment.End) {
					child.SetValue (RelativeLayout.YConstraintProperty, Constraint.RelativeToParent (rl => rl.Height - v.HeightRequest));
				}
			}
		}
	}
}