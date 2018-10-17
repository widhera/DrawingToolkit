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
    public class Circle : DrawingObject
    {
        public Point start;
        public Point end;
        public Pen blackPen = new Pen(Color.Black);
        public Circle(Point start2, Point end2)
        {
            start = start2;
            end = end2;
        }
        public override void Draw(PaintEventArgs e)
        {
            Brush black = new SolidBrush(Color.Black);
            Rectangle objek = new Rectangle(start.X, start.Y, end.X - start.X, end.Y - start.Y);
            e.Graphics.DrawEllipse(blackPen, objek);
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

            if ((test.X >= start.X && test.X <= start.X + (end.X - start.X)) && (test.Y >= start.Y && test.Y <= start.Y + (end.Y - start.Y)))
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

        public override void MoveShape(MouseEventArgs e, int xAmount, int yAmount)
        {
            Point test = e.Location;
            start = new Point((start.X + xAmount), (start.Y + yAmount));
            end = new Point((end.X + xAmount), (end.Y + yAmount));
        }
    }
}
