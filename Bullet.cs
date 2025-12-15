using C_sharpe_3tankfight.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
        public bool IsbulletDestory { get; set; }
        public Bullet(int x, int y, int speed, Direciton bullet_dir,Source bulletSource)
        {
            IsbulletDestory = false;
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


        //public override void DrawSelf()
        //{
        //    lock (_lock)
        //    {
        //        base.DrawSelf();
        //    }
        //}


        public override void Update()
        {
            MoveCheck();
            move();
            base.Update();
        }

        public void MoveCheck()
        {
            #region 检查有没有超过窗体边界
            if (Dir == Direciton.Up)
            {
                if (Y_coordinate +Height/2+3< 0)
                {
                    IsbulletDestory=true;
                    return;
                }

            }
            if (Dir == Direciton.Down)
            {
                if (Y_coordinate  + Height/2-3  > 450)
                {
                    IsbulletDestory = true;
                    return;
                }
            }
            if (Dir == Direciton.Left)
            {
                if (X_coordinate +Width/2-3 < 0)
                {
                    IsbulletDestory = true;
                    return;
                }
            }
            if (Dir == Direciton.Right)
            {
                if (X_coordinate +  Width/2+3 > 450)
                {
                    IsbulletDestory = true;
                    return;
                }
            }
            #endregion

            //检查有没有和其他元素发生碰撞
            Rectangle rect = GetRectangle();

            rect.X = X_coordinate + Width / 2 - 3;
            rect.Y = Y_coordinate + Height / 2 - 3;
            rect.Height = 3;
            rect.Width = 3;

            Stationary_Obj wall = null;
            if((wall=GameObjectManager.IsCollidedWall(rect) )!= null)
            {
               IsbulletDestory=true ;
                GameObjectManager.DestroyWall(wall);
                return;
            }

            if (GameObjectManager.IsCollidedSteel(rect) != null)
            {
                //ChangeDirection();
                IsbulletDestory = true;
                return;
            }

            if (GameObjectManager.IsCollidedBoss(rect))
            {
                //ChangeDirection();
                return;
            }

            if (bulletSource == Source.MyTank)
            {
                Enemy_Tank tank = null;
                //ChangeDirection();
                if ((tank=GameObjectManager.IsCollidedEnemyTank(rect)) != null)
                {
                    IsbulletDestory=true;
                    GameObjectManager.DestroyTank(tank);
                    return;
                }
                return;
            }

        }

        private void move()
        {
            //if (IsMoving == false)
            //{
            //    return;
            //}
            switch (Dir)
            {
                case Direciton.Up:
                    Y_coordinate -= Speed;
                    break;
                case Direciton.Down:
                    Y_coordinate += Speed;
                    break;
                case Direciton.Left:
                    X_coordinate -= Speed;
                    break;
                case Direciton.Right:
                    X_coordinate += Speed;
                    break;


            }
        }

    }
}
