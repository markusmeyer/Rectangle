using System;
using System.Drawing;

namespace Rectangle
{
	class Example
	{
		void _()
		{
			RectangleF rect1 = new Rectangle(10, 20, 30, 40);
			RectangleF rect2 = 
				Rect.CreateWith()
				.Top(30)
				.Bottom(60)
				.CenterXOf(rect1)
				.RelativeWidthOf(rect1, 2)
				.ToRectangleF();
			
			RectangleF rect3 = new Rect().With.Top(20).ToRectangleF();

			Rect rect = Rect.CreateWith().Top(20).Rect;
			float? top = rect.Top;
			RectangleF rect6 = rect.With.Left(30).ToRectangleF();
			RectangleF rect5 = rect.With.LeftOf(rect2).ToRectangleF();
		}
	}
}