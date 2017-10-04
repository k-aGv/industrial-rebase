using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace industrial_rebase {
    public partial class Form1 : Form {
        public Form1() {
            DoubleBuffered = true;
            InitializeComponent();
            MeasureScreen();
            BuildUI();
        }

  

        private void button1_Click(object sender, EventArgs e) {
            tempFlag = true;
            Init();
            UpdateGrid();
        }

        private void toolStripButton1_Click(object sender, EventArgs e) {
            toolStripButton1.Checked = !toolStripButton1.Checked;
            if (toolStripButton1.Checked) {
                toolStripLabel1.Text = "Tool:Walls - Release the icon to change tool";
                toolStripButton2.Enabled = false;
                toolStripButton3.Enabled = false;
                toolStripButton4.Enabled = false;
            } else {
                toolStripLabel1.Text = "Select tool...";
                toolStripButton1.Enabled = true;
                toolStripButton2.Enabled = true;
                toolStripButton3.Enabled = true;
                toolStripButton4.Enabled = true;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e) {
            toolStripButton2.Checked = !toolStripButton2.Checked;
            if (toolStripButton2.Checked) {
                toolStripLabel1.Text = "Tool:Start - Release the icon to change tool"; 
                toolStripButton1.Enabled = false;
                toolStripButton3.Enabled = false;
                toolStripButton4.Enabled = false;
            } else {
                toolStripLabel1.Text = "Select tool...";
                toolStripButton1.Enabled = true;
                toolStripButton2.Enabled = true;
                toolStripButton3.Enabled = true;
                toolStripButton4.Enabled = true;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e) {
            toolStripButton3.Checked = !toolStripButton3.Checked;
            if (toolStripButton3.Checked) {
                toolStripLabel1.Text = "Tool:Loads - Release the icon to change tool"; 
                toolStripButton2.Enabled = false;
                toolStripButton1.Enabled = false;
                toolStripButton4.Enabled = false;
            } else {
                toolStripLabel1.Text = "Select tool...";
                toolStripButton1.Enabled = true;
                toolStripButton2.Enabled = true;
                toolStripButton3.Enabled = true;
                toolStripButton4.Enabled = true;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e) {
            toolStripButton4.Checked = !toolStripButton4.Checked;
            if (toolStripButton4.Checked) {
                toolStripLabel1.Text = "Tool:Exit - Release the icon to change tool"; 
                toolStripButton2.Enabled = false;
                toolStripButton1.Enabled = false;
                toolStripButton3.Enabled = false;
            } else {
                toolStripLabel1.Text = "Select tool...";
                toolStripButton1.Enabled = true;
                toolStripButton2.Enabled = true;
                toolStripButton3.Enabled = true;
                toolStripButton4.Enabled = true;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e) {
            if (tempFlag == false) return; //avoid crash for now
            if (isMouseDown) {
                for (int widthTrav = 0; widthTrav < Globals._WidthBlocks; widthTrav++) {
                    for (int heightTrav = 0; heightTrav < Globals._HeightBlocks; heightTrav++) {
                        if (rects[widthTrav][heightTrav].boxRec.IntersectsWith(new Rectangle(e.Location, new Size(1, 1)))) {
                            lastBoxType = rects[widthTrav][heightTrav].boxType;
                            lastBoxSelect = rects[widthTrav][heightTrav];
                            switch (lastBoxType) {
                                case BoxType.Normal:
                                case BoxType.Wall:
                                    rects[widthTrav][heightTrav].SwitchBox();
                                    UpdateGrid();
                                    break;
                                case BoxType.Start:
                                case BoxType.End:
                                    break;
                            }
                        }


                    }
                }
            }
            
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e) {
            isMouseDown = true;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e) {
            isMouseDown = false;
        }
    }
}
