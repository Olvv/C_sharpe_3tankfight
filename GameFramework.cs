using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_sharpe_3tankfight
{
    internal class GameFramework
    {
        public static Graphics  graph ;
        public static void Start()
        {
            //prepare the game environment before game begin
            GameObjectManager.Start();
            GameObjectManager.CreateMap();
            GameObjectManager.CreateMyTank();
        }

        public static void Update()
        {
            //update the game state, such as player position, enemy position, etc.
            //related to FPS
            // GameObjectManager.DrawMap();
            //GameObjectManager.DrawMyThank();
            GameObjectManager.Update();
        }

      
    }
}   
