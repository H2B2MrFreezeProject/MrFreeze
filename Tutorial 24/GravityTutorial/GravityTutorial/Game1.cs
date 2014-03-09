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
        SoundEffect effect;
        SoundEffectInstance effect2;
        

        Song song;

        //PLAYER
        Character player;

        //VIEWPORT & Map
        Map map;
        Camera camera;
        int block_size = 70;

        //VIDEO
        VideoPlayer VidPlayer;
        Video vid;
        Rectangle vidRectangle;
        int level = 1;

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
            this.graphics.IsFullScreen = true;
            //this.Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {     
  
            map = new Map();

            VidPlayer = new VideoPlayer();

            menu = new Menu(Menu.MenuType.none, 0, ressources.BackgroundMenuMain);
            inGame = false;

            base.Initialize();
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ressources.LoadContent(Content);


            // VIDEO DISPLAY
            vid = Content.Load<Video>("vid");
            vidRectangle = new Rectangle(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y,
                GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            if (level == 0)
            {
                VidPlayer.Play(vid);
            }

            //MENU GENERATION
            menu = menu.ChangeMenu(Menu.MenuType.welcome);


            // MAP GENERARATION
            Tile.Content = Content;
            camera = new Camera(GraphicsDevice.Viewport);
            map.Generate(new int[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,},
                {0,0,0,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {1,1,1,2,2,0,0,0,0,0,0,0,0,1,1,1,1,0,0,1,2,2,2,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,},
             },block_size);

            
            // PLAYER CREATION
            player = new Character(ressources.Player_animation, new Vector2(0, 0));


            //SOND
            effect = Content.Load<SoundEffect>("SF-course_sable1");
            effect2 = effect.CreateInstance();

            song = Content.Load<Song>("DRUM&BASS");

            if (ressources.parameter[0])
            {
                MediaPlayer.Play(song);
                MediaPlayer.Volume = 0.1f;
            }
        }


        protected override void UnloadContent()
        {
        }


        protected override void Update(GameTime gameTime)
        {
            
            if (Keyboard.GetState().IsKeyDown(Keys.Enter)) Exit();
            if (exitgame)
                this.Exit();
            switch (level)
            {
                case 0:
                    if (VidPlayer.State == MediaState.Stopped)
                    {
                        level = 1;
                    }
                    break;
                case 1:
                    if (inGame)
                    {
                        player.Update(gameTime, effect2);
                        foreach (CollisionTiles tile in map.CollisionTiles)
                        {
                            player.Collision(tile.Rectangle, map.Width, map.Height, effect2);
                            camera.update(player.position, map.Width, map.Height);
                        }
                    }
                    else
                    {
                        menu.Update(Mouse.GetState(), Keyboard.GetState(), ref menu);
                    }
                    break;
            }
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //PROCESS
            switch (level)
            {
                case 0:
                    spriteBatch.Begin();
                    spriteBatch.Draw(VidPlayer.GetTexture(), vidRectangle, Color.White);
                    break;
                case 1:
                    if (inGame)
                    {
                        spriteBatch.Begin(SpriteSortMode.Deferred,
                                BlendState.AlphaBlend,
                                null, null, null, null,
                                camera.Transform);
                        spriteBatch.Draw(ressources.background, new Rectangle(0, -200, map.Width, GraphicsDevice.Viewport.Height + 200), Color.White);
                        map.Draw(spriteBatch);
                        player.Draw(spriteBatch);
                    }
                    else
                    {
                        spriteBatch.Begin();
                        menu.Draw(spriteBatch);
                    }
                    break;
            }
            

            //ENDING
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}