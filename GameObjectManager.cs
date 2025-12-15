using C_sharpe_3tankfight.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_sharpe_3tankfight
{
    internal class GameObjectManager
    {
        private static List<Stationary_Obj> Wall_List = new List<Stationary_Obj>();
        private static List<Stationary_Obj> Steel_List = new List<Stationary_Obj>();
        private static List<Enemy_Tank> Enemytank_List = new List<Enemy_Tank>();
        private static List<Bullet> Bullet_List = new List<Bullet>();
        private static List<explosion> explosions_List=new List<explosion>();
        private static Stationary_Obj Boss;
        private static MyTank myTank;
        private static Bullet bullet; 


        private static int enemyBornSpeed = 60;
        private static int enemyBornCount = 60;
         private static Point[] points = new Point[3];



        public static void Update()
        {
            EnemyBorn();
            foreach (Stationary_Obj wallbick in Wall_List)
            {
                wallbick.Update();
            }
            foreach (Stationary_Obj steels in Steel_List)
            {
                steels.Update();
            }

            foreach(Enemy_Tank tank in Enemytank_List)
            {
                tank.Update();
            }

            ChecandDestroyBullet();
            foreach (Bullet bullet in Bullet_List)
            {
                bullet.Update();
             }
           
            foreach(explosion exp in explosions_List)
            {
                exp.Update();
            }
            ChecandDestroyExp();



            Boss.Update();
            myTank.Update();

         

        }


        public static void Start()
        {
           
            points[0].X = 0;
            points[0].Y = 0;
            points[1].X = 7*30;
            points[1].Y = 0;
            points[2].X = 14*30;    
            points[2].Y = 0;
        }


        public static void CreateBullet(int x, int y,Source tag, Direciton dir)
        {
             bullet = new Bullet(x, y, 5, dir,tag);
           
                Bullet_List.Add(bullet);
           
        }
        public static void ChecandDestroyBullet()
        {
            List<Bullet> NeedToDestroy = new List<Bullet>();
            foreach (Bullet bullet in Bullet_List)
            {
                if(bullet.IsbulletDestory==true)
                {
                    NeedToDestroy.Add(bullet);
                }
            }
            foreach(Bullet bullet in NeedToDestroy)
            {
                Bullet_List.Remove(bullet);
            }

        }



        public static void ChecandDestroyExp()
        {
            List<explosion> NeedToDestroy = new List<explosion>();
            foreach (explosion exp in explosions_List)
            {
                if (exp.isDestory_explosion == true)
                {
                    NeedToDestroy.Add(exp);
                }
            }
            foreach (explosion exp in NeedToDestroy)
            {
                explosions_List.Remove(exp);
            }

        }


        public static void CreateExplosion( int x,int y)
        {
            explosion exp = new explosion(x, y);
            explosions_List.Add(exp);
        }


        public static void DestroyWall(Stationary_Obj wall)
        {
            Wall_List.Remove(wall); 
        }

     
        private static void EnemyBorn()
        {
            enemyBornCount++;
            if (enemyBornCount <enemyBornSpeed)
            {
              return;
            }
            //generate enemy
            //Random rd = new Random();
           Random rd = new Random();
        int index = rd.Next(0, 3);
            Point position = points[index];
            int enemyType = rd.Next(1, 5);
            switch(enemyType)
            {
                case 1:
                    CreateEnemyTank1(position.X, position.Y);
                    break;
                case 2:
                    CreateEnemyTank2(position.X, position.Y);
                    break;
                case 3:
                    CreateEnemyTank3(position.X, position.Y);
                    break;
                case 4:
                    CreateEnemyTank4(position.X, position.Y);
                    break;

            }


            enemyBornCount = 0;
        }




        private static void CreateEnemyTank1(int x, int y)
        { 
            Enemy_Tank tank =new Enemy_Tank(x,y,3,Resources.GrayDown,Resources.GrayUp,Resources.GrayLeft,Resources.GrayRight);
            Enemytank_List.Add(tank);

        }

        private static void CreateEnemyTank2(int x, int y)
        {
            Enemy_Tank tank = new Enemy_Tank(x, y, 3, Resources.GreenDown, Resources.GreenUp, Resources.GreenLeft, Resources.GreenRight);
            Enemytank_List.Add(tank);
        }

        private static void CreateEnemyTank3(int x, int y)
        {
            Enemy_Tank tank = new Enemy_Tank(x, y, 5, Resources.QuickDown, Resources.QuickUp, Resources.QuickLeft, Resources.QuickRight);
            Enemytank_List.Add(tank);
        }
        private static void CreateEnemyTank4(int x, int y)
        {
            Enemy_Tank tank = new Enemy_Tank(x, y, 2, Resources.SlowDown, Resources.SlowUp, Resources.SlowLeft, Resources.SlowRight);
            Enemytank_List.Add(tank);
        }

        public static Stationary_Obj IsCollidedWall(Rectangle rt)
        {

            foreach (Stationary_Obj wall in Wall_List)
            {
               if(wall.GetRectangle().IntersectsWith(rt))
                {
                    return wall;
                }
                    }
            return null;
        }



        public static Stationary_Obj IsCollidedSteel(Rectangle rt)
        {

            foreach (Stationary_Obj steel in Steel_List)
            {
                if (steel.GetRectangle().IntersectsWith(rt))
                {
                    return steel;
                }
            }
            return null;
        }

        public static bool IsCollidedBoss(Rectangle rt)
        {
            return Boss.GetRectangle().IntersectsWith(rt);
        }
        public static Enemy_Tank IsCollidedEnemyTank(Rectangle rt)
        {
            foreach(Enemy_Tank tank in Enemytank_List)
            {
                if (tank.GetRectangle().IntersectsWith(rt))
                {
                    return tank;
                }

            }
            return null;


        }
        public static MyTank IsCollidedMyTank(Rectangle rt)
        {
            if(myTank.GetRectangle().IntersectsWith(rt)) return myTank;

            else return null;


        }

        public static void DestroyTank(Enemy_Tank tank)
        {

            Enemytank_List.Remove(tank);
        }

        public static void CreateMap()
        {
            CreateWall(1, 1, 5,Resources.wall, Wall_List);
            CreateWall(3, 1, 5, Resources.wall, Wall_List);
            CreateWall(5, 1, 4, Resources.wall, Wall_List);
            CreateWall(7, 1, 3, Resources.wall, Wall_List);
            CreateWall(9, 1, 4, Resources.wall, Wall_List);
            CreateWall(11, 1, 5, Resources.wall, Wall_List);
            CreateWall(13, 1, 5, Resources.wall, Wall_List);
            CreateWall(2, 7, 1, Resources.wall, Wall_List);
            CreateWall(3, 7, 1, Resources.wall, Wall_List);
            CreateWall(4, 7, 1, Resources.wall, Wall_List);// 编写横向建墙的代码

            CreateWall(6, 7, 1, Resources.wall, Wall_List);
            CreateWall(7, 6, 2, Resources.wall, Wall_List);
            CreateWall(8, 7, 1, Resources.wall, Wall_List);

            CreateWall(10, 7, 1, Resources.wall, Wall_List);
            CreateWall(11, 7, 1, Resources.wall, Wall_List);
            CreateWall(12, 7, 1, Resources.wall, Wall_List);


            CreateWall(1, 9, 5, Resources.wall, Wall_List);
            CreateWall(3, 9, 5, Resources.wall, Wall_List);
            CreateWall(5, 9, 3, Resources.wall, Wall_List);
            CreateWall(9, 9, 3, Resources.wall, Wall_List);
            CreateWall(11, 9, 5, Resources.wall, Wall_List);
            CreateWall(13, 9, 5, Resources.wall, Wall_List);

            CreateWall(6, 10, 1, Resources.wall, Wall_List);
            CreateWall(7, 10, 2, Resources.wall, Wall_List);
            CreateWall(8, 10, 1, Resources.wall, Wall_List);

            CreateWall(6, 13, 2, Resources.wall, Wall_List);
            CreateWall(7, 13, 1, Resources.wall, Wall_List);
            CreateWall(8, 13, 2, Resources.wall, Wall_List);


            CreateWall(7, 4, 1, Resources.steel, Steel_List);
            CreateWall(0, 7, 1, Resources.steel, Steel_List);
            CreateWall(14, 7, 1, Resources.steel, Steel_List);


            CreateBoss(7, 14, Resources.Boss);
        }
        //public static void DrawMap()
        //{
        //    foreach (Stationary_Obj wallbick in Wall_List)
        //    {
        //        wallbick.DrawSelf();
        //    }
        //    foreach (Stationary_Obj steels in Steel_List)
        //    {
        //        steels.DrawSelf();
        //    }
        //    Boss.DrawSelf();
        //}
        //public static void DrawMyThank()
        //{
        //    myTank.DrawSelf();
        //}

        public static void CreateMyTank()
        {
            int x = 5 * 30;
            int y = 14 * 30;
            myTank = new MyTank(x, y, 2);
        }
        private static void CreateBoss(int x,int y,Image img)
        {
            int xPosition = x * 30;
            int yPosition = y * 30;
             Boss = new Stationary_Obj(xPosition, yPosition, img);

        }
        private static void CreateWall( int X, int Y, int count, Image img, List<Stationary_Obj> Wall_List) //wall  start address X,Y and length count _x,y
        {
            //List<Stationary_Obj> Wall_List = new List<Stationary_Obj>();
            int Xposition = X * 30;  //one image =30 pixels
            int Yposition = Y * 30;
            for (int i = Yposition; i < Yposition + count * 30; i += 15)
            {

                //i  xPosition  I xPosition+15



                Stationary_Obj wall1 = new Stationary_Obj(Xposition, i, img);
                Stationary_Obj wall2 = new Stationary_Obj(Xposition+15, i, img);
                Wall_List.Add(wall1);
                Wall_List.Add(wall2);

            }
            
        }

        public static void keydonw(KeyEventArgs args)
        {
            myTank.keydonw(args);

        }
        public static void keyup(KeyEventArgs args)
        {

            myTank.keyup(args);
        }
    }
}
