using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GravityTutorial
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public int height_size;
        public int width_size;
        Rectangle back = new Rectangle(0, 0, 800, 500);
        Character player;



        List<Platform> platforms = new List<Platform>();
        Map map;
        Camera camera;
        // Sound
        SoundEffect effect;
        Song song;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            //this.graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            map = new Map();
            base.Initialize();
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ressources.LoadContent(Content);
            Tile.Content = Content;
            camera = new Camera(GraphicsDevice.Viewport);
            map.Generate(new int[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,},
                {0,0,0,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {1,1,1,1,2,0,0,0,0,0,0,0,0,1,1,1,1,0,0,1,2,2,2,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,},
             },64);

            

            player = new Character(ressources.Player_animation, new Vector2(0, 0));

            effect = Content.Load<SoundEffect>("Effect");
            song = Content.Load<Song>("Song");

            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();

            player.Update(gameTime, effect);
            foreach (CollisionTiles tile in map.CollisionTiles)
            {
                player.Collision(tile.Rectangle, map.Width, map.Height);
                camera.update(player.position, map.Width, map.Height);
            }
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred,
                                BlendState.AlphaBlend,
                                null, null, null, null,
                                camera.Transform);
            spriteBatch.Draw(ressources.background, new Rectangle(0, 0, ressources.background.Width, 500), Color.White);
            map.Draw(spriteBatch);
            player.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
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
            r1.Right >= r2.Left  + (r2.Width / 10) &&
            r1.Left <= r2.Right - (r2.Width  / 10));
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