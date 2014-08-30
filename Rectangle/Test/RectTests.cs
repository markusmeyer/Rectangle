using System;
using System.Drawing;
using NUnit.Framework;

namespace Rectangle
{
	[TestFixture]
	public class RectTests
	{
		[Test]
		public void Test1()
		{
			Assert.AreEqual(
				new RectangleF(123, 678, 876, 234),
				Rect.CreateWith
				.Left(123).Width(876)
				.Top(678).Height(234).ToRectangleF());
		}

		[Test]
		public void Test2()
		{
			Assert.AreEqual(
				RectangleF.FromLTRB(123, 234, 987, 765), 
				Rect.CreateWith
				.Left(123).Right(987)
				.Top(234).Bottom(765)
				.ToRectangleF());
		}
			
		[Test]
		public void Test3()
		{
			Assert.AreEqual(
				new RectangleF(30, 20, 40, 80),
				Rect.CreateWith
				.CenterX(50).Width(40)
				.CenterY(60).Height(80)
				.ToRectangleF());
		}
			
		[Test]
		public void Test4()
		{
			RectangleF a = new RectangleF(1, 7, 17, 31);
			Assert.AreEqual(
				a,
				Rect.CreateWith
				.LeftOf(a).RightOf(a)
				.TopOf(a).BottomOf(a)
				.ToRectangleF());
		}
			
		[Test]
		public void Test5()
		{
			RectangleF a = new RectangleF(1, 7, 17, 31);
			Assert.AreEqual(
				a,
				Rect.CreateWith
				.LeftOf(a).WidthOf(a)
				.TopOf(a).HeightOf(a)
				.ToRectangleF());
		}
			
		[Test]
		public void Test6()
		{
			RectangleF a = new RectangleF(1, 7, 17, 31);
			Assert.AreEqual(
				a,
				Rect.CreateWith
				.RightOf(a).WidthOf(a)
				.BottomOf(a).HeightOf(a)
				.ToRectangleF());
		}
			
		[Test]
		public void Test7()
		{
			RectangleF a = new RectangleF(1, 7, 17, 31);
			Assert.AreEqual(
				a,
				Rect.CreateWith
				.CenterXOf(a).WidthOf(a)
				.CenterYOf(a).HeightOf(a)
				.ToRectangleF());
		}

		[Test]
		public void Test8()
		{
			Rect rect2 = Rect.CreateWith.Left(1).Right(2).Top(3).Bottom(4);
			Rect rect3 = rect2.Left(5);
			Assert.AreEqual(RectangleF.FromLTRB(1, 3, 2, 4), rect2.ToRectangleF());
		}

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
		public void SettingAValue_ReturnsSameValueAsPropertyOfRect()
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
			var a = Rect.CreateWith.LeftTopRightBottom(1, 2, 3, 4);
			Assert.AreEqual(1, a.GetLeft());
			Assert.AreEqual(2, a.GetTop());
			Assert.AreEqual(3, a.GetRight());
			Assert.AreEqual(4, a.GetBottom());
			Assert.AreEqual(RectangleF.FromLTRB(1, 2, 3, 4), a.ToRectangleF());
		}
	}
}