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
        private GraphicsDevice m_graphics;
        private Texture2D m_Texture, m_tileTexture, m_emptyTexture, m_blockTexture, m_backgroundTexture, m_WaterTexture, m_ghostTexture;
        private Rectangle destrect;
        private Rectangle destRectGhost;
        private Vector2 ghostViewPos;
        private Vector2 viewportSize;
        private float scale;
        private Camera m_camera;
        private gameModel m_model;
        private Texture2D m_Level1Background, m_Level2Background, m_Level3Background;

        /// <summary>
        /// Constructor (loading all images).
        /// </summary>
        /// <param name="GraphicsDevice"></param>
        /// <param name="Content"></param>
        public View(GraphicsDevice GraphicsDevice, Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            m_spriteBatch = new SpriteBatch(GraphicsDevice);
            m_Texture = Content.Load<Texture2D>("run3");
            m_blockTexture = Content.Load<Texture2D>("g1");
            m_backgroundTexture = Content.Load<Texture2D>("glass");
            m_WaterTexture = Content.Load<Texture2D>("waterTile");
            m_ghostTexture = Content.Load<Texture2D>("ghost");
            m_Level1Background = Content.Load<Texture2D>("texture1");
            m_Level2Background = Content.Load<Texture2D>("texture2");
            m_Level3Background = Content.Load<Texture2D>("texture3");
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
        public void DrawLevel(Level a_level, Camera a_camera, gameModel model)
        {

            viewportSize = new Vector2(m_graphics.Viewport.Width, m_graphics.Viewport.Height);
            scale = a_camera.GetScale();

            m_camera = a_camera;
            m_model = model;

            m_spriteBatch.Begin();

            if (Level.CurrentLevel == 1)
            {
                m_spriteBatch.Draw(m_Level1Background, new Rectangle(0, 0, (int)viewportSize.X, (int)viewportSize.Y), Color.White);
            }

            else if (Level.CurrentLevel == 2)
            {
                m_spriteBatch.Draw(m_Level2Background, new Rectangle(0, 0, (int)viewportSize.X, (int)viewportSize.Y), Color.White);
            }

            else if (Level.CurrentLevel == 3)
            {
                m_spriteBatch.Draw(m_Level3Background, new Rectangle(0, 0, (int)viewportSize.X, (int)viewportSize.Y), Color.DarkRed);
            }

            for (int x = 0; x < Level.g_levelWidth; x++)
            {
                for (int y = 0; y < Level.g_levelHeight; y++)
                {
                    Vector2 viewPos = a_camera.GetViewPosition(x, y, viewportSize);
                    //Destination rectangle in windows coordinates only scaling
                    Rectangle destRect = new Rectangle((int)viewPos.X, (int)viewPos.Y, (int)scale, (int)scale);

                    if (a_level.m_tiles[x, y] == TileType.BLOCKED)
                    {
                        m_spriteBatch.Draw(m_blockTexture, destRect, Color.White);
                    }
                    else if (a_level.m_tiles[x, y] == TileType.Background)
                    {
                        m_spriteBatch.Draw(m_backgroundTexture, destRect, Color.White);
                    }

                    else if (a_level.m_tiles[x, y] == TileType.Water)
                    {
                        m_spriteBatch.Draw(m_WaterTexture, destRect, Color.White);
                    }

                }
            }

            Color color;
            if (model.hasCollidedWidthTheLeft())
            {
                color = Color.Red;
            }
            else
            {
                color = Color.White;

            }


            Vector2 viewpos = a_camera.GetViewPosition(model.GetPlayerPosition().X, model.GetPlayerPosition().Y, viewportSize);
            destrect = new Rectangle((int)(viewpos.X - scale / 2), (int)(viewpos.Y - scale), (int)scale, (int)scale);
            Rectangle animationRect = new Rectangle(m_Texture.Width / 8 * (int)model.getFrame(), 0, m_Texture.Width / 8, m_Texture.Height / 2);

            m_spriteBatch.Draw(m_Texture, destrect, animationRect, color);

            m_spriteBatch.End();
        }


        /// <summary>
        /// Draw ghost texture.
        /// </summary>
        public void drawGhost()
        {
            ghostViewPos = m_camera.GetViewPosition(m_model.getGhostPosition().X, m_model.GetPlayerPosition().Y, viewportSize);
            destRectGhost = new Rectangle((int)(ghostViewPos.X - scale / 2), (int)(ghostViewPos.Y - scale), (int)scale, (int)scale);

            m_spriteBatch.Begin();
            m_spriteBatch.Draw(m_ghostTexture, destRectGhost, Color.White);
            m_spriteBatch.End();
        }

        /// <summary>
        /// return
        /// </summary>
        /// <returns>ghost rectangle</returns>
        public Rectangle ghostRectangle()
        {
            return destRectGhost;
        }

        /// <summary>
        /// return
        /// </summary>
        /// <returns>player rectangle</returns>
        public Rectangle playerRectangle()
        {
            return destrect;
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

        /// <summary>
        /// return bool if the user is pressed the enter button on keyboard or not.
        /// </summary>
        /// <returns>enter/returns>
        public bool IsClickedToPlayAgain()
        {
            return Keyboard.GetState().IsKeyDown(Keys.Enter);
        }
    }
}
