using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace R2
{
    public partial class mainform : Form
    {

        public mainform()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = BitmapToRegion.getRegionFast((Bitmap)this.BackgroundImage, Color.FromArgb(0,255,0),100);
        }

        #region form moving
        Point lastPoint;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        #endregion

        #region opened and closed form
        private void openedform()
        {
            this.Height = 362;
        }

        private void closedform()
        {
            this.Height = 105;
        }
        #endregion

     






    }
}
