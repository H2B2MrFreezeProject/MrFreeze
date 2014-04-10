using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace GravityTutorial
{
    public static class Ressource
    {
        public static Texture2D Player_animation, 
            background,
            Button, BackgroundMenuMain, BackgroundMenuPause, Title, 
            Gold, Loser;

        public static SpriteFont Font;
        public static SpriteFont MenuPolice, ArialDefaultMenu;

        public static SoundEffect effect;
        public static Song song;
        public static SoundEffectInstance effect2;

        public static Video vid;

        public static bool[] parameter = new bool[2];

        public enum inGameAction
        {
            Left,
            Right,
            Jump,
            Pause,
        };

        public static Dictionary<Ressource.inGameAction, Microsoft.Xna.Framework.Input.Keys> Key =
           new Dictionary<Ressource.inGameAction, Microsoft.Xna.Framework.Input.Keys>();

        public static int screenHeight, screenWidth;

        public static void LoadContent(ContentManager Content)
        {
            //FILES
            string MenuFile = "MenuRessources\\";
            //string TileFile = "TileRessources\\";
            string CharacterFile = "CharacterRessources\\";
            string MusicFile = "MusicRessources\\";
            //string MiscFile = "MiscRessources\\";
            string BonusFile = "BonusRessources\\";
            string InGameFile = "InGameRessources\\";

            //PLAYER
            Player_animation = Content.Load<Texture2D>(CharacterFile + "walkpetit");

            //GAME
            background = Content.Load<Texture2D>(InGameFile + "back");
            Loser = Content.Load<Texture2D>(InGameFile + "bleucrash");

            //TOUCHES
            Key.Add(inGameAction.Left, Keys.Left);
            Key.Add(inGameAction.Right, Keys.Right);
            Key.Add(inGameAction.Jump, Keys.Space);
            Key.Add(inGameAction.Pause, Keys.Escape);

            //MENU
            Button = Content.Load<Texture2D>(MenuFile + "boutton");
            BackgroundMenuMain = Content.Load<Texture2D>(MenuFile + "backgroundmenu");
            BackgroundMenuPause = Content.Load<Texture2D>(MenuFile + "backgroundmenugris");
            Title = Content.Load<Texture2D>(MenuFile + "title");
            MenuPolice = Content.Load<SpriteFont>(MenuFile + "MenuFont");
            ArialDefaultMenu = Content.Load<SpriteFont>(MenuFile + "ArialDefaultMenu");

            //PARAMETERS
            parameter[0] = false; //Musique
            parameter[1] = true; //Bruitages

            //FONT
            Font = Content.Load<SpriteFont>(InGameFile + "Arial");

            //BONUS
            Gold = Content.Load<Texture2D>(BonusFile + "gold");

            //SOUND 
            effect = Content.Load<SoundEffect>(MusicFile + "SF-course_sable1");
            effect2 = effect.CreateInstance();
            song = Content.Load<Song>(MusicFile + "DRUM&BASS");

            //INTRO
            vid = Content.Load<Video>("vid");
        }

    }
}
