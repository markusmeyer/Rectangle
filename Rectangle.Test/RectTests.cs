using System;
using System.Drawing;
using NUnit.Framework;

namespace Rectangle.Test
{
	[TestFixture]
	public class RectTests
	{
		[Test]
		public void NewlyCreatedObject_ReturnsNullForEverything()
		{
			Assert.AreEqual(null, Rect.CreateWith.GetLeft());
			Assert.AreEqual(null, Rect.CreateWith.GetCenterX());
			Assert.AreEqual(null, Rect.CreateWith.GetRight());
			Assert.AreEqual(null, Rect.CreateWith.GetWidth());
			Assert.AreEqual(null, Rect.CreateWith.GetTop());
			Assert.AreEqual(null, Rect.CreateWith.GetCenterY());
			Assert.AreEqual(null, Rect.CreateWith.GetBottom());
			Assert.AreEqual(null, Rect.CreateWith.GetHeight());
		}

		[Test]
		public void SettingAValue_ReturnsSameValueInGetter()
		{
			Assert.AreEqual(42, Rect.CreateWith.Left(42).GetLeft());
			Assert.AreEqual(42, Rect.CreateWith.CenterX(42).GetCenterX());
			Assert.AreEqual(42, Rect.CreateWith.Right(42).GetRight());
			Assert.AreEqual(42, Rect.CreateWith.Width(42).GetWidth());
			Assert.AreEqual(42, Rect.CreateWith.Top(42).GetTop());
			Assert.AreEqual(42, Rect.CreateWith.CenterY(42).GetCenterY());
			Assert.AreEqual(42, Rect.CreateWith.Bottom(42).GetBottom());
			Assert.AreEqual(42, Rect.CreateWith.Height(42).GetHeight());
		}
			
		[Test]
		public void CopyingAValue_ReturnsSameValueInGetter()
		{
			RectangleF a = new RectangleF(1, 7, 10, 12);
			Assert.AreEqual(a.Left,   Rect.CreateWith.LeftOf(a).GetLeft());
			Assert.AreEqual(6f,       Rect.CreateWith.CenterXOf(a).GetCenterX());
			Assert.AreEqual(a.Right,  Rect.CreateWith.RightOf(a).GetRight());
			Assert.AreEqual(a.Width,  Rect.CreateWith.WidthOf(a).GetWidth());
			Assert.AreEqual(a.Top,    Rect.CreateWith.TopOf(a).GetTop());
			Assert.AreEqual(13f,      Rect.CreateWith.CenterYOf(a).GetCenterY());
			Assert.AreEqual(a.Bottom, Rect.CreateWith.BottomOf(a).GetBottom());
			Assert.AreEqual(a.Height, Rect.CreateWith.HeightOf(a).GetHeight());
		}

		[Test]
		public void LeftTopRightBottom_SetsCorrectValues()
		{
			var a = Rect.CreateWith.LeftTopRightBottom(1, 2, 3, 4);
			Assert.AreEqual(1, a.GetLeft());
			Assert.AreEqual(2, a.GetTop());
			Assert.AreEqual(3, a.GetRight());
			Assert.AreEqual(4, a.GetBottom());
			Assert.AreEqual(RectangleF.FromLTRB(1, 2, 3, 4), a.ToRectangleF());
		}

		[Test]
		public void LeftTopRightBottomOf_SetsCorrectValues()
		{
			var a = Rect.CreateWith.LeftTopRightBottomOf(RectangleF.FromLTRB(1, 2, 3, 4));
			Assert.AreEqual(1, a.GetLeft());
			Assert.AreEqual(2, a.GetTop());
			Assert.AreEqual(3, a.GetRight());
			Assert.AreEqual(4, a.GetBottom());
			Assert.AreEqual(RectangleF.FromLTRB(1, 2, 3, 4), a.ToRectangleF());
		}

		[Test]
		public void LeftTopWidthHeight_SetsCorrectValues()
		{
			var a = Rect.CreateWith.LeftTopWidthHeight(1, 2, 3, 4);
			Assert.AreEqual(1, a.GetLeft());
			Assert.AreEqual(2, a.GetTop());
			Assert.AreEqual(3, a.GetWidth());
			Assert.AreEqual(4, a.GetHeight());
			Assert.AreEqual(new RectangleF(1, 2, 3, 4), a.ToRectangleF());
		}

		[Test]
		public void SettingAProperty_DoesNotAffectOriginalRect()
		{
			Rect rect = Rect.CreateWith.Left(1);
			rect.Left(2);
			Assert.AreEqual(1, rect.GetLeft());
		}

		[Test]
		public void ToRectangleFWithoutInferring_ReturnsCorrectRectangleF()
		{
			Assert.AreEqual(
				new RectangleF(123, 678, 876, 234),
				Rect.CreateWith.Left(123).Top(678).Width(876).Height(234).ToRectangleF());
		}

		[Test]
		public void ToRectangleFWithInferring_ReturnsCorrectRectangleF()
		{
			Assert.AreEqual(
				RectangleF.FromLTRB(123, 234, 987, 765),
				Rect.CreateWith.Left(123).Top(234).Right(987).Bottom(765).ToRectangleF());
		}
			
		[Test]
		public void ToRectangleFWithInferringFromCenter_ReturnsCorrectRectangleF()
		{
			Assert.AreEqual(
				new RectangleF(30, 20, 40, 80),
				Rect.CreateWith.CenterX(50).Width(40).CenterY(60).Height(80).ToRectangleF());
		}

		[Test]
		public void Apply()
		{
			var rect =
				Rect.CreateWith.Left(1).Right(2).Top(3).Bottom(4).Apply(
					Rect.CreateWith.Left(5).Top(6));
			Assert.AreEqual(5, rect.GetLeft());
			Assert.AreEqual(2, rect.GetRight());
			Assert.AreEqual(6, rect.GetTop());
			Assert.AreEqual(4, rect.GetBottom());
		}
	}
}