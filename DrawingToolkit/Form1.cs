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
    public partial class Form1 : Form
    {

        private DrawingCanvas drawingCanvas;
        public Form1()
        {
            drawingCanvas = new DrawingCanvas();
            InitializeComponent(drawingCanvas);
        }

        public void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LineTool line = new LineTool();
            line.setTool(drawingCanvas);
            this.lineToolStripMenuItem.BackColor = SystemColors.Highlight;
            this.rectangleToolStripMenuItem.BackColor = SystemColors.Control;
            this.circleToolStripMenuItem.BackColor = SystemColors.Control;
            this.selectToolStripMenuItem.BackColor = SystemColors.Control;
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SquareTool square = new SquareTool();
            square.setTool(drawingCanvas);
            this.rectangleToolStripMenuItem.BackColor = SystemColors.Highlight;
            this.lineToolStripMenuItem.BackColor = SystemColors.Control;
            this.circleToolStripMenuItem.BackColor = SystemColors.Control;
            this.selectToolStripMenuItem.BackColor = SystemColors.Control;
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CircleTool circle = new CircleTool();
            circle.setTool(drawingCanvas);
            this.circleToolStripMenuItem.BackColor = SystemColors.Highlight;
            this.lineToolStripMenuItem.BackColor = SystemColors.Control;
            this.rectangleToolStripMenuItem.BackColor = SystemColors.Control;
            this.selectToolStripMenuItem.BackColor = SystemColors.Control;
        }
        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectTool select = new SelectTool();
            select.setTool(drawingCanvas);
            this.selectToolStripMenuItem.BackColor = SystemColors.Highlight;
            this.circleToolStripMenuItem.BackColor = SystemColors.Control;
            this.lineToolStripMenuItem.BackColor = SystemColors.Control;
            this.rectangleToolStripMenuItem.BackColor = SystemColors.Control;
        }

    }
}
