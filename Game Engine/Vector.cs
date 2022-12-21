using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sodium
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        private double magnitude
        {
            get
            {
                return Math.Sqrt((this.X * this.X) + (this.Y * this.Y));
            }
        }

        public Vector normalize
        {
            get
            {
                Vector norm = new Vector(this.X /= this.magnitude, this.Y /= this.magnitude);
                if (!Double.IsNaN(norm.X) || !Double.IsNaN(norm.Y))
                    return norm;
                else
                    return new Vector(0,0);
            }
        }

        public Vector(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public static Vector GetMiddleLocation(Vector Position, Vector Scale)
        {
            return new Vector((int)Position.X + (int)Scale.X / 2, (int)Position.Y + (int)Scale.Y / 2);
        }

        public static Vector GetDirection(Vector too, Vector from)
        {
            return new Vector(too.X - from.X, too.Y - from.Y);
        }

        public static double GetDistance(Vector point1, Vector point2)
        {
            if (point1 != null &&  point2 != null)
            {
                double x = Math.Abs(point1.X - point2.X);
                double y = Math.Abs(point1.Y - point2.Y);
                return Math.Sqrt((x * x) + (y * y));
            }
            return 0;
        }

        public static Shape GetClosestShape(Vector Position, string tag, Shape Exeption)
        {
            List<Shape> shapes = GameEngine.GetShapes(tag);
            if (shapes.Count == 0) return null;
            Shape currentClosestShape = shapes[0];
            foreach (Shape s in shapes)
            {
                if (s != Exeption)
                {
                    if (GetDistance(s.Position, Position) < GetDistance(currentClosestShape.Position, Position))
                    {
                        currentClosestShape = s;
                    }
                }
            }
            return currentClosestShape;
        }
    }
}
