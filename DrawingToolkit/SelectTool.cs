using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit
{
    class SelectTool : Tool
    {
        public override void setTool(DrawingCanvas a)
        {
            a.setToolValue(4);
        }
    }
}
