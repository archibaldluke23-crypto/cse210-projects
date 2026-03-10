using System;

class Program
{
    static void Main(string[] args)
    {
        
        Square square1 = new Square("blue", 5);
        Rectangle rectangle1 = new Rectangle("yellow", 5, 4);
        Circle circle1 = new Circle("green", 5);

        List<Shape> shapes = new List<Shape>();
        shapes.Add(square1);
        shapes.Add(rectangle1);
        shapes.Add(circle1);
        
        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());
        }
        

    }
}