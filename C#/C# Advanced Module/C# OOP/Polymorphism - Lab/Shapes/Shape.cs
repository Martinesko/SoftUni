using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{

    public abstract class Shape
    {
        public abstract double CalculatePerimeter();
        public abstract double CalculateArea();
        public virtual string Draw()
        {
            return "Drawing ";
        }
    }
    public class Rectangle : Shape
    {
        public double Height { get; protected set; }
        public double Width { get; protected set; }

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }
        public override double CalculateArea()
        {
            return (this.Height * this.Width);
        }

        public override double CalculatePerimeter()
        {
            return (this.Height * 2) + (this.Width * 2);
        }
        public override string Draw()
        {
            return base.Draw() + "Rectangle";
        }
    }
    public class Circle : Shape
    {
        public double Radius { get; protected set; }
        public Circle(double radius)
        {
            this.Radius = radius;
        }
        public override double CalculateArea()
        {
            return Math.PI * (this.Radius * this.Radius);
        }

        public override double CalculatePerimeter()
        {
            return (2*Math.PI) * this.Radius;
        }
        public override string Draw()
        {
            return base.Draw() + "Circle";
        }
    }
}
