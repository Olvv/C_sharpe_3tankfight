using C_sharpe_3tankfight.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C_sharpe_3tankfight
{

  
    class Enemy_Tank:Moving_Obj
    {
        private Object _lock = new Object();
        private Random updir = new Random();
        public int ChangeDirSpeed { get; set; }
        private int ChangeDirCount=0;
        public int attackspeed { get; set; }
        private int attackCount=0;
        public Enemy_Tank(int x, int y, int speed, Bitmap Bitmapdown, Bitmap Bitmapup, Bitmap Bitmapleft, Bitmap Bitmapright)
        {
            //IsMoving = true;
            this.X_coordinate = x;
            this.Y_coordinate = y;
            this.Speed = speed;
          
            Bitmap_down = Bitmapdown; 
            Bitmap_left = Bitmapleft;
            Bitmap_right = Bitmapright;
            Bitmap_up = Bitmapup;
            this.Dir = Direciton.Down;
            attackspeed = 10;
            ChangeDirSpeed=20;
        }

        public override void DrawSelf()
        {
            lock (_lock)
            { 
                base.DrawSelf();
        }
        }


        public override void Update()
        {
            MoveCheck();
            move();
            AttackCheck();
            AutoChangeDirection();
            base.Update();
            
        }

        public void MoveCheck()
        {
            #region 检查有没有超过窗体边界
            if (Dir == Direciton.Up)
            {
                if (Y_coordinate - Speed < 0)
                {
                    ChangeDirection();
                    return;
                }

            }
            if (Dir == Direciton.Down)
            {
                if (Y_coordinate + Speed + Height > 450)
                {
                    ChangeDirection();
                    return;
                }
            }
            if (Dir == Direciton.Left)
            {
                if (X_coordinate - Speed < 0)
                {
                    ChangeDirection();
                    return;
                }
            }
            if (Dir == Direciton.Right)
            {
                if (X_coordinate + Speed + Width > 450)
                {
                    ChangeDirection();
                    return;
                }
            }
            #endregion

            //检查有没有和其他元素发生碰撞
            Rectangle rect = GetRectangle();


            switch (Dir)
            {
                case Direciton.Up:
                    rect.Y -= Speed;
                    break;
                case Direciton.Down:
                    rect.Y += Speed;
                    break;
                case Direciton.Left:
                    rect.X -= Speed;
                    break;
                case Direciton.Right:
                    rect.X += Speed;
                    break;


            }

            if (GameObjectManager.IsCollidedWall(rect) != null)
            {
                ChangeDirection();
                return;
            }

            if (GameObjectManager.IsCollidedSteel(rect) != null)
            {
                ChangeDirection();
                return;
            }

            if (GameObjectManager.IsCollidedBoss(rect))
            {
                ChangeDirection();
                return;
            }

        }
        private void AutoChangeDirection()
        {
            ChangeDirCount++;
             if (ChangeDirCount < ChangeDirSpeed)
            { 
            return;
              }
             ChangeDirection();
            ChangeDirCount = 0; 


        }

        private void ChangeDirection()
        {
            //get current direciton 

            while (true)
            {
                Direciton dir = (Direciton)updir.Next(0, 4);
                if (dir == Dir)
                {
                    continue;

                }
                {
                    Dir = dir; 
                    break;
                }
            }
            MoveCheck();
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

        private void AttackCheck()
        {
            attackCount++;
            if (attackCount < attackspeed)
            {
                return;
            }
            Attack();
            attackCount = 0;
        }

        private void Attack()
        {
            int x = this.X_coordinate;
            int y = this.Y_coordinate;
            switch (Dir)
            {
                case Direciton.Up:
                    x = x + Width / 2;
                    break;
                case Direciton.Down:
                    x = x + Width / 2;
                    y += Height;
                    break;
                case Direciton.Left:
                    y = y + Height / 2;
                    break;
                case Direciton.Right:
                    x += Width;
                    y = y + Height / 2;
                    break;


            }

            GameObjectManager.CreateBullet(x, y, Source.EnemyTank, Dir);
        }
    }
}
