using System;
using System.Drawing;

namespace Rectangle
{
	public class RectWithOriginal : Rect
	{
		RectangleF original;

		public RectWithOriginal(RectangleF original)
		{
			this.original = original;
		}

		public RectWithOriginal(RectWithOriginal other)
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
			return new RectWithOriginal(this);
		}

		RectWithOriginal Modify(Action<RectWithOriginal> modify)
		{
			RectWithOriginal newRect = (RectWithOriginal)Clone();
			modify(newRect);
			return newRect;
		}

		// Horizontal dimension, basic properties

		public RectWithOriginal SameLeft()
		{
			return Modify(rect => rect.Left(original.Left));
		}

		public RectWithOriginal SameCenterX()
		{
			return Modify(rect => rect.CenterX(original.CenterX()));
		}

		public RectWithOriginal SameRight()
		{
			return Modify(rect => rect.Right(original.Right));
		}

		public RectWithOriginal SameWidth()
		{
			return Modify(rect => rect.Width(original.Width));
		}

		// Vertical dimension, basic properties

		public RectWithOriginal SameTop()
		{
			return Modify(rect => rect.Top(original.Top));
		}

		public RectWithOriginal SameCenterY()
		{
			return Modify(rect => rect.CenterY(original.CenterY()));
		}

		public RectWithOriginal SameBottom()
		{
			return Modify(rect => rect.Bottom(original.Bottom));
		}

		public RectWithOriginal SameHeight()
		{
			return Modify(rect => rect.Height(original.Height));
		}

		// Both dimensions, basic properties

		public RectWithOriginal SameTopLeft()
		{
			return SameTop().SameLeft();
		}

		public RectWithOriginal SameCenter()
		{
			return SameCenterX().SameCenterY();
		}

		public RectWithOriginal SameSize()
		{
			return SameWidth().SameHeight();
		}

		// Horizontal dimension, adding methods

		public RectWithOriginal AddToLeft(float delta)
		{
			return Modify(rect => rect.Left(original.Left + delta));
		}

		public RectWithOriginal AddToCenterX(float delta)
		{
			return Modify(rect => rect.CenterX(original.CenterX() + delta));
		}

		public RectWithOriginal AddToRight(float delta)
		{
			return Modify(rect => rect.Right(original.Right + delta));
		}

		public RectWithOriginal EnlargeHorizontally(float delta)
		{
			return Modify(rect => rect.Width(original.Width + delta));
		}

		// Vertical dimension, adding methods

		public RectWithOriginal AddToTop(float delta)
		{
			return Modify(rect => rect.Top(original.Top + delta));
		}

		public RectWithOriginal AddToCenterY(float delta)
		{
			return Modify(rect => rect.CenterY(original.CenterY() + delta));
		}

		public RectWithOriginal AddToBottom(float delta)
		{
			return Modify(rect => rect.Bottom(original.Bottom + delta));
		}

		public RectWithOriginal EnlargeVertically(float delta)
		{
			return Modify(rect => rect.Height(original.Height + delta));
		}

		// Both dimensions, adding methods

		public RectWithOriginal Enlarge(float widthDelta, float heightDelta)
		{
			return EnlargeHorizontally(widthDelta).EnlargeVertically(heightDelta);
		}

		public RectWithOriginal Enlarge(SizeF sizeDelta)
		{
			return EnlargeHorizontally(sizeDelta.Width).EnlargeVertically(sizeDelta.Height);
		}

		// Multiplying methods

		public RectWithOriginal RelativeWidth(float fraction)
		{
			return (RectWithOriginal)RelativeWidthOf(original, fraction);
		}

		public RectWithOriginal RelativeHeight(float fraction)
		{
			return (RectWithOriginal)RelativeHeightOf(original, fraction);
		}

		public RectWithOriginal RelativeSize(float fraction)
		{
			return (RectWithOriginal)RelativeSizeOf(original, fraction);
		}
	}
}