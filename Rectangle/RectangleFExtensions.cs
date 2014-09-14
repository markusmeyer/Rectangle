using System;
using System.Drawing;

namespace Rectangle
{
	public static class RectangleFExtensions
	{
		// Center

		public static float CenterX(this RectangleF rect)
		{
			return rect.Left + rect.Width / 2;
		}

		public static float CenterY(this RectangleF rect)
		{
			return rect.Top + rect.Height / 2;
		}

		// Corners

		public static PointF TopLeft(this RectangleF rect)
		{
			return new PointF(rect.Left, rect.Top);
		}

		public static PointF TopCenter(this RectangleF rect)
		{
			return new PointF(rect.CenterX(), rect.Top);
		}

		public static PointF TopRight(this RectangleF rect)
		{
			return new PointF(rect.Right, rect.Top);
		}

		public static PointF CenterLeft(this RectangleF rect)
		{
			return new PointF(rect.Left, rect.CenterY());
		}

		public static PointF Center(this RectangleF rect)
		{
			return new PointF(rect.CenterX(), rect.CenterY());
		}

		public static PointF CenterRight(this RectangleF rect)
		{
			return new PointF(rect.Right, rect.CenterY());
		}

		public static PointF BottomLeft(this RectangleF rect)
		{
			return new PointF(rect.Left, rect.Bottom);
		}

		public static PointF BottomCenter(this RectangleF rect)
		{
			return new PointF(rect.CenterX(), rect.Bottom);
		}

		public static PointF BottomRight(this RectangleF rect)
		{
			return new PointF(rect.Right, rect.Bottom);
		}

		// Move

		public static RectangleF Move(this RectangleF rectangle, float deltaX, float deltaY)
		{
			return new RectangleF(
				rectangle.Left + deltaX,
				rectangle.Top + deltaY,
				rectangle.Width,
				rectangle.Height);
		}

		public static RectangleF MoveRight(this RectangleF rectangle, float delta)
		{
			return new RectangleF(
				rectangle.Left + delta,
				rectangle.Top,
				rectangle.Width,
				rectangle.Height);
		}

		public static RectangleF MoveDown(this RectangleF rectangle, float delta)
		{
			return new RectangleF(
				rectangle.Left,
				rectangle.Top + delta,
				rectangle.Width,
				rectangle.Height);
		}

		// RectWithOriginal

		public static RectWithOriginal With(this RectangleF rectangle)
		{
			return new RectWithOriginal(rectangle);
		}

		public static RectWithOriginal WithSameSize(this RectangleF rectangle)
		{
			return rectangle.With().SameSize();
		}

		public static RectWithOriginal WithSameTopLeft(this RectangleF rectangle)
		{
			return rectangle.With().SameTop().SameLeft();
		}
	}
}