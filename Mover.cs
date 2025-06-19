using System;
using System.Drawing;
using System.Numerics;

namespace BouncingBalls
{
    class Mover
    {
        static Random rnd = new Random();
        Vector2 location;
        Vector2 velocity;

        public Mover(int x, int y)
        {
            location = new Vector2(rnd.Next(x), rnd.Next(y));
            velocity = new Vector2(rnd.Next(-10, 11), rnd.Next(-10, 11));
        }

        public void Update()
        {
            velocity.X = rnd.Next(-10, 11);
            velocity.Y = rnd.Next(-10, 11);

            location = Vector2.Add(location, velocity);
        }

        public void Display(Graphics e)
        {
            e.FillEllipse(Brushes.Pink, location.X, location.Y, 100, 100);
        }
    }
}
