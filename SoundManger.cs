using C_sharpe_3tankfight.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace C_sharpe_3tankfight
{
    internal class SoundManger
    {
        private static SoundPlayer startPlayer=new SoundPlayer();
        private static SoundPlayer addPlayer = new SoundPlayer();
        private static SoundPlayer blastPlayer = new SoundPlayer();
        private static SoundPlayer firePlayer = new SoundPlayer();
        private static SoundPlayer hitPlayer = new SoundPlayer();
        public static void InitSound()
        {
              startPlayer.Stream=Resources.start;
              addPlayer.Stream=Resources.add;
            blastPlayer.Stream=Resources.blast;
            firePlayer.Stream=Resources.fire;
            hitPlayer.Stream=Resources.hit;
        }



        public static void PlayStart()
        {

            startPlayer.Play();
        }
        public static void Playadd()
        {

            addPlayer.Play();
        }

        public static void Playblast()
        {

            blastPlayer.Play();
        }

        public static void Playfire()
        {

            firePlayer.Play();
        }

        public static void Playerhit()
        {

            hitPlayer.Play();
        }
    }
}
