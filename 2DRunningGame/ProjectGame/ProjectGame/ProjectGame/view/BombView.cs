using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ProjectGame.model;

namespace ProjectGame.view
{
    class BombView
    {
        public Texture2D bombTexture;
        private Microsoft.Xna.Framework.Content.ContentManager Content;
        private BombModel m_BombModel;

        public BombView(Microsoft.Xna.Framework.Content.ContentManager Content, BombModel BombModel)
        {
            // TODO: Complete member initialization
            this.m_BombModel = BombModel;
            this.Content = Content;
            bombTexture = Content.Load<Texture2D>("bomb");
        }

        /// <summary>
        /// Draw the bomb.
        /// </summary>
        /// <param name="sprite"></param>
        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(bombTexture, m_BombModel.bombRectangle(), Color.White);
        }

    }
}
