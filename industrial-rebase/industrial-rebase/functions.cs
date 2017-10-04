using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace industrial_rebase {
    public partial class Form1 : Form {

        void MeasureScreen() {
            //Maximize the window to fit the screen.Our window will be forced to full screen size
            Location = new Point(0, 0);
            Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        void BuildUI() {
            //treeview build
            treeView1.Location = new Point(0, menuStrip1.Height + toolStrip1.Height);
            treeView1.Height = statusStrip1.Location.Y - menuStrip1.Height - toolStrip1.Height;

            //tabs build
            tabControl1.Location = new Point(treeView1.Width + Globals._WindowsOffset, menuStrip1.Height + toolStrip1.Height);
            Size innerFormSize = RectangleToScreen(this.ClientRectangle).Size;
            // int titleBarSize = (RectangleToScreen(this.ClientRectangle).Top + this.Top);
            tabControl1.Size = new Size(innerFormSize.Width - treeView1.Width - Globals._WindowsOffset, innerFormSize.Height - menuStrip1.Height - statusStrip1.Height - toolStrip1.Height);

            //panel build
            panel1.Dock = DockStyle.Fill;

            //Form build
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;

            //toolbar build
            toolStripLabel1.Text = "Select tool...";
        }

        void UpdateGrid() {
            g = panel1.CreateGraphics();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            for (int rowBlocks = 0; rowBlocks < Globals._WidthBlocks; rowBlocks++) {
                for (int colBlocks = 0; colBlocks < Globals._HeightBlocks; colBlocks++) {
                    rects[rowBlocks][colBlocks].DrawBox(g, BoxType.Normal);
                    rects[rowBlocks][colBlocks].DrawBox(g, BoxType.Wall);
                }
            }
        }

        void Init() {
            rects = new GridBox[Globals._WidthBlocks][];

            int gridBlockWidth = Globals._WidthBlocks * Globals._BlockSide;
            int gridBlockHeight = Globals._HeightBlocks * Globals._BlockSide;
            Point measuredSpawn = new Point((panel1.Location.X + panel1.Width / 2) - (gridBlockWidth / 2), (panel1.Location.Y + panel1.Height / 2) - (gridBlockHeight / 2));

            for (int rowBlocks = 0; rowBlocks < Globals._WidthBlocks; rowBlocks++) {
                rects[rowBlocks] = new GridBox[Globals._HeightBlocks];
                for (int colBlocks = 0; colBlocks < Globals._HeightBlocks; colBlocks++) {
                    rects[rowBlocks][colBlocks] = new GridBox(((rowBlocks * Globals._BlockSide) + measuredSpawn.X), measuredSpawn.Y + (colBlocks * Globals._BlockSide), BoxType.Normal);
                }
            }
        }
    }
}
