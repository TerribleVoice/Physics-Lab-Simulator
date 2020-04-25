using System;

namespace MathModel
{
    public class GDO
    {
        private const int ArraySize = 2000;
        public double R0 { get; }
        public double L { get; }
        public double C { get; }

        public int R100 { get; set; }
        public int R10 { get; set; }
        public double Phase0 { get; }

        public GDO()
        {
            var rnd = new Random();
            R0 = rnd.Next(18, 22); // 20 ± 2 om
            L = rnd.Next(9, 11) * 0.001; // 0,01 ± 0,001 Gn
            C = rnd.Next(45, 55) * Math.Pow(10, -9); // 5 ± 0,5 *10^-8 F
            Phase0 = rnd.Next(785, 1133) * -0.001; // –0,959 ± 0,174 rad
        }

        public Point[] Generate(double step)
        {
            var r = 100 * R100 + 10 * R10 + R0;
            var beta = r / (2 * L);
            var omega0 = 1 / Math.Sqrt(L * C);
            var omega = Math.Sqrt(omega0 * omega0 + beta * beta);
            var result = new Point[ArraySize];

            for (var i = 0; i < ArraySize; i++)
            {
                var t = step * i;
                var point = new Point(t, GetY(t, omega, beta));

                result[i] = point;
            }

            return result;
        }

        public double GetY(double t, double omega, double beta)
        {
            return 0.9 * Math.Pow(Math.E, -beta * t / 1000) * Math.Cos(omega * t / 1000 + Phase0);
        }

    }
}