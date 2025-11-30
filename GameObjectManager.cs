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
        private static Stationary_Obj Boss;
        private static MyTank myTank;


        public static void Update()
        {
            foreach (Stationary_Obj wallbick in Wall_List)
            {
                wallbick.Update();
            }
            foreach (Stationary_Obj steels in Steel_List)
            {
                steels.Update();
            }
            Boss.Update();
            myTank.Update();

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
