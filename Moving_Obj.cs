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

        public Bitmap Bitmap_up {  get; set; }
        public Bitmap Bitmap_down { get; set; }
        public Bitmap Bitmap_left { get; set; }
        public Bitmap Bitmap_right { get; set; }

        public int Speed {  get; set; }

        public Direciton Dir { get; set; } 

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

            bitmap.MakeTransparent(Color.Black);
            return bitmap;
        }
    }
}
