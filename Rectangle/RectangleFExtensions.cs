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

		// Modifications, horizontal

		public static RectangleF SetLeftKeepWidth(this RectangleF rect, float left)
		{
			return new RectangleF(left, rect.Top, rect.Width, rect.Height);
		}

		public static RectangleF SetLeftKeepRight(this RectangleF rect, float left)
		{
			float width = rect.Right - left;
			return new RectangleF(left, rect.Top, width, rect.Height);
		}

		public static RectangleF SetLeftKeepCenter(this RectangleF rect, float left)
		{
			float center = rect.CenterX();
			float width = (center - left) * 2;
			return new RectangleF(left, rect.Top, width, rect.Height);
		}

		public static RectangleF SetCenterXKeepWidth(this RectangleF rect, float centerX)
		{
			float left = centerX - rect.Width / 2;
			return new RectangleF(left, rect.Top, rect.Width, rect.Height);
		}

		public static RectangleF SetCenterXKeepLeft(this RectangleF rect, float centerX)
		{
			float width = (centerX - rect.Left) * 2;
			return new RectangleF(rect.Left, rect.Top, width, rect.Height);
		}

		public static RectangleF SetCenterXKeepRight(this RectangleF rect, float centerX)
		{
			float width = (rect.Right - centerX) * 2;
			float left = rect.Right - width;
			return new RectangleF(left, rect.Top, width, rect.Height);
		}

		public static RectangleF SetRightKeepWidth(this RectangleF rect, float right)
		{
			float left = right - rect.Width;
			return new RectangleF(left, rect.Top, rect.Width, rect.Height);
		}

		public static RectangleF SetRightKeepLeft(this RectangleF rect, float right)
		{
			float width = right - rect.Left;
			return new RectangleF(rect.Left, rect.Top, width, rect.Height);
		}

		public static RectangleF SetRightKeepCenter(this RectangleF rect, float right)
		{
			float center = rect.CenterX();
			float width = (right - center) * 2;
			float left = right - width;
			return new RectangleF(left, rect.Top, width, rect.Height);
		}

		// Modifications, vertical

		public static RectangleF SetTopKeepHeight(this RectangleF rect, float top)
		{
			return new RectangleF(rect.Left, top, rect.Width, rect.Height);
		}

		public static RectangleF SetTopKeepBottom(this RectangleF rect, float top)
		{
			float height = rect.Bottom - top;
			return new RectangleF(rect.Left, top, rect.Width, height);
		}

		public static RectangleF SetTopKeepCenter(this RectangleF rect, float top)
		{
			float center = rect.CenterY();
			float height = (center - top) * 2;
			return new RectangleF(rect.Left, top, rect.Width, height);
		}

		public static RectangleF SetCenterYKeepHeight(this RectangleF rect, float centerY)
		{
			float top = centerY - rect.Height / 2;
			return new RectangleF(rect.Left, top, rect.Width, rect.Height);
		}

		public static RectangleF SetCenterYKeepTop(this RectangleF rect, float centerY)
		{
			float height = (centerY - rect.Top) * 2;
			return new RectangleF(rect.Left, rect.Top, rect.Width, height);
		}

		public static RectangleF SetCenterYKeepBottom(this RectangleF rect, float centerY)
		{
			float height = (rect.Bottom - centerY) * 2;
			float top = rect.Bottom - height;
			return new RectangleF(rect.Left, top, rect.Width, height);
		}

		public static RectangleF SetBottomKeepHeight(this RectangleF rect, float bottom)
		{
			float top = bottom - rect.Height;
			return new RectangleF(rect.Left, top, rect.Width, rect.Height);
		}

		public static RectangleF SetBottomKeepTop(this RectangleF rect, float bottom)
		{
			float height = bottom - rect.Top;
			return new RectangleF(rect.Left, rect.Top, rect.Width, height);
		}

		public static RectangleF SetBottomKeepCenter(this RectangleF rect, float bottom)
		{
			float center = rect.CenterY();
			float height = (bottom - center) * 2;
			float top = bottom - height;
			return new RectangleF(rect.Left, top, rect.Width, height);
		}

		// TODO

//		public static RectangleF Displace(this RectangleF rect, float dx, float dy)
//		{
//		}
//
//		public static RectangleF MoveTopLeftTo()
//		{
//		}
//
//		SetWidthHeightKeepTopLeft

	}
}