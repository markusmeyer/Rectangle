using System;
using System.Drawing;

namespace Rectangle
{
	public partial class Rect
	{
		protected Range xRange;
		protected Range yRange;

		public Rect()
		{
			xRange = new Range(Dimension.Horizontal);
			yRange = new Range(Dimension.Vertical);
		}

		public Rect(Rect other)
		{
			xRange = other.xRange;
			yRange = other.yRange;
		}

		// Basic getters

		public float? GetLeft()
		{
			return xRange.Low;
		}

		public float? GetCenterX()
		{
			return xRange.Middle;
		}

		public float? GetRight()
		{
			return xRange.High;
		}

		public float? GetWidth()
		{
			return xRange.Length;
		}

		public float? GetTop()
		{
			return yRange.Low;
		}

		public float? GetCenterY()
		{
			return yRange.Middle;
		}

		public float? GetBottom()
		{
			return yRange.High;
		}

		public float? GetHeight()
		{
			return yRange.Length;
		}

		// Basic setters

		void SetLeft(float value)
		{
			xRange.Low = value;
		}

		void SetCenterX(float value)
		{
			xRange.Middle = value;
		}

		void SetRight(float value)
		{
			xRange.High = value;
		}

		void SetWidth(float value)
		{
			xRange.Length = value;
		}

		void SetTop(float value)
		{
			yRange.Low = value;
		}

		void SetCenterY(float value)
		{
			yRange.Middle = value;
		}

		void SetBottom(float value)
		{
			yRange.High = value;
		}

		void SetHeight(float value)
		{
			yRange.Length = value;
		}

		public static Rect CreateWith 
		{
			get { return new Rect(); }
		}

		public virtual Rect Clone()
		{
			return new Rect(this);
		}

		public Rect Apply(Rect other)
		{
			Rect result = Clone();
			result.xRange.Apply(other.xRange);
			result.yRange.Apply(other.yRange);
			return result;
		}

		public virtual RectangleF ToRectangleF()
		{
			xRange.InferLowAndLength();
			yRange.InferLowAndLength();
			var result = new RectangleF(
				xRange.Low.Value, 
				yRange.Low.Value, 
				xRange.Length.Value, 
				yRange.Length.Value);
			return result;
		}
	}
}