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
			var r3 = Rect.CreateWith.Bottom(40).Height(10).CenterX(20).Width(30).ToRectangleF();
			var r4 = Rect.CreateWith.Left(10).Right(20).Width(30).Top(40).ToRectangleF();
			var r5 = Rect.CreateWith.Left(10).Right(20).Top(30).Bottom(40).Left(20).ToRectangleF();
		}

		void Example1()
		{
			RectangleF rect1 = new RectangleF(10, 20, 30, 40);
			PointF point = new PointF(50, 60);
			SizeF size = new SizeF(70,80);

			RectangleF rect2 = 
				Rect.CreateWith
				.TopLeft(point)
				.RightOf(rect1)
				.RelativeHeightOf(rect1, 2)
				.ToRectangleF();

			RectangleF rect3 = 
				Rect.CreateWith
				.Size(size)
				.AtRightOf(rect1)
				.AtBottomOf(rect1)
				.ToRectangleF();
		}

		void Example2()
		{
			Rect rect = Rect.CreateWith.Left(20);
			float left = rect.GetLeft().Value;
		}

		void Example3()
		{
			Rect rect = Rect.CreateWith.Left(10).Right(20).Top(30);
			RectangleF rect1 = rect.Bottom(40).ToRectangleF();
			RectangleF rect2 = rect.Bottom(50).ToRectangleF();
		}

		void Example4()
		{
			var rect = new RectangleF(10, 20, 30, 40);
			rect = rect.With().SameTopLeft().Size(100, 200).ToRectangleF();
			rect = rect.With().SameSize().Top(10).Left(20).ToRectangleF();
			rect = rect.With().SameRight().SameBottom().AddToLeft(10).AddToTop(20).ToRectangleF();
			rect = rect.With().SameCenter().AddToWidth(-20).AddToHeight(-20).ToRectangleF();
			rect = rect.With().SameCenter().RelativeHeight(.5f).RelativeWidth(.5f).ToRectangleF();
			rect = rect.With().SameCenter().RelativeSize(.5f).ToRectangleF();
			rect = rect.With().SameCenter().AddToSize(new SizeF(20, 30)).ToRectangleF();
			rect = rect.With().SameCenter().AddToSize(20, 30).ToRectangleF();

			rect = rect.Move(20, 20);
			rect = rect.MoveRight(20);
			rect = rect.MoveDown(20);
			rect = rect.With().SameWidth().Left(30).ToRectangleF();

			rect = rect.With().Right(10).Width(20).ToRectangleF();
		}
	}
}