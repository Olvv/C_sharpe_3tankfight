using C_sharpe_3tankfight.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharpe_3tankfight
{
    internal class explosion:GameObject
    {
        public bool isDestory_explosion { get; set; }
        private int playspeed = 1;
        private int playcount = 0;
        private int index=0;
        private Bitmap[] bmpArray = new Bitmap[]
        {
            Resources.EXP1,
            Resources.EXP2,
            Resources.EXP3,
            Resources.EXP4,
            Resources.EXP5
        };
        public explosion(int x,int y)
        {
            foreach(Bitmap bmp in bmpArray)
            {
                bmp.MakeTransparent(Color.Black);
            }
            this.X_coordinate = x - bmpArray[0].Width / 2;
            this.Y_coordinate=y- bmpArray[0].Height / 2;
            isDestory_explosion=false;
        }
        protected override Image GetImage()
        {
            //throw new NotImplementedException();
          
           if (index>4)
            {
                return bmpArray[4];
            }
            return bmpArray[index];
        }
        public override void Update()
        {
            if (index > 4)
            {
                isDestory_explosion = true;
            }
            playcount++;
            index = (playcount - 1) / playspeed;
            base.Update();
        }


    }
}
