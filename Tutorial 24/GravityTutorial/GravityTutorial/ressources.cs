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
        public static Texture2D Player_animation, background, menu_back, bouton, Titre;


        public static void LoadContent(ContentManager Content)
        {
            Player_animation = Content.Load<Texture2D>("walkpetit");
            background = Content.Load<Texture2D>("back");
            menu_back = Content.Load<Texture2D>("logo2");
            bouton = Content.Load<Texture2D>("bouttons2");
            Titre = Content.Load<Texture2D>("title2");

        }

    }
}
