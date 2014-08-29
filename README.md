Rectangle
=========

These are some helper classes for handling rectangles comfortably.

RectangleF provides only two methods two specify the rectangle: 

By constructor: 

	new RectangleF(10, 20, 30, 30)

which takes top and left coordinates and width and height.

By static method: 

	RectangleF.FromLTRB(10, 20, 30, 40)

which takes left, top, right and bottom coordinates.

But often you want to specify the horizontal dimension differently from the vertical one, or specify the center and width / height, or the width and right coordinate, for example.
To avoid the cumbersome task of calculating the required parameters from the given ones each time, I created the Rect helper class.

With the Rect class you can specify a rectangle in a very flexible way:

For each dimension, two out of four possible specifications are made. For the horizontal dimension, these are left, center, right and width. For the vertical dimension it's top, center, bottom and height.

In the following example, we specify bottom coordinate, height, horizontal center coordinate and the width:

	Rect.CreateWith().Bottom(40).Height(10).CenterX(20).Width(30).ToRectangleF()

If you there is just one or none specification per dimension, the range for a dimension is not defined. If you specify more than two things, the range is inconsistent. In both cases, you will get an exception when you try to convert to RectngleF, but whether the right count of specifications has been provided can easily be seen from the source code.

Following example will fail to execute, because the horizontal dimension is overspecified (left and right coordinate and width is given) and the vertical dimension is underspecified (only top coordinate is given):

	Rect.CreateWith().Left(10).Right(20).Width(30).Top(40).ToRectangleF()

Specifying the same thing twice is no problem, however:

	Rect.CreateWith().Left(10).Right(20).Top(30).Bottom(40).Left(20).ToRectangleF()

As an alternative to providing direct coordinates or lengths, you can exctract them from other rectangles, points or sizes.

	RectangleF rect1 = new RectangleF(10, 20, 30, 40);
	PointF point = new PointF(50, 60);
	SizeF size = new SizeF(70,80);

	RectangleF rect2 = 
		Rect.CreateWith()
		.TopLeft(point)
		.RightOf(rect1)
		.RelativeHeightOf(rect1, 2)
		.ToRectangleF();

	RectangleF rect3 = 
		Rect.CreateWith()
		.Size(size)
		.AtRightOf(rect1)
		.AtBottomOf(rect1)
		.ToRectangleF();

In fact, there are two classes, not just one, to get all this done. One is Rect, the other is RectModifier.

Rect itself is immutable and holds the specifications, RectModifier provides means to change the spedifications.
You create a RectModifiert by calling With on a existing Rect or Rect.CreateWith() to create both the Rect and modifier objects.

If you want to query again what you just set, you can do that as follows:

	Rect rect = Rect.CreateWith().Left(20).Rect;
	float left = rect.Left.Value;

If you want to use the same partial specifications to create two different rectangles, you can do this as follows:

	Rect rect = Rect.CreateWith().Left(10).Right(20).Top(30).Rect;
	RectangleF rect1 = rect.With.Bottom(40).ToRectangleF();
	RectangleF rect2 = rect.With.Bottom(50).ToRectangleF();
