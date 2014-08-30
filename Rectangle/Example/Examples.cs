using System;
using System.Drawing;

namespace Rectangle
{
	class Examples
	{
		void BasicExamples()
		{
			var r1 = new RectangleF(10, 20, 30, 30);
			var r2 = RectangleF.FromLTRB(10, 20, 30, 40);
			var r3 = Rect.CreateWith().Bottom(40).Height(10).CenterX(20).Width(30).ToRectangleF();
			var r4 = Rect.CreateWith().Left(10).Right(20).Width(30).Top(40).ToRectangleF();
			var r5 = Rect.CreateWith().Left(10).Right(20).Top(30).Bottom(40).Left(20).ToRectangleF();
		}

		void Example1()
		{
			RectangleF rect1 = new RectangleF(10, 20, 30, 40);
			PointF point = new PointF(50, 60);
			SizeF size = new SizeF(70,80);

			RectangleF rect2 = 
				Rect.CreateWith()
				.TopLeft(point)
				.RightOf(rect1)
				.RelativeHeightOf(rect1, 2)
				.ToRectangleF();

			RectangleF rect3 = 
				Rect.CreateWith()
				.Size(size)
				.AtRightOf(rect1)
				.AtBottomOf(rect1)
				.ToRectangleF();
		}

		void Example2()
		{
			Rect rect = Rect.CreateWith().Left(20).Rect;
			float left = rect.Left.Value;
		}

		void Example3()
		{
			Rect rect = Rect.CreateWith().Left(10).Right(20).Top(30).Rect;
			RectangleF rect1 = rect.With.Bottom(40).ToRectangleF();
			RectangleF rect2 = rect.With.Bottom(50).ToRectangleF();
		}
	}
}