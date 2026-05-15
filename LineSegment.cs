using System;

namespace LineSegmentWPF
{
    internal class LineSegment
    {
        private double _x;
        private double _y;

        public LineSegment(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public LineSegment(LineSegment other)
        {
            _x = other._x;
            _y = other._y;
        }

        public static double operator !(LineSegment s)
        {
            return Math.Abs(s._x - s._y);
        }

        public static LineSegment operator ++(LineSegment s)
        {
            return new LineSegment(s._x - 1, s._y + 1);
        }

        public static explicit operator int(LineSegment s)
        {
            return (int)s._x;
        }

        public static implicit operator double(LineSegment s)
        {
            return s._y;
        }

        public static LineSegment operator +(LineSegment s,int d)
        {
            return new LineSegment(s._x - d, s._y + d);
        }

        public static LineSegment operator +(int d,LineSegment s)
        {
            return s + d;
        }

        public static bool operator <(LineSegment s,int number)
        {
            double start = Math.Min(s._x, s._y);
            double end = Math.Max(s._x, s._y);
            return number >= start && number <= end;
        }

        public static bool operator >(LineSegment s,int number)
        {
            double start = Math.Min(s._x, s._y);
            double end = Math.Max(s._x, s._y);
            return !(number >= start && number <= end);
        }

        public override string ToString()
        {
            return $"Отрезок: [{_x:F2}; {_y:F2}]";
        }
    }
}
