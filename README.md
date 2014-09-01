Rectangle
=========

These are some helper classes and extension methods for handling rectangles comfortably.

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

### Modify rectangles

If you want to modify a rectangle, let's say

	var rect = new RectangleF(10, 20, 30, 40);

you could create a new Rect, copy the things which should remain the same, and change the others:

	Rect.CreateWith.TopOf(rect).RightOf(rect).HeightOf(rect).Width(100).ToRectangleF()

But this is a bit lenghty and cumbersome. With the use of another helper class you can write

	rect.With().SameTop().SameRight().SameHeight().Width(100).ToRectangleF()

The With extension method on RectangleF saves the original rectangle and you can transfer the desired 
specifications just by calling the Same... methods. 

Following example relocates the top left corner of the rectangle:

	rect.With().SameSize().Top(20).Left(30).ToRectangleF();

### Even shorter

	rect.With().SameTop().SameRight().SameHeight().Width(100).ToRectangleF()

is still a bit lengthy, and can be written shorter as

	rect.With().SameRight().Width(100).ToRectangleF()

So, as an exception to the above rule that for every dimension exactly two specifications have to be provided, 
you can provide *zero* specifcations for a dimension, i.e. omitting the dimension as a whole.
It will be transferred to the new RectangleF as it was in the original RectangleF.

Note that in the above example it would not be enough to only change the width:

	rect.With().Width(100).ToRectangleF()
	
It's not specified which part of the horizontal range should remain the same: the left, the middle or the right.
Hence, in this case an exception is thrown stating that the dimension is underspecified.

Some more examples with just one dimension changed:

	rect.With().SameWidth().Left(30).ToRectangleF()
	rect.With().Right(10).Width(20).ToRectangleF()

### Relative sizes

For convenience, you can multiply the sizes of the original rectangle:

	rect.With().SameCenter().RelativeHeight(.5f).RelativeWidth(.5f).ToRectangleF()
	rect.With().SameCenter().RelativeSize(.5f).ToRectangleF()

### Addition

Or you can add some value to any of the original rectangle.

This code moves the lop left corner while the bottom right corner remains fixed:

	rect.With().SameRight().SameBottom().AddToLeft(10).AddToTop(20).ToRectangleF()

All 3 alternatives fix the center while enlarging the rectangle:

	rect.With().SameCenter().EnlargeHorizontally(20).EnlargeVertically(30).ToRectangleF();
	rect.With().SameCenter().Enlarge(new SizeF(20, 30)).ToRectangleF();
	rect.With().SameCenter().Enlarge(20, 30).ToRectangleF();

This moves the rectangle:

	rect.With().SameSize().AddToRight(20).AddToTop(30).ToRectangleF();

### Move

Because writing the above line just to move a rectange is still too much code (and choosing a corner for adding the offset is
redundant), I have added extension methods for RectangleF directly, which are just for the task of moving it:

	rect.Move(20, 30);
	rect.MoveRight(20);
	rect.MoveDown(30);

### Corners and Centers

Some more extension methods to RectangleF return the corners of the rectangle:

	rect.TopLeft()
	rect.BottomRight()

They also can be used with the Rect methods:

	Rect.CreateWith.TopLeft(rect.BottomRight()).Size(10, 20).ToRectangleF();

Finally, there are two extension methods to return the center coordinates of a rectangle:

	rect.CenterX()
	rect.CenterY()
