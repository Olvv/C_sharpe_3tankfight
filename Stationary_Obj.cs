using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharpe_3tankfight
{
    /*
     * not move object
     */
    internal class Stationary_Obj : GameObject
    {
        public Image Image { get; set; }

        protected override Image GetImage()
        {
          return Image; 
        }

        public Stationary_Obj(int x, int y ,Image image)   
        {
           this.X_coordinate = x;   
           this.Y_coordinate = y;
           this.Image = image;
        }
    }
}
