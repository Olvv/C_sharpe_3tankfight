using C_sharpe_3tankfight.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_sharpe_3tankfight
{
    internal class MyTank:Moving_Obj
    {
        public bool IsMoving { get; set; }
        public MyTank(int x, int y, int speed ) 
        {
            IsMoving= false;
            this.X_coordinate = x;
            this.Y_coordinate = y;
            this.Speed = speed;
            this.Dir = Direciton.Up;
            Bitmap_down=Resources.MyTankDown;
            Bitmap_left=Resources.MyTankLeft;
            Bitmap_right=Resources.MyTankRight;
            Bitmap_up=Resources.MyTankUp;
        }

        public override void Update()
        {
            MoveCheck();
            move();
            base.Update();
        }

        public void MoveCheck()
        {
#region 检查有没有超过窗体边界
            if (Dir==Direciton.Up)
            {
                if (Y_coordinate - Speed < 0)
                {
                    IsMoving= false;
                    return;
                }
                
            }
            if (Dir==Direciton.Down)
            {
                if (Y_coordinate+Speed+Height>450)
                {
                    IsMoving = false;
                    return;
                }
            }
            if (Dir == Direciton.Left)
            {
                if (X_coordinate - Speed <0)
                {
                    IsMoving = false;
                    return;
                }
            }
            if (Dir == Direciton.Right)
            {
                if (X_coordinate + Speed+Width >450)
                {
                    IsMoving = false;
                    return;
                }
            }
            #endregion

            //检查有没有和其他元素发生碰撞
            Rectangle rect = GetRectangle();


            switch (Dir)
            {
                case Direciton.Up:
                    rect.Y-= Speed;
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

            if (GameObjectManager.IsCollidedWall(rect)!=null)
            {
                IsMoving = false;
                return;
            }

            if (GameObjectManager.IsCollidedSteel(rect) != null)
            {
                IsMoving = false;
                return;
            }

            if (GameObjectManager.IsCollidedBoss(rect))
            {
                IsMoving = false;
                return;
            }
         
        }

        private void move()
        {
            if (IsMoving == false)
            { 
            return;
            }
            switch (Dir)
            {
                case Direciton.Up:
                    Y_coordinate-=Speed;
                    break; 
                case Direciton.Down:
                    Y_coordinate+=Speed;
                    break;
                 case Direciton.Left:
                    X_coordinate-=Speed;
                    break;
                 case Direciton.Right:
                    X_coordinate+=Speed;        
                    break;  
                        

            }
        }
        public  void keydonw(KeyEventArgs args)
        {
            switch(args.KeyCode)
            {
                case Keys.W:
                    Dir= Direciton.Up;
                    IsMoving= true;
                    break;
                case Keys.S:
                    Dir= Direciton.Down;
                    IsMoving = true;
                    break;
                case Keys.D:    
                    Dir= Direciton.Right;
                    IsMoving = true;
                    break;
                case Keys.A:    
                    Dir= Direciton.Left;
                    IsMoving = true;
                    break;


            }

        }
        public  void keyup(KeyEventArgs args)
        {
            switch (args.KeyCode)
            {
                case Keys.W:
                   
                    IsMoving = false;
                    break;
                case Keys.S:
                  
                    IsMoving = false;
                    break;
                case Keys.D:
                   
                    IsMoving = false;
                    break;
                case Keys.A:
                   
                    IsMoving = false;
                    break;


            }

        }

    }
}
