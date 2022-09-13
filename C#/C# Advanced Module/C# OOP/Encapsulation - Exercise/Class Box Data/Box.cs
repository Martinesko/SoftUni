using System;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;
        public double Length
        {
            get { return this.length; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }
                else
                {
                    this.length = value;
                }
            }
        }
        public double Width
        {
            get { return this.width; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }
                else
                {
                    this.width = value;
                }
            }
        }
        public double Height
        {
            get { return this.height; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }
                else
                {
                    this.height = value;
                }
            }
        }
        public Box(double length , double width , double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        public double SurfaceArea()
        {
            return 2 * (this.Width * this.Length) + 2 * (this.Height * this.Length) + 2 * (this.Width * this.Height);
        }
        public double LateralSurfaceArea()
        {
            return 2 * ((this.Height * this.Length)) + (2 * (this.Width * this.Height));
        }
        public double Volume()
        {
            return this.Length * this.Width * this.Height;
        }
        static void Main()
        {
            try
            {
                double l = double.Parse(Console.ReadLine());
                double w = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());
                Box box = new Box(l, w, h);
                Console.WriteLine($"Surface Area - {box.SurfaceArea():F2}");
                Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():f2}");
                Console.WriteLine($"Volume - {box.Volume():f2}");
            }
            catch (Exception ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

    }
}
