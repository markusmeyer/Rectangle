using System;
using NUnit.Framework;

namespace Rectangle
{
	class RangeTests
	{
		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void SpecifyingNothing_ThrowsException()
		{
			new Rect.Range().InferLowAndLength();
		}

		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void JustSpecifyingLow_ThrowsException()
		{
			new Rect.Range{Low = 1}.InferLowAndLength();
		}

		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void JustSpecifyingHigh_ThrowsException()
		{
			new Rect.Range{High = 1}.InferLowAndLength();
		}

		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void JustSpecifyingLength_ThrowsException()
		{
			new Rect.Range{Length = 1}.InferLowAndLength();
		}

		[Test]
		public void SpecifyingLowAndMiddle_InfersLength()
		{
			var r = new Rect.Range{Low = 1, Middle = 3};
			r.InferLowAndLength();
			Assert.That(r.Low, Is.EqualTo(1f));
			Assert.That(r.Length, Is.EqualTo(4f));
		}

		[Test]
		public void SpecifyingLowAndHigh_InfersLength()
		{
			var r = new Rect.Range{Low = 1, High = 3};
			r.InferLowAndLength();
			Assert.That(r.Low, Is.EqualTo(1f));
			Assert.That(r.Length, Is.EqualTo(2f));
		}

		[Test]
		public void SpecifyingLowAndLength_ReturnsSameValuesAfterInferring()
		{
			var r = new Rect.Range{Low = 1, Length = 3};
			r.InferLowAndLength();
			Assert.That(r.Low, Is.EqualTo(1f));
			Assert.That(r.Length, Is.EqualTo(3f));
		}

		[Test]
		public void SpecifyingMiddleAndHigh_InfersLowAndLength()
		{
			var r = new Rect.Range{Middle = 3, High = 5};
			r.InferLowAndLength();
			Assert.That(r.Low, Is.EqualTo(1f));
			Assert.That(r.Length, Is.EqualTo(4f));
		}

		[Test]
		public void SpecifyingMiddleAndLength_InfersLow()
		{
			var r = new Rect.Range{Middle = 5, Length = 4};
			r.InferLowAndLength();
			Assert.That(r.Low, Is.EqualTo(3f));
			Assert.That(r.Length, Is.EqualTo(4f));
		}

		[Test]
		public void SpecifyingHighAndLength_InfersLow()
		{
			var r = new Rect.Range{High = 5, Length = 3};
			r.InferLowAndLength();
			Assert.That(r.Low, Is.EqualTo(2f));
			Assert.That(r.Length, Is.EqualTo(3f));
		}

		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void SpecifyingTooMuch_ThrowsException()
		{
			new Rect.Range{Low = 1, High = 2, Length = 3}.InferLowAndLength();
		}

		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void SpecifyingTooMuch_ThrowsException_EvenIfConsistent()
		{
			new Rect.Range{Low = 1, High = 2, Length = 1}.InferLowAndLength();
		}
	}
}