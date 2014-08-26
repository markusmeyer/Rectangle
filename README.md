Rectangle
=========

These are some helper classes for handling rectangles comfortably.

RectangleF only has only a constructor which takes top / left coordinates and width / height and a static method which takes top / left / bottom / right coordinates.

With the Rect class you can combine a range of different possibilities to specify parts of a rectangle.

Example:

	RectangleF rect1 = new Rectangle(10, 20, 30, 40);
	RectangleF rect2 = 
		Rect.CreateWith()
		.Top(30)
		.Bottom(60)
		.CenterXOf(rect1)
		.RelativeWidthOf(rect1, 2)
		.ToRectangleF();
