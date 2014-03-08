using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GravityTutorial
{
    public class Menu
    {
        //FIELDS
        int nbButton;
        public MenuButton[] Buttons;

        int nbSwitchButton;
        public SwitchButton[] SButtons;

        public Title title;
        public Texture2D background;

        public MenuType actualType;
        public MenuType previousType;

        public bool cooldown;

        public enum MenuType
        {
            none,
            close,
            welcome,
            play,
            option,
            pause,
            freeplay,
            adventure,
            unpause,
            reloadlevel
        }

        //CONSTRUCTOR
        public Menu(MenuType type, int nbButton, Texture2D background, int nbSwitchButton = 0)
        {
            this.nbButton = nbButton;
            Buttons = new MenuButton[nbButton];

            this.actualType = type;
            this.previousType = MenuType.none;

            this.cooldown = true;

            this.background = background;

            this.nbSwitchButton = nbSwitchButton;
            SButtons = new SwitchButton[nbSwitchButton];
        }
        //METHODS
        public Menu ChangeMenu(MenuType type)
        {
            Menu actualMenu;
            actualMenu = this;

            int Xtitle = 300;
            int Ytitle = 50;

            int Xbutton = 400;
            int Ybutton0 = 350;
            int Ybutton1 = 450;
            int Ybutton2 = 550;

            switch (type)
            {
                case MenuType.none:
                    break;
                case MenuType.close:
                    {
                        Game1.exitgame = true;
                        break;
                    }

                case MenuType.welcome:
                    {
                        actualMenu = new Menu(type, 3, ressources.BackgroundMenuMain);
                        actualMenu.title = new Title(new Vector2(Xtitle, Ytitle), 0);
                        actualMenu.Buttons[0] = new MenuButton(new Vector2(Xbutton, Ybutton0), 0, MenuType.play);
                        actualMenu.Buttons[1] = new MenuButton(new Vector2(Xbutton, Ybutton1), 1, MenuType.option);
                        actualMenu.Buttons[2] = new MenuButton(new Vector2(Xbutton, Ybutton2), 2, MenuType.close);
                        actualMenu.previousType = MenuType.none;
                        break;
                    }
                case MenuType.play:
                    {
                        actualMenu = new Menu(type, 3, ressources.BackgroundMenuMain);
                        actualMenu.title = new Title(new Vector2(Xtitle, Ytitle), 1);
                        actualMenu.Buttons[0] = new MenuButton(new Vector2(Xbutton, Ybutton0), 3, MenuType.adventure);
                        actualMenu.Buttons[1] = new MenuButton(new Vector2(Xbutton, Ybutton1), 4, MenuType.freeplay);
                        actualMenu.Buttons[2] = new MenuButton(new Vector2(Xbutton, Ybutton2), 8, this.actualType);
                        actualMenu.previousType = this.actualType;
                        break;
                    }
                case MenuType.option:
                    {
                        actualMenu = new Menu(type, 1, ressources.BackgroundMenuMain, 2);
                        actualMenu.title = new Title(new Vector2(Xtitle, Ytitle), 2);
                        actualMenu.SButtons[0] = new SwitchButton(new Vector2(Xbutton, Ybutton0), 9, 10, 0);
                        actualMenu.SButtons[1] = new SwitchButton(new Vector2(Xbutton, Ybutton1), 11, 12, 1);
                        actualMenu.Buttons[0] = new MenuButton(new Vector2(Xbutton, Ybutton2), 8, this.actualType);
                        break;
                    }
                case MenuType.pause:
                    {
                        actualMenu = new Menu(type, 3, ressources.BackgroundMenuMain);
                        actualMenu.title = new Title(new Vector2(Xtitle, Ytitle), 4);
                        actualMenu.Buttons[0] = new MenuButton(new Vector2(Xbutton, Ybutton0), 7, MenuType.unpause);
                        actualMenu.Buttons[1] = new MenuButton(new Vector2(Xbutton, Ybutton1), 5, MenuType.reloadlevel);
                        actualMenu.Buttons[2] = new MenuButton(new Vector2(Xbutton, Ybutton2), 6, MenuType.welcome);
                        actualMenu.previousType = this.actualType;
                        break;
                    }
                case MenuType.freeplay:
                    {
                        Game1.inGame = true;
                        //Précharge la pause
                        actualMenu = new Menu(MenuType.pause, 3, ressources.BackgroundMenuPause);
                        actualMenu.title = new Title(new Vector2(Xtitle, Ytitle), 4);
                        actualMenu.Buttons[0] = new MenuButton(new Vector2(Xbutton, Ybutton0), 7, MenuType.unpause);
                        actualMenu.Buttons[1] = new MenuButton(new Vector2(Xbutton, Ybutton1), 5, MenuType.reloadlevel);
                        actualMenu.Buttons[2] = new MenuButton(new Vector2(Xbutton, Ybutton2), 6, MenuType.welcome);
                        actualMenu.previousType = this.actualType;
                        break;
                    }
                case MenuType.adventure:
                    {
                        Game1.inGame = true;
                        //Précharge la pause
                        actualMenu = new Menu(MenuType.pause, 3, ressources.BackgroundMenuPause);
                        actualMenu.title = new Title(new Vector2(Xtitle, Ytitle), 4);
                        actualMenu.Buttons[0] = new MenuButton(new Vector2(Xbutton, Ybutton0), 7, MenuType.unpause);
                        actualMenu.Buttons[1] = new MenuButton(new Vector2(Xbutton, Ybutton1), 5, MenuType.reloadlevel);
                        actualMenu.Buttons[2] = new MenuButton(new Vector2(Xbutton, Ybutton2), 6, MenuType.welcome);
                        actualMenu.previousType = this.actualType;
                        break;
                    }
                case MenuType.unpause:
                    {
                        Game1.inGame = true;
                        //Précharge la pause
                        actualMenu = new Menu(MenuType.pause, 3, ressources.BackgroundMenuPause);
                        actualMenu.title = new Title(new Vector2(Xtitle, Ytitle), 4);
                        actualMenu.Buttons[0] = new MenuButton(new Vector2(Xbutton, Ybutton0), 7, MenuType.unpause);
                        actualMenu.Buttons[1] = new MenuButton(new Vector2(Xbutton, Ybutton1), 5, MenuType.reloadlevel);
                        actualMenu.Buttons[2] = new MenuButton(new Vector2(Xbutton, Ybutton2), 6, MenuType.welcome);
                        actualMenu.previousType = this.actualType;
                        break;
                    }
                case MenuType.reloadlevel:
                    {
                        Game1.inGame = true;

                        // HADRIEN : Met ici ton code pour reload le niveau !!


                        //Précharge la pause
                        actualMenu = new Menu(MenuType.pause, 3, ressources.BackgroundMenuPause);
                        actualMenu.title = new Title(new Vector2(Xtitle, Ytitle), 4);
                        actualMenu.Buttons[0] = new MenuButton(new Vector2(Xbutton, Ybutton0), 7, MenuType.unpause);
                        actualMenu.Buttons[1] = new MenuButton(new Vector2(Xbutton, Ybutton1), 5, MenuType.reloadlevel);
                        actualMenu.Buttons[2] = new MenuButton(new Vector2(Xbutton, Ybutton2), 6, MenuType.welcome);
                        actualMenu.previousType = this.actualType;
                        break;
                    }
                default:
                    {
                        actualMenu = new Menu(type, 0, ressources.BackgroundMenuMain);
                        actualMenu.title = new Title(new Vector2(Xtitle, Ytitle), 0);
                        actualMenu.previousType = this.actualType;
                        break;
                    }
            }
            return actualMenu;
        }


        //UPDATE & DRAW
        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.actualType == MenuType.pause)
            {
                // HADRIEN : Met ici ton code qui draw le jeu normalement (hors pause)
            }
            spriteBatch.Draw(this.background, new Rectangle(0, 0, 1600, 900), new Rectangle(0, 0, 1600, 900), Color.White);
            foreach (MenuButton b in Buttons)
            {
                b.Draw(spriteBatch);
            }

            foreach (SwitchButton b in SButtons)
            {
                b.Draw(spriteBatch);
            }
            title.Draw(spriteBatch);
        }

        public void Update(MouseState mouse, KeyboardState keyboard, ref Menu menu)
        {

            if (!menu.cooldown &
                mouse.LeftButton == ButtonState.Released &
                keyboard.IsKeyUp(Keys.Escape))
            {
                menu.cooldown = true;
            }


            foreach (MenuButton b in menu.Buttons)
            {
                if (mouse.LeftButton == ButtonState.Pressed
                    & mouse.X >= b.pos.X
                    & mouse.X <= b.pos.X + b.SpriteWidth
                    & mouse.Y >= b.pos.Y
                    & mouse.Y <= b.pos.Y + b.SpriteHeight
                    & b.nextMenu != MenuType.none
                    & cooldown)
                {
                    menu = ChangeMenu(b.nextMenu);
                    menu.cooldown = false;
                    return;
                }
            }

            foreach (SwitchButton b in SButtons)
            {
                if (mouse.LeftButton == ButtonState.Pressed
                    & mouse.X >= b.pos.X
                    & mouse.X <= b.pos.X + b.SpriteWidth
                    & mouse.Y >= b.pos.Y
                    & mouse.Y <= b.pos.Y + b.SpriteHeight
                    & cooldown)
                {
                    b.Update();
                    menu.cooldown = false;
                    return;
                }
            }

        }

        public class Title
        {
            //FIELDS
            Vector2 pos;
            Rectangle hitbox;

            int SpriteHeight;
            int SpriteWidth;
            int FrameLine;


            //CONSTRUCTOR
            public Title(Vector2 pos, int FrameLine)
            {
                this.pos = pos;
                this.FrameLine = FrameLine;
                SpriteHeight = 250;
                SpriteWidth = 700;
                this.hitbox = new Rectangle((int)pos.X, (int)pos.Y, this.SpriteWidth, this.SpriteHeight);
            }

            //METHODS

            //UPDATE & DRAW
            public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(ressources.Title, this.hitbox, new Rectangle(0, this.FrameLine * this.SpriteHeight, this.SpriteWidth, this.SpriteHeight),
                    Color.White);
            }

        }

        public class MenuButton : Button
        {
            //FIELDS
            public Menu.MenuType nextMenu;


            //CONSTRUCTOR
            public MenuButton(Vector2 pos, int FrameLine, Menu.MenuType nextMenu)
                : base(pos, FrameLine)
            {
                this.nextMenu = nextMenu;
            }

            //METHODS

            //UPDATE & DRAW
            public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(ressources.Button, this.hitbox, new Rectangle(0, this.FrameLine * this.SpriteHeight, this.SpriteWidth, this.SpriteHeight),
                    Color.White);
            }

        }

        public class Button
        {
            //FIELDS
            public Vector2 pos;
            protected Rectangle hitbox;

            public int SpriteHeight;
            public int SpriteWidth;
            protected int FrameLine;

            //CONSTRUCTOR
            public Button(Vector2 pos, int FrameLine)
            {
                this.pos = pos;
                this.FrameLine = FrameLine;
                SpriteHeight = 75;
                SpriteWidth = 500;
                this.hitbox = new Rectangle((int)pos.X, (int)pos.Y, this.SpriteWidth, this.SpriteHeight);
            }
        }

        public class SwitchButton : Button
        {
            //FIELDS
            int nbParameter;
            int FrameLineTrue;
            int FrameLineFalse;

            //CONSTRUCTOR
            public SwitchButton(Vector2 pos, int FrameLineTrue, int FrameLineFalse, int nbParameter)
                : base(pos, FrameLineTrue)
            {
                this.FrameLineTrue = FrameLineTrue;
                this.FrameLineFalse = FrameLineFalse;
                this.nbParameter = nbParameter;

                if (ressources.parameter[nbParameter])
                {
                    this.FrameLine = FrameLineFalse;
                }
            }

            //METHODS

            //UPDATE & DRAW
            public void Draw(SpriteBatch spriteBatch)
            {
                if (ressources.parameter[nbParameter])
                {
                    this.FrameLine = FrameLineTrue;
                }
                else
                {
                    this.FrameLine = FrameLineFalse;
                }

                spriteBatch.Draw(ressources.Button,
                    this.hitbox,
                    new Rectangle(0, this.FrameLine * this.SpriteHeight, this.SpriteWidth, this.SpriteHeight),
                    Color.White);
            }

            public void Update()
            {
                ressources.parameter[this.nbParameter] = !ressources.parameter[this.nbParameter];
            }
        }



    }
}
