using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace GravityTutorial
{
    class ressources
    {
        public static Texture2D Player_animation, 
            background,
            Button, BackgroundMenuMain, BackgroundMenuPause, Title;

        public static bool[] parameter = new bool[2];


        public static void LoadContent(ContentManager Content)
        {
            //PLAYER
            Player_animation = Content.Load<Texture2D>("walkpetit");

            //GAME
            background = Content.Load<Texture2D>("back");

            //MENU
            Button = Content.Load<Texture2D>("bouttons");
            BackgroundMenuMain = Content.Load<Texture2D>("backgroundmenu");
            BackgroundMenuPause = Content.Load<Texture2D>("backgroundmenugris");
            Title = Content.Load<Texture2D>("title");

            //PARAMETERS
            parameter[0] = false; //Musique
            parameter[1] = true; //Bruitages
        }

    }
}
