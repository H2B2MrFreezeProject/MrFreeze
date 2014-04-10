using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GravityTutorial
{
    public class Hud
    {
        public Vector2 position;
        public Vector2 position_timer;
        public int score;
        double timer;
        int cd;
        bool new_cd;
        bool youlose;
        Rectangle loser;

        public Hud(TimeSpan timespan, Vector2 position_data)
        {
            this.score = 0;
            timer = timespan.TotalSeconds;
            this.position = Vector2.One;
            this.position_timer = new Vector2(position_data.X - 100, 10);
            bool new_cd = true;
            loser = new Rectangle(0, 0, (int)position_data.X, (int)position_data.Y);
            
        }

        public void Save(int score, int pseudo)
        {
            
        }

        public void Update()
        {
            if (timer < 0)
            {
                timer = 0;
                youlose = true;
            }
            else
            {
                if (new_cd)
                {
                    //timer--;
                    new_cd = false;
                }
                else
                {
                    cd++;
                }
                if (cd >= 60)
                {
                    cd = 0;
                    new_cd = true;
                }
            }

            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (youlose)
            {
                spriteBatch.Draw(Ressource.Loser, loser, Color.White);
            }
            spriteBatch.DrawString(Ressource.Font,"Score: " + this.score, position, Color.Red);
            spriteBatch.DrawString(Ressource.Font, "Timer: " + this.timer, position_timer, Color.Red);

        }
    }
}
