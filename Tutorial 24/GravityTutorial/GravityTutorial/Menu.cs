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
        int nb_button;
        public Button[] Buttons;

        public Title title;

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
        public Menu(MenuType type, int nb_button)
        {
            this.nb_button = nb_button;
            Buttons = new Button[nb_button];
            this.actualType = type;
            this.previousType = MenuType.none;
            this.cooldown = true;
        }
        //METHODS
        public Menu ChangeMenu(MenuType type)
        {
            Menu actualMenu;
            actualMenu = this;
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
                        actualMenu = new Menu(type, 3);
                        actualMenu.title = new Title(new Vector2(100, 50), 0);
                        actualMenu.Buttons[0] = new Button(new Vector2(100, 350), 0, MenuType.play);
                        actualMenu.Buttons[1] = new Button(new Vector2(100, 450), 1, MenuType.option);
                        actualMenu.Buttons[2] = new Button(new Vector2(100, 550), 2, MenuType.close);
                        actualMenu.previousType = MenuType.none;
                        break;
                    }
                case MenuType.play:
                    {
                        actualMenu = new Menu(type, 2);
                        actualMenu.title = new Title(new Vector2(100, 50), 1);
                        actualMenu.Buttons[0] = new Button(new Vector2(100, 350), 3, MenuType.adventure);
                        actualMenu.Buttons[1] = new Button(new Vector2(100, 450), 4, MenuType.freeplay);
                        actualMenu.previousType = this.actualType;
                        break;
                    }
                case MenuType.option:
                    {
                        //TODO
                        actualMenu = new Menu(type, 0);
                        actualMenu.title = new Title(new Vector2(100, 50), 0);
                        break;
                    }
                case MenuType.pause:
                    {
                        actualMenu = new Menu(type, 3);
                        actualMenu.title = new Title(new Vector2(100, 50), 2);
                        actualMenu.Buttons[0] = new Button(new Vector2(100, 350), 7, MenuType.unpause);
                        actualMenu.Buttons[1] = new Button(new Vector2(100, 450), 5, MenuType.reloadlevel);
                        actualMenu.Buttons[2] = new Button(new Vector2(100, 550), 6, MenuType.welcome);
                        actualMenu.previousType = this.actualType;
                        break;
                    }
                case MenuType.freeplay:
                    {
                        Game1.inGame = true;
                        //Précharge la pause
                        actualMenu = new Menu(type, 3);
                        actualMenu.title = new Title(new Vector2(100, 50), 2);
                        actualMenu.Buttons[0] = new Button(new Vector2(100, 350), 7, MenuType.unpause);
                        actualMenu.Buttons[1] = new Button(new Vector2(100, 450), 5, MenuType.reloadlevel);
                        actualMenu.Buttons[2] = new Button(new Vector2(100, 550), 6, MenuType.welcome);
                        actualMenu.previousType = this.actualType;
                        break;
                    }
                case MenuType.adventure:
                    {
                        Game1.inGame = true;
                        //Précharge la pause
                        actualMenu = new Menu(type, 3);
                        actualMenu.title = new Title(new Vector2(100, 50), 2);
                        actualMenu.Buttons[0] = new Button(new Vector2(100, 350), 7, MenuType.unpause);
                        actualMenu.Buttons[1] = new Button(new Vector2(100, 450), 5, MenuType.reloadlevel);
                        actualMenu.Buttons[2] = new Button(new Vector2(100, 550), 6, MenuType.welcome);
                        actualMenu.previousType = this.actualType;
                        break;
                    }
                case MenuType.unpause:
                    {
                        Game1.inGame = true;
                        //Précharge la pause
                        actualMenu = new Menu(type, 3);
                        actualMenu.title = new Title(new Vector2(100, 50), 2);
                        actualMenu.Buttons[0] = new Button(new Vector2(100, 350), 7, MenuType.unpause);
                        actualMenu.Buttons[1] = new Button(new Vector2(100, 450), 5, MenuType.reloadlevel);
                        actualMenu.Buttons[2] = new Button(new Vector2(100, 550), 6, MenuType.welcome);
                        actualMenu.previousType = this.actualType;
                        break;
                    }
                case MenuType.reloadlevel:
                    {
                        //TODO
                        Game1.inGame = true;
                        //Précharge la pause
                        actualMenu = new Menu(type, 3);
                        actualMenu.title = new Title(new Vector2(100, 50), 2);
                        actualMenu.Buttons[0] = new Button(new Vector2(100, 350), 7, MenuType.unpause);
                        actualMenu.Buttons[1] = new Button(new Vector2(100, 450), 5, MenuType.reloadlevel);
                        actualMenu.Buttons[2] = new Button(new Vector2(100, 550), 6, MenuType.welcome);
                        actualMenu.previousType = this.actualType;
                        break;
                    }
                default:
                    {
                        actualMenu = new Menu(type, 0);
                        actualMenu.title = new Title(new Vector2(100, 50), 0);
                        actualMenu.previousType = this.actualType;
                        break;
                    }
            }
            return actualMenu;
        }

        //UPDATE & DRAW
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ressources.menu_back, new Rectangle(0, 0, 1579, 765), new Rectangle(0, 0, 1579, 765),
                Color.White);
            foreach (Button b in Buttons)
            {
                b.Draw(spriteBatch);
            }
            title.Draw(spriteBatch);
        }

        public void Update(MouseState mouse, ref Menu menu)
        {
            if (!menu.cooldown & mouse.LeftButton == ButtonState.Released)
            {
                menu.cooldown = true;
            }

            foreach (Button b in menu.Buttons)
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
                SpriteHeight = 225;
                SpriteWidth = 700;
                this.hitbox = new Rectangle((int)pos.X, (int)pos.Y, this.SpriteWidth, this.SpriteHeight);
            }

            //METHODS

            //UPDATE & DRAW
            public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(ressources.Titre, this.hitbox, new Rectangle(0, this.FrameLine * this.SpriteHeight, this.SpriteWidth, this.SpriteHeight),
                    Color.White);
            }

        }

        public class Button
        {
            //FIELDS
            public Vector2 pos;
            Rectangle hitbox;

            public int SpriteHeight;
            public int SpriteWidth;
            int FrameLine;

            public Menu.MenuType nextMenu;


            //CONSTRUCTOR
            public Button(Vector2 pos, int FrameLine, Menu.MenuType nextMenu)
            {
                this.pos = pos;
                this.FrameLine = FrameLine;
                SpriteHeight = 75;
                SpriteWidth = 500;
                this.hitbox = new Rectangle((int)pos.X, (int)pos.Y, this.SpriteWidth, this.SpriteHeight);
                this.nextMenu = nextMenu;
            }

            //METHODS

            //UPDATE & DRAW
            public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(ressources.bouton, this.hitbox, new Rectangle(0, this.FrameLine * this.SpriteHeight, this.SpriteWidth, this.SpriteHeight),
                    Color.White);
            }

        }
    }
}