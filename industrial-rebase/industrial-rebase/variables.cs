using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace industrial_rebase {
    public partial class Form1 : Form {

        bool isMouseDown = false;
        GridBox[][] rects;
        Graphics g;
        GridBox lastBoxSelect;
        BoxType lastBoxType;

        bool tempFlag = false;
    }
}
