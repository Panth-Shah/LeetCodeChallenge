using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LeetCodeProblems_March
{
    public class Day17_GenerateRandomPointsInCircle
    {
        private readonly double r;
        private readonly double x;
        private readonly double y;
        private readonly Random rand;
        public Day17_GenerateRandomPointsInCircle(double radius, double x_center, double y_center)
        {
            this.r = radius;
            this.x = x_center;
            this.y = y_center;
            rand = new Random();
        }

        public double[] RandPoint()
        {
            double theta = rand.NextDouble() * 2 * Math.PI,
                hyp = Math.Sqrt(rand.NextDouble()) * r,
                adj = Math.Cos(theta) * hyp,
                opp = Math.Sin(theta) * hyp;

            return new double[] { x + adj, y + opp};
        }
    }
}
