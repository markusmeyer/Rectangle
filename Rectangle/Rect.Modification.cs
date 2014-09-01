using System;
using System.Drawing;

namespace Rectangle
{
	public partial class Rect
	{
		Rect Modify(Action<Rect> modify)
		{
			Rect newRect = Clone();
			modify(newRect);
			return newRect;
		}

		// Horizontal dimension, basic properties

		public Rect Left(float left)
		{
			return Modify((Rect rect) => rect.SetLeft(left));
		}

		public Rect CenterX(float centerX)
		{
			return Modify((Rect rect) => rect.SetCenterX(centerX));
		}

		public Rect Right(float right)
		{
			return Modify((Rect rect) => rect.SetRight(right));
		}

		public Rect Width(float width)
		{
			return Modify((Rect rect) => rect.SetWidth(width));
		}

		// Vertical dimension, basic properties

		public Rect Top(float top)
		{
			return Modify((Rect rect) => rect.SetTop(top));
		}

		public Rect CenterY(float centerY)
		{
			return Modify((Rect rect) => rect.SetCenterY(centerY));
		}

		public Rect Bottom(float bottom)
		{
			return Modify((Rect rect) => rect.SetBottom(bottom));
		}

		public Rect Height(float height)
		{
			return Modify((Rect rect) => rect.SetHeight(height));
		}

		// Horizontal dimension, from RectangleF

		public Rect ToLeftOf(RectangleF rect, float margin = 0)
		{
			return Right(rect.Left - margin);
		}

		public Rect ToRightOf(RectangleF rect, float margin = 0)
		{
			return Left(rect.Right + margin);
		}

		public Rect AtRightOf(RectangleF rect, float margin = 0)
		{
			return Right(rect.Right - margin);
		}

		public Rect AtLeftOf(RectangleF rect, float margin = 0)
		{
			return Left(rect.Left + margin);
		}

		public Rect LeftOf(RectangleF rect)
		{
			return Left(rect.Left);
		}

		public Rect RightOf(RectangleF rect)
		{
			return Right(rect.Right);
		}

		public Rect LeftRightOf(RectangleF rect, float margin = 0)
		{
			return Left(rect.Left + margin).Right(rect.Right - margin);
		}

		public Rect WidthOf(RectangleF rect)
		{
			return Width(rect.Width);
		}

		public Rect RelativeWidthOf(RectangleF rect, float fraction)
		{
			return Width(rect.Width * fraction);
		}

		public Rect CenterXOf(RectangleF rect)
		{
			return CenterX(rect.Left + rect.Width / 2);
		}

		// Vertical dimension, from RectangleF

		public Rect Above(RectangleF rect, float margin = 0)
		{
			return Bottom(rect.Top - margin);
		}

		public Rect Below(RectangleF rect, float margin = 0)
		{
			return Top(rect.Bottom + margin);
		}

		public Rect AtTopOf(RectangleF rect, float margin = 0)
		{
			return Top(rect.Top + margin);
		}

		public Rect AtBottomOf(RectangleF rect, float margin = 0)
		{
			return Bottom(rect.Bottom - margin);
		}

		public Rect TopOf(RectangleF rect)
		{
			return Top(rect.Top);
		}

		public Rect BottomOf(RectangleF rect)
		{
			return Bottom(rect.Bottom);
		}

		public Rect TopBottomOf(RectangleF rect, float margin = 0)
		{
			return Top(rect.Top + margin).Bottom(rect.Bottom - margin);
		}

		public Rect HeightOf(RectangleF rect)
		{
			return Height(rect.Height);
		}

		public Rect RelativeHeightOf(RectangleF rect, float fraction)
		{
			return Height(rect.Height * fraction);
		}

		public Rect CenterYOf(RectangleF rect)
		{
			return CenterY(rect.Top + rect.Height / 2);
		}

		// Both dimensions, from RectangleF

		public Rect TopLeftOf(RectangleF rect)
		{
			return TopOf(rect).LeftOf(rect);
		}

		public Rect CenterOf(RectangleF rect)
		{
			return CenterXOf(rect).CenterYOf(rect);
		}

		public Rect SizeOf(RectangleF rect)
		{
			return WidthOf(rect).HeightOf(rect);
		}

		public Rect RelativeSizeOf(RectangleF rect, float fraction)
		{
			return RelativeWidthOf(rect, fraction).RelativeHeightOf(rect, fraction);
		}

		public Rect LeftTopRightBottom(float left, float top, float right, float bottom)
		{
			return Left(left).Top(top).Right(right).Bottom(bottom);
		}

		public Rect LeftTopRightBottomOf(RectangleF rect)
		{
			return LeftOf(rect).TopOf(rect).BottomOf(rect).RightOf(rect);
		}

		public Rect LeftTopWidthHeight(float left, float top, float width, float height)
		{
			return Left(left).Top(top).Width(width).Height(height);
		}

		public Rect LeftTopWidthHeightOf(RectangleF rect)
		{
			return LeftOf(rect).TopOf(rect).WidthOf(rect).HeightOf(rect);
		}

		// Both dimensions, from SizeF

		public Rect Size(SizeF size)
		{
			return Width(size.Width).Height(size.Height);
		}

		public Rect RelativeSize(SizeF size, float fraction)
		{
			return Width(size.Width * fraction).Height(size.Height * fraction);
		}

		public Rect Size(float width, float height)
		{
			return Width(width).Height(height);
		}

		// Both dimensions, from PointF

		public Rect TopLeft(PointF point)
		{
			return Top(point.Y).Left(point.X);
		}

		public Rect TopRight(PointF point)
		{
			return Top(point.Y).Right(point.X);
		}

		public Rect TopCenter(PointF point)
		{
			return Top(point.Y).CenterX(point.X);
		}

		public Rect CenterLeft(PointF point)
		{
			return CenterY(point.Y).Left(point.X);
		}

		public Rect CenterRight(PointF point)
		{
			return CenterY(point.Y).Right(point.X);
		}

		public Rect BottomLeft(PointF point)
		{
			return Bottom(point.Y).Left(point.X);
		}

		public Rect BottomCenter(PointF point)
		{
			return Bottom(point.Y).CenterX(point.X);
		}

		public Rect BottomRight(PointF point)
		{
			return Bottom(point.Y).Right(point.X);
		}
	}
}