using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ProjectGame.model;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using ProjectGame.controller;

namespace ProjectGame.view
{
    class View
    {
        // Some of code took from (https://code.google.com/p/1dv437arkanoid/source/browse/trunk/Collisions/Collisions2/View/View.cs).

        private SpriteBatch m_spriteBatch;
        private Texture2D m_Texture;
        private Texture2D m_TextureBackground;
        private GraphicsDevice m_graphics;


        /// <summary>
        /// Constructor (loading all images).
        /// </summary>
        /// <param name="GraphicsDevice"></param>
        /// <param name="Content"></param>
        public View(GraphicsDevice GraphicsDevice, Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            m_spriteBatch = new SpriteBatch(GraphicsDevice);

            m_Texture = Content.Load<Texture2D>("run3");
            m_TextureBackground = Content.Load<Texture2D>("Tiles3");

            this.m_graphics = GraphicsDevice;
        }


        /// <summary>
        /// draw player and level.
        /// </summary>
        /// <param name="a_graphicsDevice"></param>
        /// <param name="a_level"></param>
        /// <param name="a_camera"></param>
        /// <param name="postion"></param>
        /// <param name="model"></param>
        public void DrawLevel(Level a_level, Camera a_camera, Vector2 postion, gameModel model)
        {

            Vector2 viewportSize = new Vector2(m_graphics.Viewport.Width, m_graphics.Viewport.Height);
            float scale = a_camera.GetScale();

            m_spriteBatch.Begin();

            for (int x = 0; x < Level.g_levelWidth; x++)
            {
                for (int y = 0; y < Level.g_levelHeight; y++)
                {
                    Vector2 viewPos = a_camera.GetViewPosition(x, y, viewportSize);

                    //Destination rectangle in windows coordinates only scaling
                    Rectangle destRect = new Rectangle((int)viewPos.X, (int)viewPos.Y, (int)scale, (int)scale);
                    m_spriteBatch.Draw(m_TextureBackground, destRect, Color.White);
                }
            }

            Vector2 viewpos = a_camera.GetViewPosition(postion.X, postion.Y, viewportSize);

            Rectangle destrect = new Rectangle((int)(viewpos.X - scale / 2), (int)(viewpos.Y - scale), (int)scale, (int)scale);
            Rectangle animationRect = new Rectangle(m_Texture.Width / 8 * (int)model.getFrame(), 0, m_Texture.Width / 8, m_Texture.Height / 2);
            m_spriteBatch.Draw(m_Texture, destrect, animationRect, Color.White);
            m_spriteBatch.End();
        }


        /// <summary>
        /// return bool if user has press a keyboard right button or not.
        /// </summary>
        /// <returns></returns>
        public bool IsCharacterMovingToRight()
        {
            return Keyboard.GetState().IsKeyDown(Keys.Right);
        }


        /// <summary>
        /// return bool if user has press a keyboard left button or not.
        /// </summary>
        /// <returns></returns>
        public bool IsCharacterMovingToLeft()
        {
            return Keyboard.GetState().IsKeyDown(Keys.Left);
        }


        /// <summary>
        /// return bool if user has press a keyboard space button or not.
        /// </summary>
        /// <returns></returns>
        public bool IsCharacterJumping()
        {
            return Keyboard.GetState().IsKeyDown(Keys.Space);
        }


    }
}
