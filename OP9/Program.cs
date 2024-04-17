using System;

// Базовый класс для всех фигур
public abstract class Shape
{
    public abstract double Area();
    public abstract void PrintInfo();
}

// Класс для четырехугольника
public abstract class Quadrilateral : Shape
{
    // Длины сторон
    protected double SideA { get; set; }
    protected double SideB { get; set; }
    protected double SideC { get; set; }
    protected double SideD { get; set; }

    // Конструктор
    public Quadrilateral(double a, double b, double c, double d)
    {
        SideA = a;
        SideB = b;
        SideC = c;
        SideD = d;
    }
}

// Класс для треугольника
public abstract class Triangle : Shape
{
    // Длины сторон
    protected double SideA { get; set; }
    protected double SideB { get; set; }
    protected double SideC { get; set; }

    // Конструктор
    public Triangle(double a, double b, double c)
    {
        SideA = a;
        SideB = b;
        SideC = c;
    }
}

// Класс для квадрата
public class Square : Quadrilateral
{
    public Square(double side) : base(side, side, side, side) { }

    public override double Area()
    {
        return SideA * SideA;
    }

    public override void PrintInfo()
    {
        Console.WriteLine("Квадрат:");
        Console.WriteLine($"Сторона: {SideA}");
        Console.WriteLine($"Площадь: {Area()}");
    }
}

// Класс для равнобедренного треугольника
public class IsoscelesTriangle : Triangle
{
    public IsoscelesTriangle(double baseSide, double legs) : base(baseSide, legs, legs) { }

    public override double Area()
    {
        double s = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
    }

    public override void PrintInfo()
    {
        Console.WriteLine("Равнобедренный треугольник:");
        Console.WriteLine($"Основание: {SideA}");
        Console.WriteLine($"Боковая сторона: {SideB}");
        Console.WriteLine($"Площадь: {Area()}");
    }
}

// Класс для прямоугольного треугольника
public class RightTriangle : Triangle
{
    public RightTriangle(double a, double b, double c) : base(a, b, c) { }

    public override double Area()
    {
        return (SideA * SideB) / 2;
    }

    public override void PrintInfo()
    {
        Console.WriteLine("Прямоугольный треугольник:");
        Console.WriteLine($"Катет A: {SideA}");
        Console.WriteLine($"Катет B: {SideB}");
        Console.WriteLine($"Гипотенуза: {SideC}");
        Console.WriteLine($"Площадь: {Area()}");
    }
}

// Класс для равностороннего треугольника
public class EquilateralTriangle : Triangle
{
    public EquilateralTriangle(double side) : base(side, side, side) { }

    public override double Area()
    {
        return (Math.Sqrt(3) / 4) * SideA * SideA;
    }

    public override void PrintInfo()
    {
        Console.WriteLine("Равносторонний треугольник:");
        Console.WriteLine($"Сторона: {SideA}");
        Console.WriteLine($"Площадь: {Area()}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание объектов каждого класса и помещение их в массив
        Shape[] shapes = new Shape[]
        {
            new Square(5),
            new IsoscelesTriangle(4, 6),
            new RightTriangle(3, 4, 5),
            new EquilateralTriangle(5)
        };

        // Вызываем метод Area для каждого объекта и выводим информацию о каждом
        foreach (var shape in shapes)
        {
            shape.PrintInfo();
            Console.WriteLine();
        }
    }
}
