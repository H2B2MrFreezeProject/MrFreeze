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
        public static Texture2D Player_animation,Player_animation_jump, plateform, background;


        public static void LoadContent(ContentManager Content)
        {
            Player_animation = Content.Load<Texture2D>("full-animation-aste");
            Player_animation_jump = Content.Load<Texture2D>("jump");
            plateform = Content.Load<Texture2D>("Platform");
            background = Content.Load<Texture2D>("back");
        }

    }
}
