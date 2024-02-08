using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning05 World!");

        Square square = new Square("Blue",25);
        Rectangle rectangle = new Rectangle("Yellow",15,35);
        Circle circle = new Circle("Red", 30);
        
        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach(Shape shape in shapes){
            Console.WriteLine($"{shape.GetColor()} - {shape.GetArea()}");
        }




    }
}