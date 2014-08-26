using System;
using System.Drawing;

namespace Rectangle
{
	public partial class Rect
	{
		public class RectModifier
		{
			public Rect Rect { get; private set; }

			public RectModifier(Rect rect)
			{
				if (rect == null)
					throw new ArgumentNullException("rect");

				Rect = rect;
			}

			public RectangleF ToRectangleF()
			{
				return Rect.ToRectangleF();
			}

			RectModifier Modify(Action<Rect> modify)
			{
				Rect newRect = Rect.Clone();
				modify(newRect);
				return new RectModifier(newRect);
			}

			// Horizontal dimension, basic

			public RectModifier Left(float left)
			{
				return Modify((Rect rect) => rect.Left = left);
			}

			public RectModifier CenterX(float centerX)
			{
				return Modify((Rect rect) => rect.CenterX = centerX);
			}

			public RectModifier Right(float right)
			{
				return Modify((Rect rect) => rect.Right = right);
			}

			public RectModifier Width(float width)
			{
				return Modify((Rect rect) => rect.Width = width);
			}

			// Vertical dimension, basic

			public RectModifier Top(float top)
			{
				return Modify((Rect rect) => rect.Top = top);
			}

			public RectModifier CenterY(float centerY)
			{
				return Modify((Rect rect) => rect.CenterY = centerY);
			}

			public RectModifier Bottom(float bottom)
			{
				return Modify((Rect rect) => rect.Bottom = bottom);
			}

			public RectModifier Height(float height)
			{
				return Modify((Rect rect) => rect.Height = height);
			}

			// Horizontal dimension, extended

			public RectModifier ToLeftOf(RectangleF rect, float margin = 0)
			{
				return Right(rect.Left - margin);
			}

			public RectModifier ToRightOf(RectangleF rect, float margin = 0)
			{
				return Left(rect.Right + margin);
			}

			public RectModifier AtRightOf(RectangleF rect, float margin = 0)
			{
				return Right(rect.Right - margin);
			}

			public RectModifier AtLeftOf(RectangleF rect, float margin = 0)
			{
				return Left(rect.Left + margin);
			}

			public RectModifier LeftOf(RectangleF rect)
			{
				return Left(rect.Left);
			}

			public RectModifier RightOf(RectangleF rect)
			{
				return Right(rect.Right);
			}

			public RectModifier LeftRightOf(RectangleF rect, float margin = 0)
			{
				return Left(rect.Left + margin).Right(rect.Right - margin);
			}

			public RectModifier WidthOf(RectangleF rect)
			{
				return Width(rect.Width);
			}

			public RectModifier RelativeWidthOf(RectangleF rect, float fraction)
			{
				return Width(rect.Width * fraction);
			}

			public RectModifier CenterXOf(RectangleF rect)
			{
				return CenterX(rect.Left + rect.Width / 2);
			}

			// Vertical dimension, extended

			public RectModifier Above(RectangleF rect, float margin = 0)
			{
				return Bottom(rect.Top - margin);
			}

			public RectModifier Below(RectangleF rect, float margin = 0)
			{
				return Top(rect.Bottom + margin);
			}

			public RectModifier AtTopOf(RectangleF rect, float margin = 0)
			{
				return Top(rect.Top + margin);
			}

			public RectModifier AtBottomOf(RectangleF rect, float margin = 0)
			{
				return Bottom(rect.Bottom - margin);
			}

			public RectModifier TopOf(RectangleF rect)
			{
				return Top(rect.Top);
			}

			public RectModifier BottomOf(RectangleF rect)
			{
				return Bottom(rect.Bottom);
			}

			public RectModifier TopBottomOf(RectangleF rect, float margin = 0)
			{
				return Top(rect.Top + margin).Bottom(rect.Bottom - margin);
			}

			public RectModifier HeightOf(RectangleF rect)
			{
				return Height(rect.Height);
			}

			public RectModifier RelativeHeightOf(RectangleF rect, float fraction)
			{
				return Height(rect.Height * fraction);
			}

			public RectModifier CenterYOf(RectangleF rect)
			{
				return CenterY(rect.Top + rect.Height / 2);
			}

			// Both dimensions, from RectangleF

			public RectModifier TopLeftOf(RectangleF rect)
			{
				return TopOf(rect).LeftOf(rect);
			}

			public RectModifier CenterOf(RectangleF rect)
			{
				return CenterXOf(rect).CenterYOf(rect);
			}

			public RectModifier SizeOf(RectangleF rect)
			{
				return WidthOf(rect).HeightOf(rect);
			}

			public RectModifier RelativeSizeOf(RectangleF rect, float relativeSize)
			{
				return RelativeWidthOf(rect, relativeSize).RelativeHeightOf(rect, relativeSize);
			}

			public RectModifier LeftTopRightBottom(float left, float top, float right, float bottom)
			{
				return Left(left).Top(top).Right(right).Bottom(bottom);
			}

			public RectModifier LeftTopRightBottomOf(RectangleF rect)
			{
				return LeftOf(rect).TopOf(rect).BottomOf(rect).RightOf(rect);
			}

			public RectModifier LeftTopWidthHeight(float left, float top, float width, float height)
			{
				return Left(left).Top(top).Width(width).Height(height);
			}

			public RectModifier LeftTopWidthHeightOf(RectangleF rect)
			{
				return LeftOf(rect).TopOf(rect).WidthOf(rect).HeightOf(rect);
			}

			// Both dimensions, from SizeF

			public RectModifier Size(SizeF size)
			{
				return Width(size.Width).Height(size.Height);
			}

			public RectModifier Size(float width, float height)
			{
				return Width(width).Height(height);
			}

			// Both dimensions, from PointF

			public RectModifier TopLeft(PointF point)
			{
				return Top(point.Y).Left(point.X);
			}

			public RectModifier TopRight(PointF point)
			{
				return Top(point.Y).Right(point.X);
			}

			public RectModifier TopCenter(PointF point)
			{
				return Top(point.Y).CenterX(point.X);
			}

			public RectModifier CenterLeft(PointF point)
			{
				return CenterY(point.Y).Left(point.X);
			}

			public RectModifier CenterRight(PointF point)
			{
				return CenterY(point.Y).Right(point.X);
			}

			public RectModifier BottomLeft(PointF point)
			{
				return Bottom(point.Y).Left(point.X);
			}

			public RectModifier BottomCenter(PointF point)
			{
				return Bottom(point.Y).CenterX(point.X);
			}

			public RectModifier BottomRight(PointF point)
			{
				return Bottom(point.Y).Right(point.X);
			}
		}
	}
}