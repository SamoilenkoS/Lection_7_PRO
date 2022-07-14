using System;
using System.Collections.Generic;

namespace Lection_7_PRO
{
    public enum Colors
    {
        Red = 100,
        Green = 50,
        Blue = 43
    }

    public enum Units
    {
        Gram = 1,
        Kilogram = 1_000,
        Tonn = 1_000_000
    }

    public struct Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"{nameof(X)}={X} {nameof(Y)}={Y}";
        }
    }

    public class Cat
    {
        public string DoSong()
        {
            return "Meow-meow";
        }
    }

    public interface IShape
    {
        double GetPerimetr();
        double GetSquare();
    }

    public class Rectangle : IShape
    {
        private double _a;
        private double _b;

        public double A => _a;
        public double B => _b;

        public Rectangle(double a, double b)
        {
            if(a > 0 && b > 0)
            {
                _a = a;
                _b = b;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public double GetPerimetr()
        {
            return 2 * (A + B);
        }

        public double GetSquare()
        {
            return A * B;
        }
    }

    public class Triangle : IShape
    {
        private double _a;
        private double _b;
        private double _c;

        public Triangle(double a, double b, double c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        public double GetPerimetr()
        {
            return _a + _b + _c;
        }

        public double GetSquare()
        {
            double p = GetPerimetr() / 2;

            return Math.Sqrt(p * (p - _a) *(p - _b) * (p - _c));
        }
    }

    public abstract class Car
    {
        private int _maxSpeed;

        public int MaxSpeed
        {
            get
            {
                return _maxSpeed;
            }
        }

        public Car(int maxSpeed)
        {
            if(maxSpeed > 0)
            {
                _maxSpeed = maxSpeed;
            }
            else
            {
                throw new ArgumentException("Speed is too low!");
            }
        }

        public virtual string Sound()
        {
            return "Brrrrrr!";
        }
    }

    public class SportCar : Car
    {
        public SportCar() : base(500)
        {
        }

        public override string Sound()
        {
            return "FFFFFFfffff1!";
        }
    }

    public class Bus : Car
    {
        public Bus() : base(150)
        {

        }

        public override string Sound()
        {
            return "uuuuuu";
        }
    }

    public class DefaultCar : Car
    {
        public DefaultCar() : base(100)
        {
        }
    }

    class Program
    {
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void Main(string[] args)
        {
            Car[] cars = new Car[3];
            cars[0] = new SportCar();
            cars[1] = new Bus();
            cars[2] = new DefaultCar();

            foreach(var car in cars)
            {
                Console.WriteLine(car.GetType());
                Console.WriteLine(car.MaxSpeed);
                Console.WriteLine(car.Sound());
                Console.WriteLine();
            }
        }

        static void InterfaceExample()
        {
            IShape[] shapes = new IShape[2];
            shapes[0] = new Rectangle(4, 5);
            shapes[1] = new Triangle(3, 4, 5);

            double total = 0;
            foreach (var shape in shapes)
            {
                total += shape.GetPerimetr();
            }

            Console.WriteLine(total);
        }

        static void PrintInfo(IShape shape)
        {
            if (shape != null)
            {
                Console.WriteLine(shape.GetPerimetr() + shape.GetSquare());
            }
        }

        static void ClassExample()
        {
            Dog sharik = new Dog("Sharik");
            Dog bobik = new Dog("Bobik");
            Dog newDog = new Dog();

            Console.WriteLine(Dog.DogsCount);
            Console.WriteLine(sharik.DoSong());
        }

        static void StructExample1()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5 };

            var currentCoordinates =
               new Coordinates
               {
                   X = 10,
                   Y = 50
               };

            Update(ref currentCoordinates);

            Console.WriteLine(currentCoordinates);
        }

        static void Update(ref Coordinates coordinates)
        {
            coordinates.X *= 2;
            coordinates.Y *= 2;
        }

        static void EnumExample1()
        {
            foreach (var color in Enum.GetValues<Colors>())
            {
                Console.WriteLine(color);
            }

            Console.Write("Please select color:");
            string input = Console.ReadLine();
            if (Enum.TryParse<Colors>(input, out var result))
            {
                switch (result)//alt + enter
                {
                    case Colors.Red:
                        Console.WriteLine("You choise is usual!");
                        break;
                    case Colors.Green:
                        Console.WriteLine("You choise asdasdasd");
                        break;
                    case Colors.Blue:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Incorrect!");
            }
        }

        static void EnumExample2()
        {
            Units sourceUnits = Enum.Parse<Units>(Console.ReadLine());
            int sourceAmount = Convert.ToInt32(Console.ReadLine());

            Units destUnits = Enum.Parse<Units>(Console.ReadLine());
            double destAmount = sourceAmount * (int)sourceUnits / (double)destUnits;

            Console.WriteLine(destAmount);
        }
    }
}
