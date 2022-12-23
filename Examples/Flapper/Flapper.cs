using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Input;

namespace Sodium
{
    class Flapper : GameEngine
    {
        public Flapper() : base(new Vector(1000, 1000), "Flapper: Not A Flappy Bird Rip-Off.") { }

        Random rnd = new Random();
        Shape p;
        List<Shape> objects = new List<Shape>();
        double vel = 0;
        double speed = 500;
        double jumpForce = 500;
        double velAdd = 1000;
        bool started;
        bool canJump = true;
        Vector oldPos;
        double count;
        double cooldown = .5;

        public override void OnLoad()
        {
            string[,] map = new string[20, 20]
{
                { "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w"},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", "p", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
                { "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w", "w"},
};

            Room.AddRoom(map);

            foreach (Vector i in Room.GetTiles("w"))
            {
                new Shape(i, new Vector(50, 50), Color.Black, "Wall", Type.Square, null);
            }
            foreach (Vector i in Room.GetTiles("p"))
            {
                p = new Shape(i, new Vector(50, 50), Color.Blue, "Player", Type.Square, null);
            }
        }
        public override void OnUpdate()
        {
            if (Input.GetKey(Key.Space))
            {
                started = true;
            }

            if (started)
            {
                count += deltaTime;

                if (count >= cooldown)
                {
                    count = 0;
                    Vector spawnPos = new Vector(800, rnd.Next(50, 950));
                    objects.Add(new Shape(spawnPos, new Vector(50, 50), Color.Red, "Object", Type.Square, null));
                }

                oldPos = new Vector(p.Position.X, p.Position.Y);

                p.Position.Y -= vel * deltaTime;
                vel -= velAdd * deltaTime;
                if (Input.GetKey(Key.Space) && canJump)
                {
                    vel = jumpForce;
                    canJump = false;
                }
                if (Input.GetKeyUp(Key.Space))
                {
                    canJump = true;
                }

                if (p.IsCollided(p, "Wall")) p.Position = oldPos;
                if (p.IsCollided(p, "Object")) System.Windows.Forms.Application.Exit();

                foreach (Shape obj in objects)
                {
                    obj.Position.X -= speed * deltaTime;
                }
            }
        }
    }
}