using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit
{
    public class Line : DrawingObject
    {
        public Point start;
        public Point end;
        public Pen blackPen = new Pen(Color.Black);
        private const double EPSILON = 3.0;
        public Line(Point start2, Point end2)
        {
            start = start2;
            end = end2;
        }
        public override void Draw(PaintEventArgs e)
        {   
            e.Graphics.DrawLine(blackPen, start, end);
        }

        public override Point GetStart()
        {
            return start;
        }
        public override Point GetEnd()
        {
            return end;
        }
       
        public override bool Intersect(MouseEventArgs e)
        {
            Point test = e.Location;
            double m = (double)(end.Y - start.Y) / (double)(end.X - start.X);
            double b = end.Y - m * end.X;
            double y_point = m * test.X + b;
            if(Math.Abs(test.Y - y_point) < EPSILON)
            {
                blackPen = new Pen(Color.Red);
                return true;
            }
            return false;
        }
        
        public override void ChangeColor(Pen pen)
        {
            blackPen = pen;
        }

        public override void MoveShape(MouseEventArgs e,int xAmount, int yAmount)
        {
            Point test = e.Location;
            start = new Point((start.X+ xAmount),(start.Y+ yAmount));
            end = new Point((end.X + xAmount), (end.Y + yAmount));
        }
    }
}
