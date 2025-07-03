using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

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
            //FPS:  equal to the control frequency 

           Thread mainlogcontrol= new Thread(new ThreadStart(GameMainThread));
            mainlogcontrol.Start();
        }

        private static void GameMainThread()
        {
            //GameFramework
            GameFramework.Start();

            int sleepTime= 1000 / 60; // 60 FPS, so each frame takes about 16.67 ms

            while (true)
            {
                //update the game state
                GameFramework.Update();// 60 FPS is enough for most games
                Thread.Sleep(sleepTime); // Sleep for the calculated time to maintain the frame rate

            }
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            #region how to paint string and line
            Graphics graphics = this  .CreateGraphics();
            Pen pen = new Pen(Color.Black);
            graphics.DrawLine(pen, new Point(0, 0), new Point(100, 100));
            graphics.DrawString("you can do anything you want", new Font("Arial", 16), Brushes.Black, new PointF(100, 120));
            #endregion


            Image image = Properties.Resources.Boss;
            graphics.DrawImage(image,200,200);
            Bitmap bitmap=Properties.Resources.Star1;
            bitmap.MakeTransparent(Color.Black);
            graphics.DrawImage(bitmap, new Point(150, 150));

        }
    }
}
