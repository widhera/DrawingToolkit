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
    public class CircleTool : Tool
    {
        public override void setTool(DrawingCanvas a)
        {
            a.setToolValue(3);
        }
    }
}
