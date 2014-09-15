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

		[Test]
		public void ApplyingOtherRangeWithLow_CopiesThisValue()
		{
			var range = new Rect.Range{Low = 42};
			range.Apply(new Rect.Range{Low = 43});
			Assert.AreEqual(43, range.Low);
		}

		[Test]
		public void ApplyingOtherRangeWithMiddle_CopiesThisValue()
		{
			var range = new Rect.Range{Middle = 42};
			range.Apply(new Rect.Range{Middle = 43});
			Assert.AreEqual(43, range.Middle);
		}

		[Test]
		public void ApplyingOtherRangeWithHigh_CopiesThisValue()
		{
			var range = new Rect.Range{High = 42};
			range.Apply(new Rect.Range{High = 43});
			Assert.AreEqual(43, range.High);
		}

		[Test]
		public void ApplyingOtherRangeWithLength_CopiesThisValue()
		{
			var range = new Rect.Range{Length = 42};
			range.Apply(new Rect.Range{Length = 43});
			Assert.AreEqual(43, range.Length);
		}

		[Test]
		public void ApplyingOtherRangeWithUnspecifiedLow_DoesntChangeValue()
		{
			var range = new Rect.Range{Low = 42};
			range.Apply(new Rect.Range{Middle = 43, High = 44, Length = 45});
			Assert.AreEqual(42, range.Low);
		}

		[Test]
		public void ApplyingOtherRangeWithUnspecifiedMiddle_DoesntChangeValue()
		{
			var range = new Rect.Range{Middle = 42};
			range.Apply(new Rect.Range{Low = 43, High = 44, Length = 45});
			Assert.AreEqual(42, range.Middle);
		}

		[Test]
		public void ApplyingOtherRangeWithUnspecifiedHigh_DoesntChangeValue()
		{
			var range = new Rect.Range{High = 42};
			range.Apply(new Rect.Range{Low = 43, Middle = 44, Length = 45});
			Assert.AreEqual(42, range.High);
		}

		[Test]
		public void ApplyingOtherRangeWithUnspecifiedLength_DoesntChangeValue()
		{
			var range = new Rect.Range{Length = 42};
			range.Apply(new Rect.Range{Low = 43, Middle = 44, High = 45});
			Assert.AreEqual(42, range.Length);
		}
	}
}