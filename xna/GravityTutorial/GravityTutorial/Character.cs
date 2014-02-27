﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace GravityTutorial
{
    public enum Direction
    { 
        Right,
        Left
    };
    class Character
    {
        //DEFINITION
        Texture2D texture;
        int nbr_sprite = 7;
        int player_Height = 70;
        int player_Width = 55;

        public Vector2 position;
        public Vector2 velocity;

        //SAUT
        public bool hasJumped;
        public int saut = 5;

        //HITBOX
        public Rectangle rectangle;

        //ANIMATION
        int frameCollumn;
        int frameLine;
        SpriteEffects Effect;
        Direction Direction;
        int Timer;
        int AnimationSpeed = 5;



        public Character(Texture2D newTexture, Vector2 newPosition)
        {
            texture = newTexture;

            position = newPosition;
            hasJumped = true;
            this.Timer = 0;
            this.frameCollumn = 1;
            this.frameLine = 1;

        }


        public void Animate()
        {
            this.Timer++;
            if (this.Timer == this.AnimationSpeed)
            {
                this.Timer = 0;
                this.frameCollumn++;
                if (this.frameCollumn > nbr_sprite)
                {
                    this.frameCollumn = 2;
                }
            }
        }

        public void Update(GameTime gameTime, SoundEffect effect)
        {
            //MECANISME
            position += velocity;
            if (hasJumped)
            {
                this.frameLine = 2;
            }
            else
            {
                this.frameLine = 1;
            }
            rectangle = new Rectangle((int)position.X, (int)position.Y, player_Width, player_Height);
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                velocity.X = 3f;
                this.Direction = Direction.Right;
                this.Animate();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                velocity.X = -3f;
                this.Direction = Direction.Left;
                this.Animate();
            }
            else
            {
                velocity.X = 0f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false)
            {
                position.Y -= 5f;
                velocity.Y = -saut;
                hasJumped = true;
                effect.Play();
            }
                float i = 1;
                velocity.Y += 0.15f * i;

                //SWITCH POUR GERER EFFECT SUR LE SPRITE
                switch (this.Direction)
                {
                    case Direction.Right:
                        this.Effect = SpriteEffects.None;
                        break;
                    case Direction.Left:
                        this.Effect = SpriteEffects.FlipHorizontally;
                        break;
                }
            
        }
        public void Collision(Rectangle newRectangle, int xoffset, int yoffset)
        {
            Rectangle superrectangle = new Rectangle((int)position.X + (int)velocity.X,(int)position.Y + saut,player_Height,player_Width);
            if (rectangle.isOnTopOf(newRectangle))
            {
                rectangle.Y = newRectangle.Y - rectangle.Height + 10;
                velocity.Y = 0;
                hasJumped = false;
            }
            if (rectangle.isOnLeftOf(newRectangle) && Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                position.X = newRectangle.X - rectangle.Width - 3;
            }
            if (rectangle.isOnRightOf(newRectangle) && Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                position.X = newRectangle.X + newRectangle.Width + 3;
            }
            if (superrectangle.isOnBotOf(newRectangle))
            {
                if (velocity.Y < 0)
                {
                    velocity.Y = -velocity.Y;
                }
                position.Y = newRectangle.Bottom + velocity.Y;  
            }

            if (position.X < 0)
            { position.X = 0; }
            if (position.X > xoffset - rectangle.Width)
            { position.X = xoffset - rectangle.Width;}
            if (position.Y < 0)
            { velocity.Y = 1f;}
            if (position.Y > yoffset - rectangle.Height)
            { position.Y= yoffset- rectangle.Height;}
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, rectangle, new Rectangle((this.frameCollumn - 1) * player_Width, (this.frameLine - 1) * player_Height, player_Width, player_Height), Color.Red,0f,new Vector2(0,0),this.Effect,0f);
        }
    }
}
