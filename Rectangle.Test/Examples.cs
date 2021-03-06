using System;
using System.Drawing;

namespace Rectangle.Test
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

		void MoreFlexible()
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

		void MoreFeatures1()
		{
			Rect rect = Rect.CreateWith.Left(20);
			float left = rect.GetLeft().Value;
		}

		void MoreFeatures2()
		{
			Rect rect = Rect.CreateWith.Left(10).Right(20).Top(30);
			RectangleF rect1 = rect.Bottom(40).ToRectangleF();
			RectangleF rect2 = rect.Bottom(50).ToRectangleF();
		}

		RectangleF rect = new RectangleF(10, 20, 30, 40);

		void ModifyRectangles()
		{
			// create new
			Rect.CreateWith.TopOf(rect).RightOf(rect).HeightOf(rect).Width(100).ToRectangleF();

			// better
			rect.With().SameTop().SameRight().SameHeight().Width(100).ToRectangleF();

			// move top left
			rect.With().SameSize().Top(20).Left(30).ToRectangleF();
		}

		void EvenShorter()
		{
			rect.With().SameRight().Width(100).ToRectangleF();

			// not enough
			rect.With().Width(100).ToRectangleF();

			// omit whole dimension
			rect.With().SameWidth().Left(30).ToRectangleF();
			rect.With().Right(10).Width(20).ToRectangleF();
		}

		void RelativeSizes()
		{
			rect.With().SameCenter().RelativeHeight(.5f).RelativeWidth(.5f).ToRectangleF();
			rect.With().SameCenter().RelativeSize(.5f).ToRectangleF();
		}

		void MovingAndEnlarging()
		{
			rect.With().SameRight().SameBottom().LeftMovedBy(10).TopMovedBy(20).ToRectangleF();
			rect.With().SameCenter().WidthEnlargedBy(20).HeightEnlargedBy(30).ToRectangleF();
			rect.With().SameCenter().EnlargedBy(new SizeF(20, 30)).ToRectangleF();
			rect.With().SameCenter().EnlargedBy(20, 30).ToRectangleF();

			rect.With().SameSize().LeftMovedBy(20).TopMovedBy(30).ToRectangleF();
			rect.With().LeftTopMovedBy(20, 30).ToRectangleF();
			var r1 = rect.MovedBy(20, 30);
			var r2 = rect.MovedRightBy(20);
			var r3 = rect.MovedDownBy(30);
		}

		void CornersAndCenters()
		{
			Rect.CreateWith.TopLeft(rect.BottomRight()).Size(10, 20).ToRectangleF();

			rect.CenterX();
			rect.CenterY();
		}
	}
}