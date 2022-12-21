using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sodium
{
    public class Shape
    {
        public Vector Position { get; set; }
        public Vector Scale { get; set; }
        public Color color = Color.Black;
        public string Tag;
        public GameEngine.Type type;
        public Image image;

        public Shape(Vector position, Vector scale, Color color, string tag, GameEngine.Type type, Image image)
        {
            Position = position;
            Scale = scale;
            this.color = color;
            Tag = tag;
            this.type = type;
            this.image = image;
            GameEngine.RegisterShape(this);
        }

        public bool IsCollided(Shape shape, string tag)
        {
            List<Shape> p = GameEngine.GetShapes(tag);
            foreach (Shape s in p)
            {
                if (s.Position.Y + s.Scale.Y > shape.Position.Y && shape.Position.Y + shape.Scale.Y > s.Position.Y
                    && s.Position.X + s.Scale.X > shape.Position.X && shape.Position.X + shape.Scale.X > s.Position.X)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
