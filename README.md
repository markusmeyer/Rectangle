Rectangle
=========

This is a helper class for handling rectangles comfortably.

### RectangleF

RectangleF provides only two methods to specify a rectangle: 

By constructor: 

	new RectangleF(10, 20, 30, 40)

which takes top and left coordinates and width and height.

By static method: 

	RectangleF.FromLTRB(10, 20, 30, 40)

which takes left, top, right and bottom coordinates.

But often you want to specify the horizontal dimension differently from the vertical one, or specify the center and width / height, or the width and right coordinate, for example.
To avoid the cumbersome task of calculating the required parameters from the given ones each time, I created the Rect helper class.

### Rect

With the Rect class you can specify a rectangle in a very flexible way:

For each dimension, two out of four possible specifications are made. For the horizontal dimension, this can be left, center, right and width. For the vertical dimension it can be top, center, bottom and height.

In the following example, we specify bottom coordinate, height, horizontal center coordinate and the width:

	Rect.CreateWith.Bottom(40).Height(10).CenterX(20).Width(30).ToRectangleF()

### Too much, too little?

If you there is just one or none specification per dimension, the range for a dimension is not defined. If you specify more than two things, they could contradict each other. In both cases, you will get an exception when you try to convert to RectangleF, but whether the right count of specifications has been provided can easily be seen from the source code.

Following example will fail to execute, because the horizontal dimension is overspecified (left and right coordinate and width is given) and the vertical dimension is underspecified (only top coordinate is given):

	Rect.CreateWith.Left(10).Right(20).Width(30).Top(40).ToRectangleF()

Specifying the same thing twice is no problem, however:

	Rect.CreateWith.Left(10).Right(20).Top(30).Bottom(40).Left(20).ToRectangleF()

### More flexible ways

As an alternative to providing direct coordinates or lengths, you can exctract them from other rectangles, points or sizes.

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

### More features

If you want to query again what you just set, you can do that as follows:

	Rect rect = Rect.CreateWith.Left(20);
	float left = rect.GetLeft().Value;

If you want to use the same partial specifications to create two different rectangles, you can do this as follows:

	Rect rect = Rect.CreateWith.Left(10).Right(20).Top(30);
	RectangleF rect1 = rect.Bottom(40).ToRectangleF();
	RectangleF rect2 = rect.Bottom(50).ToRectangleF();

### Pointer semantics, but immutable

RectangleF is a struct and thus has value semantics. Rect is a class and has pointer semantics. In order to be able to use a partial specification for different rectangles, the class is immutable and creates another instance for each modification operation.

Because of the immutability, you can do the following:

	Rect rect = Rect.CreateWith.Left(10).Right(20).Top(30).Bottom(40);
	RectangleF rect2 = rect.Left(50).ToRectangleF();
	RectangleF rect3 = rect.Right(60).ToRectangleF();

rect3.Left then will be the original 10 as expected, not 50.
