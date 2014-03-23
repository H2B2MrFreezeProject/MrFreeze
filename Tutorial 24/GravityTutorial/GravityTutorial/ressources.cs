using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace GravityTutorial
{
    public class Ressource
    {
        public static Texture2D Player_animation, 
            background,
            Button, BackgroundMenuMain, BackgroundMenuPause, Title;

        public static bool[] parameter = new bool[2];


        public enum inGameAction
        {
            Up,
            Down,
            Left,
            Right,
            Jump,
            Pause,
        };

        public static Dictionary<Ressource.inGameAction, Microsoft.Xna.Framework.Input.Keys> Key = 
            new Dictionary<Ressource.inGameAction, Microsoft.Xna.Framework.Input.Keys>();


        public static void LoadContent(ContentManager Content)
        {
            //PLAYER
            Player_animation = Content.Load<Texture2D>("walkpetit");

            //GAME
            background = Content.Load<Texture2D>("back");

            //TOUCHES
            Key.Add(inGameAction.Up, Keys.Up);
            Key.Add(inGameAction.Down, Keys.Down);
            Key.Add(inGameAction.Left, Keys.Left);
            Key.Add(inGameAction.Right, Keys.Right);
            Key.Add(inGameAction.Jump, Keys.Space);
            Key.Add(inGameAction.Pause, Keys.Escape);

            //MENU
            Button = Content.Load<Texture2D>("bouttons");
            BackgroundMenuMain = Content.Load<Texture2D>("backgroundmenu");
            BackgroundMenuPause = Content.Load<Texture2D>("backgroundmenugris");
            Title = Content.Load<Texture2D>("title");

            //PARAMETERS
            parameter[0] = true; //Musique
            parameter[1] = true; //Bruitages
        }

    }

    static class RectangleHelper
    {
        public static bool isOnTopOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Bottom >= r2.Top &&
                r1.Bottom <= r2.Top + (r2.Height / 2) &&
                r1.Right >= r2.Left + r2.Width / 5 &&
                r1.Left <= r2.Right - (r2.Width / 5));
        }
        public static bool isOnBotOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Top <= r2.Bottom + (r2.Height / 5) &&
                r1.Top >= r2.Bottom - 1 &&
                r1.Right >= r2.Left + (r2.Width / 10) &&
                r1.Left <= r2.Right - (r2.Width / 10));
        }
        public static bool isOnLeftOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Right <= r2.Right &&
                r1.Right >= r2.Left - 5 &&
                r1.Top <= r2.Bottom - (r2.Width / 4) &&
                r1.Bottom >= r2.Top + (r2.Height / 4));
        }
        public static bool isOnRightOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Left >= r2.Left &&
                r1.Left <= r2.Right + 5 &&
                r1.Top <= r2.Bottom - (r2.Width / 4) &&
                r1.Bottom >= r2.Top + (r2.Height / 4));
        }
    }
}
