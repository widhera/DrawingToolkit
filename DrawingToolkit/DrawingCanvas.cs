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
    public class DrawingCanvas:Panel
    {
        private Point start;
        private Point end;
        private int flag = 0;
        private int tool = 0;
        private Point positionTemp;
        private DrawingObject selectObject;
        private List<DrawingObject> allObject = new List<DrawingObject>();
        public DrawingCanvas()
        {
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 24);
            this.Name = "panel1";
            this.Size = new System.Drawing.Size(800, 426);
            this.TabIndex = 1;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
        }

        public void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            if (flag == 1 && tool == 1)
            {
                Line line = new Line(start, end);
                line.Draw(e);
            }

            else if (flag == 1 && tool == 2)
            {
                Square square = new Square(start, end);
                square.Draw(e);
                
            }

            else if (flag == 1 && tool == 3)
            {
                Circle circle = new Circle(start, end);
                circle.Draw(e);
            }

            foreach (DrawingObject obj in allObject)
            {
                obj.Draw(e);
            }


        }

        public void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            flag = 0;
            if (tool == 1)
            {
                Line line = new Line(start, end);
                allObject.Add(line);
            }
            if (tool == 2)
            {
                Square square = new Square(start, end);
                allObject.Add(square);
            }
            if (tool == 3)
            {
                Circle circle = new Circle(start, end);
                allObject.Add(circle);
            }
            if (tool == 4)
            {
                if(selectObject!=null)
                {
                    Pen pen = new Pen(Color.Black);
                    selectObject.ChangeColor(pen);
                    selectObject = null;
                    this.Refresh();
                }
                
            }

        }

        public void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if(tool!=4)
            {
                flag = 1;
                start = e.Location;
            }
            else if (tool == 4)
            {
                foreach(var obj in allObject)
                {
                    if (obj.Intersect(e))
                    {
                        var test = e.Location;
                        positionTemp = e.Location;
                        //Console.WriteLine("msuk");
                        selectObject = obj;
                        this.Refresh();
                    }
                    else
                    {
                        Pen pen = new Pen(Color.Black);
                        obj.ChangeColor(pen);
                        //selectObject = null;
                        this.Refresh();
                        //Console.WriteLine("enggak msuk");
                    }
                }
            }
            
        }

        public void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (flag == 1)
            {
                end = e.Location;
                this.Refresh();
            }
            if(selectObject!=null)
            {
                int xAmount = e.X - positionTemp.X;
                int yAmount = e.Y - positionTemp.Y;
                positionTemp = e.Location;
                selectObject.MoveShape(e, xAmount, yAmount);
                this.Refresh(); 
            }
        }
        public void setToolValue(int value)
        {
            tool = value;
        }
        
    }
}
