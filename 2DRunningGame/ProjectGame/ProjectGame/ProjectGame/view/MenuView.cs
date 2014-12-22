using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ProjectGame.controller;

namespace ProjectGame.view
{
    class MenuView
    {
        private Texture2D m_MenuTexture, m_buttonTexture, m_backToMenuTextue, m_OpitionsTexture, m_PauseTexture, m_HowToPlayTexture, m_PausedTexture, m_QuitTexture, m_ResumeTexture;
        private Microsoft.Xna.Framework.Content.ContentManager Content;
        private SpriteBatch m_spriteBatch;
        private GraphicsDevice m_graphics;
        private MenuControlls m_menuController;


        /// <summary>
        /// Construct (load menus images.)
        /// </summary>
        /// <param name="GraphicsDevice"></param>
        /// <param name="Content"></param>
        /// <param name="m_spriteBatch"></param>
        public MenuView(Microsoft.Xna.Framework.Graphics.GraphicsDevice GraphicsDevice, Microsoft.Xna.Framework.Content.ContentManager Content, SpriteBatch m_spriteBatch)
        {

            this.m_graphics = GraphicsDevice;
            this.Content = Content;
            this.m_spriteBatch = m_spriteBatch;

            m_MenuTexture = Content.Load<Texture2D>("MenuBackgroundTransp");
            m_buttonTexture = Content.Load<Texture2D>("Play2");
            m_backToMenuTextue = Content.Load<Texture2D>("menu2");
            m_OpitionsTexture = Content.Load<Texture2D>("Options2");
            m_PauseTexture = Content.Load<Texture2D>("Pause");
            m_HowToPlayTexture = Content.Load<Texture2D>("help");
            m_PausedTexture = Content.Load<Texture2D>("PausedBackground");
            m_QuitTexture = Content.Load<Texture2D>("ex");
            m_ResumeTexture = Content.Load<Texture2D>("ResumeButton");

            m_menuController = new MenuControlls(GraphicsDevice);

        }


        /// <summary>
        /// draw menu background image.
        /// </summary>
        public void DrawMenu()
        {
            Rectangle menuRectangel = new Rectangle(0, 0, m_graphics.Viewport.Width, m_graphics.Viewport.Height);

            m_spriteBatch.Begin();

            m_spriteBatch.Draw(m_MenuTexture, menuRectangel, Color.White);

            m_spriteBatch.End();

        }

        /// <summary>
        /// Draw pause background image.
        /// </summary>
        public void DrawPaused()
        {
            Rectangle pausedRectangel = new Rectangle(0, 0, m_graphics.Viewport.Width, m_graphics.Viewport.Height);

            m_spriteBatch.Begin();

            m_spriteBatch.Draw(m_PausedTexture, pausedRectangel, Color.White);

            m_spriteBatch.End();

        }


        /// <summary>
        /// Draw information background image.
        /// </summary>
        public void DrawOpstion()
        {
            Rectangle opstionRectangel = new Rectangle(0, m_graphics.Viewport.Height / 2, m_graphics.Viewport.Width, m_graphics.Viewport.Height / 2);

            m_spriteBatch.Begin();

            m_spriteBatch.Draw(m_OpitionsTexture, opstionRectangel, Color.White);

            m_spriteBatch.End();

        }


        /// <summary>
        /// Draw play, information and exit images.
        /// </summary>
        public void DrawButtons()
        {

            m_spriteBatch.Begin();
            m_spriteBatch.Draw(m_buttonTexture, m_menuController.PlayRectangel(), Color.White);
            m_spriteBatch.Draw(m_HowToPlayTexture, m_menuController.HowToPlayRectangel(), Color.White);
            m_spriteBatch.Draw(m_QuitTexture, m_menuController.quitRectangel(), Color.White);
            m_spriteBatch.End();

        }

        /// <summary>
        /// Draw image for menu.
        /// </summary>
        public void DrawReturnButton()
        {
            m_spriteBatch.Begin();
            m_spriteBatch.Draw(m_backToMenuTextue, m_menuController.BackButtonRectangel(), Color.White);
            m_spriteBatch.End();
        }


        /// <summary>
        /// Draw image for resume button
        /// </summary>
        public void DrawResumeButton()
        {
            m_spriteBatch.Begin();
            m_spriteBatch.Draw(m_ResumeTexture, m_menuController.resumeRectangel(), Color.White);
            m_spriteBatch.End();
        }

        /// <summary>
        /// Draw pause button image
        /// </summary>
        public void DrawPauseTexture()
        {
            m_spriteBatch.Begin();
            m_spriteBatch.Draw(m_PauseTexture, m_menuController.pauseBtnRectangel(), Color.White);
            m_spriteBatch.End();
        }

    }
}
