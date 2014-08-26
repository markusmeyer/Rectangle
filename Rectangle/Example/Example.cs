using System;
using System.Drawing;

namespace Rectangle
{
	class Example
	{
		void _()
		{
			RectangleF rect2 = Rect.CreateWith().Top(20).ToRectangleF();
			
			RectangleF rect3 = new Rect().With.Top(20).ToRectangleF();

			Rect rect = Rect.CreateWith().Top(20).Rect;
			float? top = rect.Top;
			RectangleF rect6 = rect.With.Left(30).ToRectangleF();
			RectangleF rect5 = rect.With.LeftOf(rect2).ToRectangleF();
		}
	}
}