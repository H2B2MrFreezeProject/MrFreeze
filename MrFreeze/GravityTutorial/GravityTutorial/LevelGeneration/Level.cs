using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace GravityTutorial
{
    public class Level
    {
        //FIELDS
        public List<Character> Heroes;
        //List<Ennemy> Ennemies;
        public List<Bonus> Bonuses;

        public Map map;
        public int lvl;

        //CONSRTRUCTOR
        public Level(int lvl)
        {
            this.lvl = lvl;
            map = new Map();
            Heroes = new List<Character>();
            Bonuses = new List<Bonus>();
            switch (lvl)
            {
                case 0:
                    {
                        break;
                    }
                case 1:
                    {
                        int block_size = 70;
                        map.Generate(new int[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,4,0,0,0,0,0,0,},
                {0,0,0,0,4,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,1,0,0,0,0,0,0,1,0,0,4,4,4,0,0,4,0,1,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,},
                {0,0,0,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {1,1,1,2,2,0,0,0,0,0,0,0,0,1,1,1,1,0,0,1,2,2,2,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,},
             }, block_size, this);
                        Heroes.Add(new Character(Ressource.Player_animation, new Vector2(0, 0)));
                        break;
                    }
                default:
                    break;
            }
            //TODO
        }

        //UPDATE & DRAW
        public void Update(GameTime gameTime, SoundEffectInstance effect)
        {
            Heroes.ElementAt(0).Update(gameTime, effect);
            foreach (CollisionTiles tile in map.CollisionTiles)
            {
                Heroes.ElementAt(0).Collision(tile.Rectangle, map.Width, map.Height, Ressource.effect2, tile.Tile_name);
            }
            foreach (Bonus gold in Bonuses)
            {
                if (gold.type == Bonus.Type.Gold)
                {
                    gold.Update(Heroes.ElementAt(0), Game1.score);
                }

            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Ressource.background, new Rectangle(0, -200, map.Width, Ressource.screenHeight + 500), Color.White);
            map.Draw(spriteBatch);
            foreach (Bonus gold in Bonuses)
            {
                if (gold.type == Bonus.Type.Gold)
                {
                    gold.Draw(spriteBatch);
                }
            }




            foreach (Character c in Heroes)
            {
                c.Draw(spriteBatch);
            }

            foreach (Bonus b in Bonuses)
            {
                b.Draw(spriteBatch);
            }


            /*foreach (Ennemy e in Ennemies)
            {
                e.Draw(spriteBatch);
            }

            Map.Draw(spriteBatch);
            //TODO*/
        }


    }

}
