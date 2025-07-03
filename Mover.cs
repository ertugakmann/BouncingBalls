using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
 
namespace BouncingBalls
{
    class Mover
    {
        static Random rnd = new Random();
        Vector2 location;
        Vector2 velocity;
        int formWidth, formHeight;
        Vector2 accerlation;
        Vector2 mouse = new Vector2();
        float topSpeed;
        Form frm;
        Color color;
 
 
        public Mover(int width, int height, Form theForm, Color color)
        {
            formWidth = width;
            formHeight = height;
            location = new Vector2(rnd.Next(width), rnd.Next(height));
            velocity = new Vector2(0, 0);
            accerlation = new Vector2((float)-0.001, (float)0.001);
            frm = theForm;
            topSpeed = 10;
            this.color = color;
        }
 
 
        float Mag(Vector2 theVector)
        {
            return (float)Math.Sqrt(theVector.X * theVector.X + theVector.Y * theVector.Y);
        }
 
 
        public Vector2 Limit(float theLimit, Vector2 theVector)
        {
            if (Mag(theVector) > theLimit)
            {
                // this is off stack overflow the 10 is the limit 
                theVector.X = theVector.X * theLimit / Mag(theVector);
                theVector.Y = theVector.Y * theLimit / Mag(theVector);
            }
            return theVector;
        }
 
        public void Update()
        {
            Point cp = frm.PointToClient(Cursor.Position);
            mouse.X = cp.X;
            mouse.Y = cp.Y;
            Vector2 dir = Vector2.Subtract(mouse, location);
            dir = Vector2.Normalize(dir);
            dir = Vector2.Multiply(0.6f, dir);
            accerlation = dir;
            velocity = Vector2.Add(velocity, accerlation);
            velocity = Limit(topSpeed, velocity);
            location = Vector2.Add(location, velocity); 
        }
 
        public void Display(Graphics e)
        {
 
            using (Brush brush = new SolidBrush(color))
            {
                e.FillEllipse(brush, location.X, location.Y, 20, 20);
            }
            //e.FillEllipse(Brushes.BlueViolet, location.X, location.Y, 20, 20);
        }
 
    }
 
 
}