using C_sharpe_3tankfight.Properties;
using System;
using System.Collections.Generic;
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
            move();
            base.Update();
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
