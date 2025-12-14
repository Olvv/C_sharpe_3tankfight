using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharpe_3tankfight
{

    enum Direciton
    {
        Up,
        Down,
        Left, 
        Right
    }
    internal class Moving_Obj:GameObject
    {
        private Object _lock=new Object();
        public Bitmap Bitmap_up {  get; set; }
        public Bitmap Bitmap_down { get; set; }
        public Bitmap Bitmap_left { get; set; }
        public Bitmap Bitmap_right { get; set; }
        //public bool IsMoving { get; set; }
        public int Speed {  get; set; }// use  pixel as unit

        private Direciton dir;
        public Direciton Dir { get{ return dir; }
            set { 
            dir = value;
                Bitmap bitmap=null;
                switch (dir)
                {
                    case Direciton.Up:
                        bitmap = Bitmap_up;
                        break;
                    case Direciton.Down:
                        bitmap = Bitmap_down;
                        break;
                    case Direciton.Left:
                        bitmap = Bitmap_left;
                        break;
                    case Direciton.Right:
                        bitmap = Bitmap_right;
                        break;
                }

                //lock (_lock)
                //{

                //    //Width = bitmap.Width;
                //    //Height = bitmap.Height;
                //}

            }
        } 

        protected override Image GetImage()
        {

            Bitmap bitmap = null;   

            switch (Dir)
            {
                case Direciton.Up:
                    bitmap = Bitmap_up;
                    break;
                case Direciton.Down:
                    bitmap = Bitmap_down;
                    break;
                case Direciton.Left:
                    bitmap = Bitmap_left;
                    break;  
                case Direciton.Right:
                    bitmap = Bitmap_right;
                    break;
            }


            Width = bitmap.Width;
            Height = bitmap.Height;
            bitmap.MakeTransparent(Color.Black);
            return bitmap;
        }


    }
}
