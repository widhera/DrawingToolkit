using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit
{
    public class DrawingCanvas : Panel
    {
        private Point start;
        private Point end;
        private int flag = 0;
        private int buttonFlag = 0;
        private int tool = 0;
        private bool group = false;
        private Point positionTemp;
        private DrawingObject selectObject;
        private List<DrawingObject> groupObject = new List<DrawingObject>();
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

        }

        public void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine(e.Button);
            if (tool != 4)
            {
                foreach (var obj in allObject)
                {
                    if (obj == selectObject)
                    {
                        Pen pen = new Pen(Color.Black);
                        obj.ChangeColor(pen);
                        selectObject = null;
                        break;
                    }
                }
                flag = 1;
                start = e.Location;
            }
            else if (tool == 4)
            {
                if (!group)
                {
                    foreach (var obj in allObject)
                    {
                        if (obj == selectObject)
                        {
                            Pen pen = new Pen(Color.Black);
                            obj.ChangeColor(pen);
                            selectObject = null;
                            break;
                        }
                    }
                }
                if (e.Button == MouseButtons.Left)
                {
                    buttonFlag = 0;


                    foreach (var obj in allObject)
                    {
                        if (obj.Intersect(e) && !group)
                        {
                            var test = e.Location;
                            positionTemp = e.Location;
                            selectObject = obj;
                            //this.Refresh();
                            break;
                        }
                        else if (obj.Intersect(e) && group)
                        {
                            var alreadySelected = 0;
                            foreach (var objGrp in groupObject)
                            {
                                if (obj == objGrp)
                                {
                                    alreadySelected = 1;
                                }
                            }
                            if (alreadySelected == 1)
                                break;
                            var test = e.Location;
                            positionTemp = e.Location;
                            //selectObject = obj;
                            groupObject.Add(obj);
                            //this.Refresh();
                            break;
                        }
                        else if (!obj.Intersect(e) && !group)
                        {
                            Pen pen = new Pen(Color.Black);
                            obj.ChangeColor(pen);
                            selectObject = null;
                            //this.Refresh();
                            Console.WriteLine("enggak msuk");
                        }
                    }
                    this.Refresh();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (group)
                    {
                        group = false;
                        foreach (var obj in allObject)
                        {
                            foreach (var objGrp in groupObject)
                            {
                                if (obj == objGrp)
                                {
                                    Pen pen = new Pen(Color.Black);
                                    obj.ChangeColor(pen);
                                    selectObject = null;
                                }
                            }
                        }
                        groupObject.Clear();
                        this.Refresh();
                    }

                    else
                        group = true;

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
            if (selectObject != null && !group)
            {
                int xAmount = e.X - positionTemp.X;
                int yAmount = e.Y - positionTemp.Y;
                Console.WriteLine(xAmount + " " + yAmount);
                positionTemp = e.Location;
                if (e.Button == MouseButtons.Left)
                {
                    selectObject.MoveShape(e, xAmount, yAmount);
                }
               
                //selectObject.MoveShape(e, xAmount, yAmount);
                this.Refresh();
            }
            else if (selectObject == null && group)
            {
                int xAmount = e.X - positionTemp.X;
                int yAmount = e.Y - positionTemp.Y;
                Console.WriteLine("haii" + groupObject.Count);
                positionTemp = e.Location;
                if (e.Button == MouseButtons.Left)
                {
                    foreach (var obj in groupObject)
                        obj.MoveShape(e, xAmount, yAmount);
                }
                this.Refresh();
            }
        }
        public void setToolValue(int value)
        {
            tool = value;
        }

    }
}
