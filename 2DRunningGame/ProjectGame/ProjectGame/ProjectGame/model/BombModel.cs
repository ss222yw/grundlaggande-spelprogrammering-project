using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ProjectGame.model
{
    class BombModel
    {

        private Vector2 bombPosition;
        private Vector2 velocity;
        public bool isHidden = false;

        /// <summary>
        /// Counstruct
        /// </summary>
        /// <param name="bombOldPosition"></param>
        public BombModel(Vector2 bombOldPosition)
        {
            bombPosition = bombOldPosition;
            velocity = new Vector2(-1.4f, 2.4f);
        }

        /// <summary>
        /// set new position for bomb texture.
        /// </summary>
        public void Update()
        {
            bombPosition += velocity;

            if (bombPosition.Y > Level.g_levelHeight * 23)
            {
                velocity.Y = -2.4f;
            }

            if (bombPosition.Y - 0 < 40)
            {
                isHidden = true;
            }

        }


        /// <summary>
        /// Rectangle.
        /// </summary>
        /// <returns>bomb rectangle</returns>
        public Rectangle bombRectangle()
        {
            return new Rectangle((int)bombPosition.X, (int)bombPosition.Y, 40, 40);
        }


    }
}
