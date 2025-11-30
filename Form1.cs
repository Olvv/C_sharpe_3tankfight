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

        private Thread mainlogcontrol;
        private static Graphics window_graph;
        private static Bitmap tempBmp;
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;


            //this.StartPosition= FormStartPosition.Manual;
            //this.Location = new Point(100,100);

            //GDI Graphics Device Interface
            //FPS:  equal to the control frequency 


            window_graph = this.CreateGraphics();

            tempBmp = new Bitmap(450,450);
            Graphics bmpG = Graphics.FromImage(tempBmp);
            GameFramework.graph = bmpG;


            mainlogcontrol = new Thread(new ThreadStart(GameMainThread));
            mainlogcontrol.Start();
        }

        private static void GameMainThread()
        {
            //GameFramework
            GameFramework.Start();

            int sleepTime= 1000 / 60; // 60 FPS, so each frame takes about 16.67 ms

            while (true)
            {
               GameFramework.graph.Clear(Color.Black);

                //update the game state
          
                GameFramework.Update();// 60 FPS is enough for most games
                window_graph.DrawImage(tempBmp, 0, 0);
                Thread.Sleep(sleepTime); // Sleep for the calculated time to maintain the frame rate

            }
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            //#region how to paint string and line
            //Graphics graphics = this  .CreateGraphics();
            //Pen pen = new Pen(Color.Black);
            //graphics.DrawLine(pen, new Point(0, 0), new Point(100, 100));
            //graphics.DrawString("you can do anything you want", new Font("Arial", 16), Brushes.Black, new PointF(100, 120));
            //#endregion


            //Image image = Properties.Resources.Boss;
            //graphics.DrawImage(image,200,200);
            //Bitmap bitmap=Properties.Resources.Star1;
            //bitmap.MakeTransparent(Color.Black);
            //graphics.DrawImage(bitmap, new Point(150, 150));

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainlogcontrol.Abort();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            GameObjectManager.keydonw(e);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            GameObjectManager.keyup(e);
        }
    }
}
