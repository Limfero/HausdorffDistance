using System;
using System.Collections.Generic;
using System.Linq;

namespace HausdorffDistanceLibrary
{
    public class PiecewiseConstantFunction
    {
        private readonly List<Point> _points;
        private readonly static string ErrorAddPoint = "Points should be ordered in ascending order\nLast: {0} > New: {1}";

        public PiecewiseConstantFunction()
        {
            _points = new List<Point>();
        }

       public void Add(Point point)
       {
            if (_points.Count != 0 && _points.Last().X > point.X)
                throw new Exception(string.Format(ErrorAddPoint, _points.Last().X, point.X));

            _points.Add(point);
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

            foreach (var point in first._points)
            {
                double minDistance = second._points.Min(p => Math.Abs(p.Y - point.Y));

                if (minDistance > distance)
                    distance = minDistance;
            }

            return distance;
        }

        public static PiecewiseConstantFunction MergeDomains(PiecewiseConstantFunction first, PiecewiseConstantFunction second)
        {
            PiecewiseConstantFunction mergedFunction = new PiecewiseConstantFunction();

            mergedFunction._points.AddRange(first._points);
            mergedFunction._points.AddRange(second._points);

            return mergedFunction;
        }
    }
}
