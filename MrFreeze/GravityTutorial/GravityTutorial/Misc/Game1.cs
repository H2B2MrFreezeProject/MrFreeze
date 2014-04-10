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
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        // GENERAL DATA
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public int height_size;
        public int width_size;


        //LEVEL
        public static Level Level;
        public static Hud score;

        //VIEWPORT & Map
        Camera camera;

        //VIDEO
        VideoPlayer VidPlayer;
        Rectangle vidRectangle;
        bool vidHasBeenPlayed = false;

        //MENU
        public static Boolean exitgame = false;
        Menu menu;
        public static bool inGame;

        //CONSTRUCTOR
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            //this.graphics.IsFullScreen = true;
            this.Window.AllowUserResizing = true;
            this.Window.Title = "MrFreeze";
        }

        protected override void Initialize()
        {
            Level Level = new Level(0);

            VidPlayer = new VideoPlayer();

            score = new Hud(new TimeSpan(0, 0, 10), new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height));

            menu = new Menu(Menu.MenuType.none, 0, Ressource.BackgroundMenuMain);
            inGame = false;

            base.Initialize();
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Ressource.LoadContent(Content);

            // VIDEO DISPLAY
            
            vidRectangle = new Rectangle(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y,
                GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            if (!vidHasBeenPlayed)
            {
                VidPlayer.Play(Ressource.vid);
                vidHasBeenPlayed = true;
            }


            //MENU GENERATION
            menu = menu.ChangeMenu(Menu.MenuType.welcome);


            // MAP GENERARATION
            Tile.Content = Content;
            camera = new Camera(GraphicsDevice.Viewport);

            if (Ressource.parameter[0])
            {
                MediaPlayer.Play(Ressource.song);
                MediaPlayer.Volume = 0.1f;
            }
            else
            {
                MediaPlayer.Stop();
            }
   
        }


        protected override void UnloadContent()
        {
        }


        protected override void Update(GameTime gameTime)
        {
            Ressource.screenWidth = GraphicsDevice.Viewport.Height;
            Ressource.screenHeight = GraphicsDevice.Viewport.Width;
            if (Keyboard.GetState().IsKeyDown(Keys.Enter)) Exit();
            if (exitgame)
                this.Exit();
            

                    if (inGame)
                    {
                        Level.Update(gameTime, Ressource.effect2);
                        score.Update();
                        camera.update(Level.Heroes.ElementAt(0).position, Level.map.Width, Level.map.Height);   
                    }
                    else
                    {
                        menu.Update(Mouse.GetState(), Keyboard.GetState(), ref menu);
                    }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //PROCESS
            /* VIDEO A FIX
                    spriteBatch.Begin();
                    spriteBatch.Draw(VidPlayer.GetTexture(), vidRectangle, Color.White);*/
                    if (inGame)
                    {
                        spriteBatch.Begin(SpriteSortMode.Deferred,
                                BlendState.AlphaBlend,
                                null, null, null, null,
                                camera.Transform);
                        Level.Draw(spriteBatch);
                        spriteBatch.End();


                        // HUD
                        spriteBatch.Begin();
                        score.Draw(spriteBatch);
                        
                    }
                    else
                    {
                        spriteBatch.Begin();
                        menu.Draw(spriteBatch, Mouse.GetState());
                    }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}