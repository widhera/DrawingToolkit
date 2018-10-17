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
    public abstract class DrawingObject
    {
        public abstract Point GetStart();
        public abstract Point GetEnd();
        public abstract bool Intersect(MouseEventArgs e);
        public abstract void Draw(PaintEventArgs e);
        public abstract void ChangeColor(Pen pen);
        public abstract void MoveShape(MouseEventArgs e,int xAmount, int yAmount);
    }
}
