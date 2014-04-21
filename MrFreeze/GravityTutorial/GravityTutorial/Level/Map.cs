﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GravityTutorial
{
    public class Map
    {
        

        public List<CollisionTiles> CollisionTiles = new List<CollisionTiles>();
        /*public List<CollisionTiles> CollisionTiles
        {
            get { return collisionTiles; }
        }*/

        private int width, height;
        public int Width
        {
            get { return width; }
        }
        public int Height
        {
            get { return height; }
        }

        public Map() 
        {
        
        }


        public void Generate(int[,] map, int size, Level Level)
        {
            
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];


                    if (number > 0 && number < 4)
                    {
                        CollisionTiles.Add(new CollisionTiles(number, new Rectangle(x * size, y * size, size, size)));
                    }
                    if (number == 4)
                    {
                        Level.Items.Add(new gold(new Vector2(x * size, y * size)));
                    }
                    width = (x + 1) * size;
                    height = (y + 1) * size;
                }
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            
            foreach (CollisionTiles tile in CollisionTiles)     
            {
                tile.Draw(spriteBatch);
            }
        }
    }
}