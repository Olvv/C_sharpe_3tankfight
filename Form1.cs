using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_sharpe_3tankfight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.StartPosition= FormStartPosition.Manual;
            //this.Location = new Point(100,100);

            //GDI Graphics Device Interface
         
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
            Pen pen = new Pen(Color.Black);
            graphics.DrawLine(pen, new Point(0, 0), new Point(100, 100));
            graphics.DrawString("you can do anything you want", new Font("Arial", 16), Brushes.Black, new PointF(100, 120));
        }
    }
}
