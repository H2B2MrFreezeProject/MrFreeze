using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GravityTutorial
{
    public class Menu
    {
        //FIELDS
        int nbButton;
        public MenuButton[] Buttons;

        int nbSwitchButton;
        public SwitchButton[] SButtons;

        int nbControleButton;
        public ControleButton[] CButtons;

        public MenuTitle title;
        public Texture2D background;

        public MenuType actualType;

        int nbLevelButton;
        public LevelButton[] LButtons;

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
            reloadlevel,
            loose,
            win,
            setcontrole,
            defaultcommand
        }

        //CONSTRUCTOR
        public Menu(MenuType type, int nbButton, Texture2D background, int nbSwitchButton = 0, int nbControleButton = 0, int nbLevelButton = 0)
        {
            this.nbButton = nbButton;
            Buttons = new MenuButton[nbButton];

            this.actualType = type;

            this.cooldown = true;

            this.background = background;

            this.nbSwitchButton = nbSwitchButton;
            SButtons = new SwitchButton[nbSwitchButton];

            this.nbControleButton = nbControleButton;
            CButtons = new ControleButton[nbControleButton];

            this.nbLevelButton = nbLevelButton;
            LButtons = new LevelButton[nbLevelButton];
        }
        //METHODS
        public Menu ChangeMenu(MenuType type)
        {
            Menu actualMenu;
            actualMenu = this;

            int Xtitle = 300;
            int Ytitle = 50;

            int Xbutton = 400;
            int Xbutton0 = 100;
            int Xbutton1 = 700;
            int Ybutton0 = 350;
            int Ybutton1 = 450;
            int Ybutton2 = 550;
            int Ybutton3 = 650;

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
                        actualMenu = new Menu(type, 3, Ressource.BackgroundMenuMain);
                        actualMenu.title = new MenuTitle(new Vector2(Xtitle, Ytitle), 0);
                        actualMenu.Buttons[0] = new MenuButton(new Vector2(Xbutton, Ybutton0), "Jouer", MenuType.play);
                        actualMenu.Buttons[1] = new MenuButton(new Vector2(Xbutton, Ybutton1), "Options", MenuType.option);
                        actualMenu.Buttons[2] = new MenuButton(new Vector2(Xbutton, Ybutton2), "Quitter", MenuType.close);
                        break;
                    }
                case MenuType.play:
                    {
                        actualMenu = new Menu(type, 3, Ressource.BackgroundMenuMain);
                        actualMenu.title = new MenuTitle(new Vector2(Xtitle, Ytitle), 1);
                        actualMenu.Buttons[0] = new MenuButton(new Vector2(Xbutton, Ybutton0), "Aventure", MenuType.adventure);
                        actualMenu.Buttons[1] = new MenuButton(new Vector2(Xbutton, Ybutton1), "Jeu libre", MenuType.freeplay);
                        actualMenu.Buttons[2] = new MenuButton(new Vector2(Xbutton, Ybutton2), "Retour", MenuType.welcome);
                        break;
                    }
                case MenuType.option:
                    {
                        actualMenu = new Menu(type, 2, Ressource.BackgroundMenuMain, 2);
                        actualMenu.title = new MenuTitle(new Vector2(Xtitle, Ytitle), 2);
                        actualMenu.SButtons[0] = new SwitchButton(new Vector2(Xbutton, Ybutton0), "Musique", 0);
                        actualMenu.SButtons[1] = new SwitchButton(new Vector2(Xbutton, Ybutton1), "Bruitage", 1);
                        actualMenu.Buttons[1] = new MenuButton(new Vector2(Xbutton, Ybutton2), "Touches", MenuType.setcontrole);
                        actualMenu.Buttons[0] = new MenuButton(new Vector2(Xbutton, Ybutton3), "Retour", MenuType.welcome);
                        break;
                    }
                case MenuType.setcontrole:
                    {
                        actualMenu = new Menu(type, 2, Ressource.BackgroundMenuMain, 0, 4);
                        actualMenu.title = new MenuTitle(new Vector2(Xtitle, Ytitle), 2);
                        actualMenu.CButtons[0] = new ControleButton(new Vector2(Xbutton0, Ybutton0), "Droite", Ressource.inGameAction.Right);
                        actualMenu.CButtons[1] = new ControleButton(new Vector2(Xbutton0, Ybutton1), "Gauche", Ressource.inGameAction.Left);
                        actualMenu.CButtons[2] = new ControleButton(new Vector2(Xbutton1, Ybutton0), "Saut", Ressource.inGameAction.Jump);
                        actualMenu.CButtons[3] = new ControleButton(new Vector2(Xbutton1, Ybutton1), "Pause", Ressource.inGameAction.Pause);
                        actualMenu.Buttons[1] = new MenuButton(new Vector2(Xbutton, Ybutton2), "Par defaut", MenuType.defaultcommand);
                        actualMenu.Buttons[0] = new MenuButton(new Vector2(Xbutton, Ybutton3), "Retour", MenuType.option);
                        break;
                    }
                case MenuType.pause:
                    {
                        Game1.inGame = true;
                        actualMenu = new Menu(type, 3, Ressource.BackgroundMenuPause);
                        actualMenu.title = new MenuTitle(new Vector2(Xtitle, Ytitle), 3);
                        actualMenu.Buttons[0] = new MenuButton(new Vector2(Xbutton, Ybutton0), "Reprendre", MenuType.unpause);
                        actualMenu.Buttons[1] = new MenuButton(new Vector2(Xbutton, Ybutton1), "Recommencer", MenuType.reloadlevel);
                        actualMenu.Buttons[2] = new MenuButton(new Vector2(Xbutton, Ybutton2), "Acceuil", MenuType.welcome);
                        break;
                    }
                case MenuType.freeplay:
                    {
                        actualMenu = new Menu(MenuType.freeplay, 1, Ressource.BackgroundMenuMain,0,0,1);
                        actualMenu.title = new MenuTitle(new Vector2(Xtitle, Ytitle), 2);
                        actualMenu.Buttons[0] = new MenuButton(new Vector2(Xbutton, Ybutton1), "Retour", MenuType.play);
                        actualMenu.LButtons[0] = new LevelButton(new Vector2(Xbutton, Ybutton0), 1);
                        break;
                    }
                case MenuType.adventure:
                    {
                        Game1.inGame = true;
                        Game1.Level = new Level(1);
                        //Précharge la pause
                        actualMenu = new Menu(MenuType.pause, 3, Ressource.BackgroundMenuPause);
                        actualMenu.title = new MenuTitle(new Vector2(Xtitle, Ytitle), 3);
                        actualMenu.Buttons[0] = new MenuButton(new Vector2(Xbutton, Ybutton0), "Reprendre", MenuType.unpause);
                        actualMenu.Buttons[1] = new MenuButton(new Vector2(Xbutton, Ybutton1), "Recommencer", MenuType.reloadlevel);
                        actualMenu.Buttons[2] = new MenuButton(new Vector2(Xbutton, Ybutton2), "Acceuil", MenuType.welcome);
                        break;
                    }
                case MenuType.unpause:
                    {
                        Game1.inGame = true;
                        //Précharge la pause
                        actualMenu = new Menu(MenuType.pause, 3, Ressource.BackgroundMenuPause);
                        actualMenu.title = new MenuTitle(new Vector2(Xtitle, Ytitle), 3);
                        actualMenu.Buttons[0] = new MenuButton(new Vector2(Xbutton, Ybutton0), "Reprendre", MenuType.unpause);
                        actualMenu.Buttons[1] = new MenuButton(new Vector2(Xbutton, Ybutton1), "Recommencer", MenuType.reloadlevel);
                        actualMenu.Buttons[2] = new MenuButton(new Vector2(Xbutton, Ybutton2), "Acceuil", MenuType.welcome);
                        break;
                    }
                case MenuType.reloadlevel:
                    {
                        Game1.inGame = true;

                        Game1.Level = new Level(Game1.Level.lvl);


                        //Précharge la pause
                        actualMenu = new Menu(MenuType.pause, 3, Ressource.BackgroundMenuPause);
                        actualMenu.title = new MenuTitle(new Vector2(Xtitle, Ytitle), 3);
                        actualMenu.Buttons[0] = new MenuButton(new Vector2(Xbutton, Ybutton0), "Reprendre", MenuType.unpause);
                        actualMenu.Buttons[1] = new MenuButton(new Vector2(Xbutton, Ybutton1), "Recommencer", MenuType.reloadlevel);
                        actualMenu.Buttons[2] = new MenuButton(new Vector2(Xbutton, Ybutton2), "Acceuil", MenuType.welcome);
                        break;
                    }
                case MenuType.loose:
                    {
                        actualMenu = new Menu(MenuType.pause, 2, Ressource.BackgroundMenuPause);
                        actualMenu.title = new MenuTitle(new Vector2(Xtitle, Ytitle), 3);
                        actualMenu.Buttons[0] = new MenuButton(new Vector2(Xbutton, Ybutton1), "Recommencer", MenuType.reloadlevel);
                        actualMenu.Buttons[1] = new MenuButton(new Vector2(Xbutton, Ybutton2), "Acceuil", MenuType.welcome);
                        break;
                    }
                case MenuType.win:
                    {
                        actualMenu = new Menu(MenuType.pause, 2, Ressource.BackgroundMenuPause);
                        actualMenu.title = new MenuTitle(new Vector2(Xtitle, Ytitle), 3);
                        actualMenu.Buttons[0] = new MenuButton(new Vector2(Xbutton, Ybutton1), "Recommencer", MenuType.reloadlevel);
                        actualMenu.Buttons[1] = new MenuButton(new Vector2(Xbutton, Ybutton2), "Acceuil", MenuType.welcome);
                        break;
                    }
                case MenuType.defaultcommand:
                    {

                        Ressource.Key[Ressource.inGameAction.Left] = Keys.Left;
                        Ressource.Key[Ressource.inGameAction.Right] = Keys.Right;
                        Ressource.Key[Ressource.inGameAction.Jump] = Keys.Space;
                        Ressource.Key[Ressource.inGameAction.Pause] = Keys.Escape;

                        actualMenu = new Menu(type, 2, Ressource.BackgroundMenuMain, 0, 4);
                        actualMenu.title = new MenuTitle(new Vector2(Xtitle, Ytitle), 2);
                        actualMenu.CButtons[0] = new ControleButton(new Vector2(Xbutton0, Ybutton0), "Droite", Ressource.inGameAction.Right);
                        actualMenu.CButtons[1] = new ControleButton(new Vector2(Xbutton0, Ybutton1), "Gauche", Ressource.inGameAction.Left);
                        actualMenu.CButtons[2] = new ControleButton(new Vector2(Xbutton1, Ybutton0), "Saut", Ressource.inGameAction.Jump);
                        actualMenu.CButtons[3] = new ControleButton(new Vector2(Xbutton1, Ybutton1), "Pause", Ressource.inGameAction.Pause);
                        actualMenu.Buttons[1] = new MenuButton(new Vector2(Xbutton, Ybutton2), "Par defaut", MenuType.defaultcommand);
                        actualMenu.Buttons[0] = new MenuButton(new Vector2(Xbutton, Ybutton3), "Retour", MenuType.option);
                        break;
                    }
                default:
                    {
                        actualMenu = new Menu(type, 0, Ressource.BackgroundMenuMain);
                        actualMenu.title = new MenuTitle(new Vector2(Xtitle, Ytitle), 0);
                        break;
                    }
            }
            return actualMenu;
        }


        //UPDATE & DRAW
        public void Draw(SpriteBatch spriteBatch, MouseState mouse)
        {
            if (this.actualType == MenuType.pause)
            {
                //A REVOIR
                Game1.Level.Draw(spriteBatch);
            }
            spriteBatch.Draw(this.background, new Rectangle(0, 0, 1900, 1200), Color.White);

            Color color;

            foreach (MenuButton b in Buttons)
            {
                if (mouse.X >= b.pos.X
                    & mouse.X <= b.pos.X + b.SpriteWidth
                    & mouse.Y >= b.pos.Y
                    & mouse.Y <= b.pos.Y + b.SpriteHeight
                    & b.nextMenu != MenuType.none)
                {
                    color = Color.LightGray;
                }
                else
                {
                    color = Color.White;
                }
                b.Draw(spriteBatch, color);
            }

            foreach (SwitchButton b in SButtons)
            {
                if (mouse.X >= b.pos.X
                    & mouse.X <= b.pos.X + b.SpriteWidth
                    & mouse.Y >= b.pos.Y
                    & mouse.Y <= b.pos.Y + b.SpriteHeight)
                {
                    color = Color.LightGray;
                }
                else
                {
                    color = Color.White;
                }
                b.Draw(spriteBatch, color);
            }

            foreach (LevelButton b in LButtons)
            {
                if (mouse.X >= b.pos.X
                    & mouse.X <= b.pos.X + b.SpriteWidth
                    & mouse.Y >= b.pos.Y
                    & mouse.Y <= b.pos.Y + b.SpriteHeight)
                {
                    color = Color.LightGray;
                }
                else
                {
                    color = Color.White;
                }
                b.Draw(spriteBatch, color);
            }

            foreach (ControleButton b in CButtons)
            {
                Boolean anotherChanging = false;
                foreach (ControleButton b2 in CButtons)
                {
                    if (b2.isChanging && b2 != b)
                    {
                        anotherChanging = true;
                    }
                }

                if (mouse.X >= b.pos.X
                    && mouse.X <= b.pos.X + b.SpriteWidth
                    && mouse.Y >= b.pos.Y
                    && mouse.Y <= b.pos.Y + b.SpriteHeight
                    && !anotherChanging)
                {
                    color = Color.LightGray;
                }
                else
                {
                    color = Color.White;
                }
                b.Draw(spriteBatch, color);
            }

            title.Draw(spriteBatch);
        }

        public void Update(MouseState mouse, KeyboardState keyboard, ref Menu menu)
        {

            //Musique
            if (Ressource.parameter[0] && MediaPlayer.State != MediaState.Playing)
            {
                MediaPlayer.Play(Ressource.song);
                MediaPlayer.Volume = 0.1f;
            }

            else if (Ressource.parameter[0] == false)
            {
                MediaPlayer.Stop();
            }




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

            foreach (LevelButton b in LButtons)
            {
                if (mouse.LeftButton == ButtonState.Pressed
                    & mouse.X >= b.pos.X
                    & mouse.X <= b.pos.X + b.SpriteWidth
                    & mouse.Y >= b.pos.Y
                    & mouse.Y <= b.pos.Y + b.SpriteHeight
                    & cooldown)
                {
                    b.Update();
                    menu = menu.ChangeMenu(Menu.MenuType.pause);
                    menu.cooldown = false;
                    return;
                }
            }

            foreach (ControleButton b in CButtons)
            {
                bool oneIsChanging = false;
                foreach (ControleButton b2 in CButtons)
                {
                    if (b2.isChanging && b2 != b)
                    {
                        oneIsChanging = true;
                    }
                }
                if (!oneIsChanging)
                {
                    b.Update(mouse, ref menu);
                }

            }

        }

    }

    public class MenuTitle
    {
        //FIELDS
        Vector2 pos;
        Rectangle hitbox;

        int SpriteHeight;
        int SpriteWidth;
        int FrameLine;


        //CONSTRUCTOR
        public MenuTitle(Vector2 pos, int FrameLine)
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
            spriteBatch.Draw(Ressource.Title, this.hitbox, new Rectangle(0, this.FrameLine * this.SpriteHeight, this.SpriteWidth, this.SpriteHeight),
                Color.White);
        }

    }

    public class MenuButton : Button
    {
        //FIELDS
        public Menu.MenuType nextMenu;


        //CONSTRUCTOR
        public MenuButton(Vector2 pos, string text, Menu.MenuType nextMenu)
            : base(pos, text)
        {
            this.nextMenu = nextMenu;
        }

        //METHODS

        //UPDATE & DRAW
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Draw(Ressource.Button, this.hitbox, new Rectangle(0, 0, this.SpriteWidth, this.SpriteHeight), color);
            spriteBatch.DrawString(Ressource.MenuPolice, Text, new Vector2(pos.X + 95, pos.Y), Color.White);
        }

    }

    public class Button
    {
        //FIELDS
        public Vector2 pos;
        protected Rectangle hitbox;

        public int SpriteHeight;
        public int SpriteWidth;
        protected string Text;

        //CONSTRUCTOR
        public Button(Vector2 pos, string text)
        {
            this.pos = pos;
            this.Text = text;
            SpriteHeight = 75;
            SpriteWidth = 500;
            this.hitbox = new Rectangle((int)pos.X, (int)pos.Y, this.SpriteWidth, this.SpriteHeight);
        }
    }

    public class SwitchButton : Button
    {
        //FIELDS
        int nbParameter;

        //CONSTRUCTOR
        public SwitchButton(Vector2 pos, string text, int nbParameter)
            : base(pos, text)
        {
            this.Text = text;
            this.nbParameter = nbParameter;
        }

        //METHODS

        //UPDATE & DRAW
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Draw(Ressource.Button, this.hitbox, new Rectangle(0, 0, this.SpriteWidth, this.SpriteHeight), color);
            spriteBatch.DrawString(Ressource.MenuPolice, Text, new Vector2(pos.X + 95, pos.Y), Color.White);
            if (Ressource.parameter[nbParameter])
            {
                spriteBatch.DrawString(Ressource.MenuPolice, "ON", new Vector2(pos.X + 380, pos.Y), Color.LimeGreen);
            }
            else
            {
                spriteBatch.DrawString(Ressource.MenuPolice, "OFF", new Vector2(pos.X + 380, pos.Y), Color.Red);
            }
        }

        public void Update()
        {
            Ressource.parameter[this.nbParameter] = !Ressource.parameter[this.nbParameter];
        }
    }

    public class ControleButton : Button
    {
        //FIELDS
        Ressource.inGameAction action;
        string ActualKey;
        public bool isChanging;

        //CONSTRUCTOR
        public ControleButton(Vector2 pos, string text, Ressource.inGameAction action)
            : base(pos, text)
        {
            this.action = action;
            Keys k = Ressource.Key[action];

            if (((int)k >= 65 && (int)k <= 90))
            {
                ActualKey = "" + (char)k;
            }
            else if (k == Keys.Space)
            {
                ActualKey = "Spa.";
            }

            else if (k == Keys.Escape)
            {
                ActualKey = "Esc.";
            }

            else if ((int)k >= 48 && (int)k <= 57)
            {
                ActualKey = "" + (char)k;
            }

            else if (k == Keys.Left)
            {
                ActualKey = "<-";
            }

            else if (k == Keys.Right)
            {
                ActualKey = "->";
            }

            else if (k == Keys.Up)
            {
                ActualKey = "Up";
            }

            else if (k == Keys.Down)
            {
                ActualKey = "Down";
            }


            isChanging = false;
            Text = text;
        }

        //UPDATE & DRAW
        public void Update(MouseState mouse, ref Menu menu)
        {
            if (mouse.LeftButton == ButtonState.Pressed
                & mouse.X >= pos.X
                & mouse.X <= pos.X + SpriteWidth
                & mouse.Y >= pos.Y
                & mouse.Y <= pos.Y + SpriteHeight
                && menu.cooldown)
            {
                isChanging = !isChanging;
                menu.cooldown = false;
            }
            if (isChanging)
            {
                foreach (Keys k in (Keys[])Enum.GetValues(typeof(Keys)))
                {
                    if (Keyboard.GetState().IsKeyDown(k)
                        && (!(Ressource.Key.ContainsValue(k)) || Ressource.Key[action] == k))
                    {
                        if (((int)k >= 65 && (int)k <= 90))
                        {
                            Ressource.Key[action] = k;
                            ActualKey = "" + (char)k;
                            isChanging = false;
                            return;
                        }
                        else if (k == Keys.Space)
                        {
                            Ressource.Key[action] = k;
                            ActualKey = "Spa.";
                            isChanging = false;
                            return;
                        }

                        else if (k == Keys.Escape)
                        {
                            Ressource.Key[action] = k;
                            ActualKey = "Esc.";
                            isChanging = false;
                            return;
                        }

                        else if ((int)k >= (int)Keys.NumPad0 && (int)k <= (int)Keys.NumPad9)
                        {
                            Ressource.Key[action] = k;
                            ActualKey = "" + (char)((int)k - (int)Keys.NumPad0 + 48);
                            isChanging = false;
                            return;
                        }

                        else if (k == Keys.Left)
                        {
                            Ressource.Key[action] = k;
                            ActualKey = "<-";
                            isChanging = false;
                            return;
                        }

                        else if (k == Keys.Right)
                        {
                            Ressource.Key[action] = k;
                            ActualKey = "->";
                            isChanging = false;
                            return;
                        }

                        else if (k == Keys.Up)
                        {
                            Ressource.Key[action] = k;
                            ActualKey = "Up";
                            isChanging = false;
                            return;
                        }

                        else if (k == Keys.Down)
                        {
                            Ressource.Key[action] = k;
                            ActualKey = "Down";
                            isChanging = false;
                            return;
                        }

                    }
                }

            }
        }


        public void Draw(SpriteBatch spriteBatch, Color color)
        {

            spriteBatch.Draw(Ressource.Button, this.hitbox, new Rectangle(0, 0, this.SpriteWidth, this.SpriteHeight), color);
            spriteBatch.DrawString(Ressource.MenuPolice, Text, new Vector2(pos.X + 95, pos.Y), Color.White);

            if (!isChanging)
            {
                spriteBatch.DrawString(Ressource.MenuPolice, ActualKey, new Vector2(pos.X + 350, pos.Y), Color.Yellow);
            }
            else
            {
                spriteBatch.DrawString(Ressource.MenuPolice, "???", new Vector2(pos.X + 350, pos.Y), Color.Yellow);
            }
        }



    }

    public class LevelButton : Button
    { 
        //FIELDS
        int lvl;

        //CONSTRUCTOR
        public LevelButton(Vector2 pos, int lvl) :
            base(pos, "Level " + lvl)
        {
            this.lvl = lvl;
        }

        //UPDATE & DRAW
        public void Update()
        {
            Game1.Level = new Level(lvl);        
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Draw(Ressource.Button, this.hitbox, new Rectangle(0, 0, this.SpriteWidth, this.SpriteHeight), color);
            spriteBatch.DrawString(Ressource.MenuPolice, Text, new Vector2(pos.X + 95, pos.Y), Color.White);
        }

    }
}