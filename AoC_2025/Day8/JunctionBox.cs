using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public class JunctionBox
    {
        public readonly int X;
        public readonly int Y;
        public readonly int Z;
        private JunctionBox _closestJunctionBox;
        private double _distanceToClosestJunctionBox = double.MaxValue;

        public JunctionBox(int x, int y, int z) 
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double CalculateDistanceToOtherJunctionBox(JunctionBox otherJunctionBox)
        {
            var xDeltaSq = Math.Pow(X - otherJunctionBox.X, 2);
            var yDeltaSq = Math.Pow(Y - otherJunctionBox.Y, 2);
            var zDeltaSq = Math.Pow(Z - otherJunctionBox.Z, 2);

            var totalSq = xDeltaSq + yDeltaSq + zDeltaSq;
            var distance = Math.Sqrt(totalSq);

            if (distance < _distanceToClosestJunctionBox)
            {
                SetClosestJunctionBox(otherJunctionBox, distance);
                otherJunctionBox.SetClosestJunctionBox(this, distance);
            }
            return distance;
        }

        public void SetClosestJunctionBox(JunctionBox otherJunctionBox, double distance)
        {
            _closestJunctionBox = otherJunctionBox;
            _distanceToClosestJunctionBox = distance;
        }
    }
}
