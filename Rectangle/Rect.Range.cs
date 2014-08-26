using System;

namespace Rectangle
{
	public partial class Rect
	{
		enum Dimension
		{ 
			Horizontal, 
			Vertical
		};

		struct Range
		{
			readonly Dimension dimension;
			public float? Low;
			public float? Middle;
			public float? High;
			public float? Length;

			public Range(Dimension dimension)
			{
				this.dimension = dimension;
				Low = null;
				Middle = null;
				High = null;
				Length = null;
			}

			public void InferLowAndLength()
			{
				EnsureNotUnderOrOverspecified();

				if (Length != null)
				{
					if (High != null) // Length, High -> !Low, !Mid
					{
						Low = High - Length;
					}
					else // Length, !High
					{
						if (Middle != null) // Length, !High, Mid -> !Low
						{
							Low = Middle - Length / 2;
						}
						else // Length, !High, !Mid -> Low
						{ 
							// nothing to be done
						}
					}
				}
				else // !Length
				{
					if (High != null) // !Length, High
					{
						if (Low != null) // !Length, High, Low
						{
							Length = High - Low;
						}
						else // !Length, High, !Low -> Middle
						{
							Length = (High - Middle) * 2;
							Low = High - Length;
						}
					}
					else // !Length, !High -> Middle, Low
					{
						Length = (Middle - Low) * 2;
					}
				}
			}

			void EnsureNotUnderOrOverspecified()
			{
				int specCount = OneIfHasValue(Low) + OneIfHasValue(Middle) + OneIfHasValue(High) + OneIfHasValue(Length);
				if (specCount < 2)
					throw new InvalidOperationException(dimension + " dimension underspecified");
				if (specCount > 2)
					throw new InvalidOperationException(dimension + " dimension overspecified");
			}

			int OneIfHasValue(float? value)
			{
				return value.HasValue ? 1 : 0;
			}
		}
	}
}