﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_sharpe_3tankfight
{
    abstract class GameObject
    {
        public int X_coordinate { get; set; }
        public int Y_coordinate { get; set; }

        protected abstract Image GetImage();
      

        public void DrawSelf()
        {
            Graphics graph=GameFramework.graph;

            graph.DrawImage(GetImage(), X_coordinate, Y_coordinate);

        }
    }
}
