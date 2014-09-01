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

		void Examples_RectWithOriginal()
		{
			var rect = new RectangleF(10, 20, 30, 40);

			// create new:
			Rect.CreateWith.TopOf(rect).RightOf(rect).HeightOf(rect).Width(100).ToRectangleF();
			// better:
			rect.With().SameTop().SameRight().SameHeight().Width(100).ToRectangleF();
			// even shorter:
			rect.With().SameRight().Width(100).ToRectangleF();

			// omit whole dimension
			rect.With().SameWidth().Left(30).ToRectangleF();
			rect.With().Right(10).Width(20).ToRectangleF();

			// relocate top left:
			rect.With().SameSize().Top(20).Left(30).ToRectangleF();

			// multiply
			rect.With().SameCenter().RelativeHeight(.5f).RelativeWidth(.5f).ToRectangleF();
			rect.With().SameCenter().RelativeSize(.5f).ToRectangleF();

			// add / enlarge
			rect.With().SameRight().SameBottom().AddToLeft(10).AddToTop(20).ToRectangleF();
			rect.With().SameCenter().EnlargeHorizontally(20).EnlargeVertically(30).ToRectangleF();
			rect.With().SameCenter().Enlarge(new SizeF(20, 30)).ToRectangleF();
			rect.With().SameCenter().Enlarge(20, 30).ToRectangleF();

			// move
			rect.With().SameSize().AddToLeft(20).AddToTop(30).ToRectangleF();
			rect.Move(20, 30);
			rect.MoveRight(20);
			rect.MoveDown(30);

			// corners
			Rect.CreateWith.TopLeft(rect.BottomRight()).Size(10, 20).ToRectangleF();

			// center
			rect.CenterX();
			rect.CenterY();
		}
	}
}