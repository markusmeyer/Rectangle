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

		// Horizontal dimension, basic properties

		public RectWithOriginal SameLeft()
		{
			return (RectWithOriginal)Left(original.Left);
		}

		public RectWithOriginal SameCenterX()
		{
			return (RectWithOriginal)CenterX(original.CenterX());
		}

		public RectWithOriginal SameRight()
		{
			return (RectWithOriginal)Right(original.Right);
		}

		public RectWithOriginal SameWidth()
		{
			return (RectWithOriginal)Width(original.Width);
		}

		// Vertical dimension, basic properties

		public RectWithOriginal SameTop()
		{
			return (RectWithOriginal)Top(original.Top);
		}

		public RectWithOriginal SameCenterY()
		{
			return (RectWithOriginal)CenterY(original.CenterY());
		}

		public RectWithOriginal SameBottom()
		{
			return (RectWithOriginal)Bottom(original.Bottom);
		}

		public RectWithOriginal SameHeight()
		{
			return (RectWithOriginal)Height(original.Height);
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

		// Horizontal dimension, moving/enlarging methods

		public RectWithOriginal LeftMovedBy(float delta)
		{
			return (RectWithOriginal)Left(original.Left + delta);
		}

		public RectWithOriginal CenterXMovedBy(float delta)
		{
			return (RectWithOriginal)CenterX(original.CenterX() + delta);
		}

		public RectWithOriginal RightMovedBy(float delta)
		{
			return (RectWithOriginal)Right(original.Right + delta);
		}

		public RectWithOriginal WidthEnlargedBy(float delta)
		{
			return (RectWithOriginal)Width(original.Width + delta);
		}

		// Vertical dimension, moving/enlarging methods

		public RectWithOriginal TopMovedBy(float delta)
		{
			return (RectWithOriginal)Top(original.Top + delta);
		}

		public RectWithOriginal CenterYMovedBy(float delta)
		{
			return (RectWithOriginal)CenterY(original.CenterY() + delta);
		}

		public RectWithOriginal BottomMovedBy(float delta)
		{
			return (RectWithOriginal)Bottom(original.Bottom + delta);
		}

		public RectWithOriginal HeightEnlargedBy(float delta)
		{
			return (RectWithOriginal)Height(original.Height + delta);
		}

		// Both dimensions, moving/enlarging methods

		public RectWithOriginal LeftTopMovedBy(float leftDelta, float topDelta)
		{
			return SameSize().LeftMovedBy(leftDelta).TopMovedBy(topDelta);
		}

		public RectWithOriginal EnlargedBy(float widthDelta, float heightDelta)
		{
			return WidthEnlargedBy(widthDelta).HeightEnlargedBy(heightDelta);
		}

		public RectWithOriginal EnlargedBy(SizeF sizeDelta)
		{
			return WidthEnlargedBy(sizeDelta.Width).HeightEnlargedBy(sizeDelta.Height);
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