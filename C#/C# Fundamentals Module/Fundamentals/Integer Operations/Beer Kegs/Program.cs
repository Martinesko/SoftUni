using System;

namespace Beer_Kegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double maxVolume = double.MinValue;
            string maxVolumeModel = String.Empty;
            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double r = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());
                if (Math.PI * Math.Pow(r, 2) * h > maxVolume)
                {
                    maxVolume = Math.PI * Math.Pow(r, 2) * h;
                    maxVolumeModel = model;
                }
            }
            Console.WriteLine(maxVolumeModel);
        }
    }
}
