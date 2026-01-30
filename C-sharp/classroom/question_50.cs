using System;

interface IArea
{
    double GetArea();
}

abstract class Shape : IArea
{
    public abstract double GetArea();
}

class Circle : Shape
{
    double r;
    public Circle(double r) { this.r = r; }
    public override double GetArea() => Math.PI * r * r;
}

class Rectangle : Shape
{
    double w, h;
    public Rectangle(double w, double h) { this.w = w; this.h = h; }
    public override double GetArea() => w * h;
}

class Triangle : Shape
{
    double b, h;
    public Triangle(double b, double h) { this.b = b; this.h = h; }
    public override double GetArea() => 0.5 * b * h;
}

class ShapesArea
{
    static double TotalArea(string[] shapes)
    {
        double total = 0;

        foreach (string s in shapes)
        {
            string[] p = s.Split(' ');
            Shape shape = null;

            if (p[0] == "C")
                shape = new Circle(double.Parse(p[1]));
            else if (p[0] == "R")
                shape = new Rectangle(double.Parse(p[1]), double.Parse(p[2]));
            else if (p[0] == "T")
                shape = new Triangle(double.Parse(p[1]), double.Parse(p[2]));

            if (shape != null)
                total += shape.GetArea();
        }

        return Math.Round(total, 2, MidpointRounding.AwayFromZero);
    }

    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] shapes = new string[n];

        for (int i = 0; i < n; i++)
            shapes[i] = Console.ReadLine();

        Console.WriteLine(TotalArea(shapes));
    }
}
