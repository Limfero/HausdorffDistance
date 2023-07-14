using System;
using System.Collections.Generic;
using System.Linq;

namespace HausdorffDistanceLibrary
{
    public class PiecewiseConstantFunction
    {
        public List<Point> Points { get; set; }

        public PiecewiseConstantFunction()
        {
            Points = new List<Point>();
        }

        public double CalculateHausdorffDistance(PiecewiseConstantFunction other)
        {
            double distance1 = CalculateDirectedHausdorffDistance(this, other);
            double distance2 = CalculateDirectedHausdorffDistance(other, this);

            return Math.Max(distance1, distance2);
        }

        private double CalculateDirectedHausdorffDistance(PiecewiseConstantFunction first, PiecewiseConstantFunction second)
        {
            double distance = 0.0;

            foreach (var point in first.Points)
            {
                double minDistance = second.Points.Min(p => Math.Abs(p.Value - point.Value));

                if (minDistance > distance)
                    distance = minDistance;
            }

            return distance;
        }

        public static PiecewiseConstantFunction MergeDomains(PiecewiseConstantFunction first, PiecewiseConstantFunction second)
        {
            PiecewiseConstantFunction mergedFunction = new PiecewiseConstantFunction();

            mergedFunction.Points.AddRange(first.Points);
            mergedFunction.Points.AddRange(second.Points);

            return mergedFunction;
        }
    }
}
