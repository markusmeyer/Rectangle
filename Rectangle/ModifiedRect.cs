using System;
using System.Drawing;

namespace Rectangle
{
	public class ModifiedRect : Rect
	{
		RectangleF original;

		public ModifiedRect(RectangleF original)
		{
			this.original = original;
		}

		public ModifiedRect(ModifiedRect other)
			:base(other)
		{
			original = other.original;
		}

		public override RectangleF ToRectangleF()
		{
			xRange.SetLowAndLengthIfUnspecified(original.Left, original.Width);
			yRange.SetLowAndLengthIfUnspecified(original.Top, original.Height);
			return base.ToRectangleF();
		}

		public override Rect Clone()
		{
			return new ModifiedRect(this);
		}

		ModifiedRect Modify(Action<ModifiedRect> modify)
		{
			ModifiedRect newRect = (ModifiedRect)Clone();
			modify(newRect);
			return newRect;
		}

		// basic, horizontal

		public ModifiedRect SameLeft()
		{
			return Modify(rect => rect.Left(original.Left));
		}

		public ModifiedRect SameCenterX()
		{
			return Modify(rect => rect.CenterX(original.CenterX()));
		}

		public ModifiedRect SameRight()
		{
			return Modify(rect => rect.Right(original.Right));
		}

		public ModifiedRect SameWidth()
		{
			return Modify(rect => rect.Width(original.Width));
		}

		// basic, vertical

		public ModifiedRect SameTop()
		{
			return Modify(rect => rect.Top(original.Top));
		}

		public ModifiedRect SameCenterY()
		{
			return Modify(rect => rect.CenterY(original.CenterY()));
		}

		public ModifiedRect SameBottom()
		{
			return Modify(rect => rect.Bottom(original.Bottom));
		}

		public ModifiedRect SameHeight()
		{
			return Modify(rect => rect.Height(original.Height));
		}

		// basic, both dimensions

		public ModifiedRect SameTopLeft()
		{
			return SameTop().SameLeft();
		}

		public ModifiedRect SameCenter()
		{
			return SameCenterX().SameCenterY();
		}

		public ModifiedRect SameSize()
		{
			return SameWidth().SameHeight();
		}

		// add, horizontal

		public ModifiedRect AddToLeft(float delta)
		{
			return Modify(rect => rect.Left(original.Left + delta));
		}

		public ModifiedRect AddToCenterX(float delta)
		{
			return Modify(rect => rect.CenterX(original.CenterX() + delta));
		}

		public ModifiedRect AddToRight(float delta)
		{
			return Modify(rect => rect.Right(original.Right + delta));
		}

		public ModifiedRect EnlargeHorizontally(float delta)
		{
			return Modify(rect => rect.Width(original.Width + delta));
		}

		// add, vertical

		public ModifiedRect AddToTop(float delta)
		{
			return Modify(rect => rect.Top(original.Top + delta));
		}

		public ModifiedRect AddToCenterY(float delta)
		{
			return Modify(rect => rect.CenterY(original.CenterY() + delta));
		}

		public ModifiedRect AddToBottom(float delta)
		{
			return Modify(rect => rect.Bottom(original.Bottom + delta));
		}

		public ModifiedRect EnlargeVertically(float delta)
		{
			return Modify(rect => rect.Height(original.Height + delta));
		}

		// add, both dimensions

		public ModifiedRect Enlarge(float widthDelta, float heightDelta)
		{
			return EnlargeHorizontally(widthDelta).EnlargeVertically(heightDelta);
		}

		public ModifiedRect Enlarge(SizeF sizeDelta)
		{
			return EnlargeHorizontally(sizeDelta.Width).EnlargeVertically(sizeDelta.Height);
		}

		// multiply

		public ModifiedRect RelativeWidth(float fraction)
		{
			return (ModifiedRect)RelativeWidthOf(original, fraction);
		}

		public ModifiedRect RelativeHeight(float fraction)
		{
			return (ModifiedRect)RelativeHeightOf(original, fraction);
		}

		public ModifiedRect RelativeSize(float fraction)
		{
			return (ModifiedRect)RelativeSizeOf(original, fraction);
		}
	}
}