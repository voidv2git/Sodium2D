using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Input;

namespace Sodium
{
    class AvoidTheEnemy : GameEngine
    {
        public AvoidTheEnemy() : base(new Vector(1000, 1000), "Avoid The Enemy") { }

        Shape p;
        List<Shape> enemys = new List<Shape>();
        int speed = 400;
        int enemySpeed = 250;
        Vector oldPos;
        Vector moveDir;

        public override void OnLoad()
        {
            string[,] map = new string[20, 20]
            {
                { "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w"},
                { "w", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "w"},
                { "w", ".", "p", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "w"},
                { "w", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "w"},
                { "w", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "w"},
                { "w", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "w"},
                { "w", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "w"},
                { "w", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "w"},
                { "w", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "w"},
                { "w", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "w"},
                { "w", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "w"},
                { "w", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "w"},
                { "w", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "w"},
                { "w", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "w"},
                { "w", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "w"},
                { "w", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "w"},
                { "w", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "w"},
                { "w", ".", "e", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "e", ".", "w"},
                { "w", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "w"},
                { "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w"},
            };

            Room.AddRoom(map);

            foreach (Vector i in Room.GetTiles("w"))
            {
                new Shape(i, new Vector(50, 50), Color.Black, "Wall", Type.Square, null);
            }
            foreach (Vector i in Room.GetTiles("p"))
            {
                p = new Shape(i, new Vector(50, 50), Color.Black, "Player", Type.Sprite, new Bitmap(@"C:\Users\nicka\Downloads\Among Us 1.png"));
            }
            foreach (Vector i in Room.GetTiles("e"))
            {
                enemys.Add(new Shape(i, new Vector(50, 50), Color.Black, "Enemy", Type.Sprite, new Bitmap(@"C:\Users\nicka\Downloads\Among Us 2.png")));
            }
        }
        public override void OnUpdate()
        {

            moveDir = new Vector(0, 0);

            if (Input.GetKey(Key.W)) moveDir.Y = -1;
            if (Input.GetKey(Key.S)) moveDir.Y = 1;
            if (Input.GetKey(Key.A)) moveDir.X = -1;
            if (Input.GetKey(Key.D)) moveDir.X = 1;
            if (p.IsCollided(p, "Wall")) p.Position = oldPos;

            oldPos = new Vector(p.Position.X, p.Position.Y);

            moveDir = moveDir.normalize;

            p.Position.X += moveDir.X * deltaTime * speed;
            p.Position.Y += moveDir.Y * deltaTime * speed;

            foreach (Shape e in enemys)
            {
                Vector direction = Vector.GetDirection(p.Position, e.Position);
                direction = direction.normalize;

                e.Position.X += direction.X * deltaTime * enemySpeed;
                e.Position.Y += direction.Y * deltaTime * enemySpeed;
            }
        }
    }
}
