using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GravityTutorial
{
    class Bonus : Item
    {
        public Bonus(Vector2 pos, Texture2D texture, Item.Type type, int nb_texture) :
            base (pos, texture, type, nb_texture) 
        { 
        
        }


        public override void Update(Character player, Hud score)
        {
            if (player.rectangle.Collide_object(hitbox) && !hasBeenTaken)
            {
                player.CurrentItem = type;
                hasBeenTaken = true;
            }
        }
    }
}
