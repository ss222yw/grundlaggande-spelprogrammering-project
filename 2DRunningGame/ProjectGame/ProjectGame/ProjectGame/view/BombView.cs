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
        private Rectangle bombRectangle;

        public BombView(Microsoft.Xna.Framework.Content.ContentManager Content, BombModel BombModel)
        {
            this.m_BombModel = BombModel;
            this.Content = Content;
            bombTexture = Content.Load<Texture2D>("bomb");
        }

        /// <summary>
        /// draw bombs
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="a_camera"></param>
        internal void Draw(SpriteBatch spriteBatch, Camera a_camera)
        {
            float scale = a_camera.GetScale();
            bombRectangle = new Rectangle((int)m_BombModel.BombPosition.X, (int)(m_BombModel.BombPosition.Y), (int)scale / 2, (int)scale / 2);
            spriteBatch.Draw(bombTexture, bombRectangle, Color.White);
        }


        /// <summary>
        /// return
        /// </summary>
        /// <returns>bomb rectangle</returns>
        public Rectangle BombRectangle()
        {
            return bombRectangle;
        }
    }
}
