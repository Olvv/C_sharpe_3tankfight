using C_sharpe_3tankfight.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace C_sharpe_3tankfight
{
    enum Source
    {
        MyTank,
        EnemyTank
    }
     class Bullet: Moving_Obj
    {
        public Source bulletSource { get; set; }
        public Bullet(int x, int y, int speed, Direciton bullet_dir,Source bulletSource)
        {
            Bitmap_down = Resources.BulletDown;
            Bitmap_left = Resources.BulletLeft;
            Bitmap_right = Resources.BulletRight;
            Bitmap_up = Resources.BulletUp;
            this.Dir = bullet_dir;
            this.X_coordinate = x;
            this.Y_coordinate = y;
            this.Speed = speed;
            this.X_coordinate -= Width / 2;
            this.Y_coordinate -= Height / 2;


            this.bulletSource = bulletSource;

        
        }

   
    }
}
