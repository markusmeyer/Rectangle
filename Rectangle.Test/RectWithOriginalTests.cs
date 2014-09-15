using System;
using System.Drawing;
using NUnit.Framework;

namespace Rectangle
{
	[TestFixture]
	public class RectWithOriginalTests
	{
		[Test]
		public void NoModification_ReturnsOriginalRectangle()
		{
			RectangleF a = new RectangleF(1, 7, 17, 31);
			Assert.AreEqual(a, a.With().ToRectangleF());
		}

		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void JustOneHorizontalSpecification_ThrowsAnException()
		{
			new RectangleF(1, 7, 17, 31).With().Left(2).ToRectangleF();
		}

		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void JustOneVerticalSpecification_ThrowsAnException()
		{
			new RectangleF(1, 7, 17, 31).With().Top(2).ToRectangleF();
		}

		[Test]
		public void SpecifyingEverything_OverwritesOriginalRectangleCompletely()
		{
			RectangleF a = new RectangleF(1, 7, 17, 31);
			RectangleF b = a.With().Left(2).Top(3).Width(4).Height(5).ToRectangleF();
			Assert.AreEqual(2, b.Left);
			Assert.AreEqual(3, b.Top);
			Assert.AreEqual(4, b.Width);
			Assert.AreEqual(5, b.Height);
		}

		[Test]
		public void UsingBasicValuesFromOriginalRectangle_Works()
		{
			RectangleF a = new RectangleF(1, 7, 10, 12);
			Assert.AreEqual(a.Left, a.With().SameLeft().GetLeft());
			Assert.AreEqual(6f, a.With().SameCenterX().GetCenterX());
			Assert.AreEqual(a.Right, a.With().SameRight().GetRight());
			Assert.AreEqual(a.Width, a.With().SameWidth().GetWidth());
			Assert.AreEqual(a.Top, a.With().SameTop().GetTop());
			Assert.AreEqual(13f, a.With().SameCenterY().GetCenterY());
			Assert.AreEqual(a.Bottom, a.With().SameBottom().GetBottom());
			Assert.AreEqual(a.Height, a.With().SameHeight().GetHeight());
		}

		[Test]
		public void CopyingEverythingFromOriginalRectangle_Works()
		{
			RectangleF a = new RectangleF(1, 7, 10, 12);
			Assert.AreEqual(a, a.With().SameLeft().SameRight().SameTop().SameBottom().ToRectangleF());
		}
	}
}

