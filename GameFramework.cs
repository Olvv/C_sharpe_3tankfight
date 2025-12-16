using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_sharpe_3tankfight
{
    enum GameState 
    {
        Running,
        Gameover
    }

    internal class GameFramework
    {
        public static Graphics graph;
        private static GameState gameState = GameState.Running;
        public static void Start()
        {
            //prepare the game environment before game begin
            SoundManger.InitSound();
            GameObjectManager.Start();
            GameObjectManager.CreateMap();
            GameObjectManager.CreateMyTank();
            SoundManger.PlayStart();
        }

        public static void Update()
        {
            //update the game state, such as player position, enemy position, etc.
            //related to FPS
            // GameObjectManager.DrawMap();
            //GameObjectManager.DrawMyThank();

            if (gameState == GameState.Running)
            {
                GameObjectManager.Update();
            }
            else if (gameState == GameState.Gameover)
            {
                GameoverUpdate();
            }
        }
        public static void Gameover()
        {

            gameState = GameState.Gameover;
        }
        private static void GameoverUpdate()
        {
            int x= 450 / 2- Properties.Resources.GameOver.Width/2;
            int y = 450 / 2 -Properties.Resources.GameOver.Height / 2;
            graph.DrawImage(Properties.Resources.GameOver, x, y);
        }

    }

 }

