using System;
using System.Drawing;

namespace Rectangle
{
	public partial class Rect
	{
		Range xRange;
		Range yRange;

		public float? Left
		{
			get { return xRange.Low; }
			private set { xRange.Low = value; }
		}

		public float? CenterX
		{
			get { return xRange.Middle; }
			private set { xRange.Middle = value; }
		}

		public float? Right
		{
			get { return xRange.High; }
			private set { xRange.High = value; }
		}

		public float? Width
		{
			get { return xRange.Length; }
			private set { xRange.Length = value; }
		}

		public float? Top
		{
			get { return yRange.Low; }
			private set { yRange.Low = value; }
		}

		public float? CenterY
		{
			get { return yRange.Middle; }
			private set { yRange.Middle = value; }
		}

		public float? Bottom
		{
			get { return yRange.High; }
			private set { yRange.High = value; }
		}

		public float? Height
		{
			get { return yRange.Length; }
			private set { yRange.Length = value; }
		}

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

		public static RectModifier CreateWith()
		{
			return new RectModifier(new Rect());
		}

		public RectModifier With
		{
			get { return new RectModifier(this); }
		}

		public Rect Clone()
		{
			return new Rect(this);
		}

		public RectangleF ToRectangleF()
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