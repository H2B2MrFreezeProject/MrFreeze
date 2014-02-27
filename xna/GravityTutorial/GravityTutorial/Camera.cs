using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GravityTutorial
{
    class Camera
    {
        private Matrix transform;
        public Matrix Transform
        {
            get { return transform; }
        }

        public Vector2 center;
        public Viewport viewport;
        public Camera(Viewport newviewport)
        {
            viewport = newviewport;
        }

        public void update(Vector2 position, int xoffset, int yoffset)
        {
            if (position.X < viewport.Width / 2)
            {
                center.X = viewport.Width / 2;
            }
            else if (position.X > xoffset - (viewport.Width / 2))
            {
                center.X = xoffset - (viewport.Width / 2);
            }
            else
            {
                center.X = position.X;
            }

            if (position.Y < viewport.Height / 2)
            {
                center.Y = viewport.Height / 2;
            }
            else if (position.Y > yoffset - (viewport.Height / 2))
            {
                center.Y = yoffset - (viewport.Height / 2);
            }
            else
            {
                center.Y = position.Y;
            }

                transform = Matrix.CreateTranslation(new Vector3(-center.X + (viewport.Width / 2),
                                                                 - center.Y + (viewport.Height / 2), 0));
        }
    }
}
