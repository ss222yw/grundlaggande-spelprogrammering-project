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
        private Texture2D m_MenuTexture, m_buttonTexture, m_backToMenuTextue, m_OpitionsTexture, m_PauseTexture, m_HowToPlayTexture, m_PausedTexture, m_QuitTexture, m_ResumeTexture, m_RePlayTexture, m_GameOverTexture, m_completedTexture, m_PlayAginTexture, m_continueTexture, m_theEndTexture;
        private Microsoft.Xna.Framework.Content.ContentManager Content;
        private SpriteBatch m_spriteBatch;
        private GraphicsDevice m_graphics;
        private MenuControlls m_menuController;
        private float m_Transparent = 0.8f;


        /// <summary>
        /// Construct (load menus images.)
        /// </summary>
        /// <param name="GraphicsDevice"></param>
        /// <param name="Content"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="m_MenuController"></param>
        public MenuView(GraphicsDevice GraphicsDevice, Microsoft.Xna.Framework.Content.ContentManager Content, SpriteBatch spriteBatch, MenuControlls MenuController)
        {
            // TODO: Complete member initialization
            this.m_graphics = GraphicsDevice;
            this.Content = Content;
            this.m_spriteBatch = spriteBatch;
            this.m_menuController = MenuController;


            m_MenuTexture = Content.Load<Texture2D>("MenuBackgroundTransp");
            m_buttonTexture = Content.Load<Texture2D>("Play2");
            m_backToMenuTextue = Content.Load<Texture2D>("menu2");
            m_OpitionsTexture = Content.Load<Texture2D>("Options2");
            m_PauseTexture = Content.Load<Texture2D>("Pause");
            m_HowToPlayTexture = Content.Load<Texture2D>("help");
            m_PausedTexture = Content.Load<Texture2D>("PausedBackground");
            m_QuitTexture = Content.Load<Texture2D>("ex");
            m_ResumeTexture = Content.Load<Texture2D>("ResumeButton");
            m_RePlayTexture = Content.Load<Texture2D>("replay3");
            m_GameOverTexture = Content.Load<Texture2D>("GameOver");
            m_completedTexture = Content.Load<Texture2D>("completed");
            m_PlayAginTexture = Content.Load<Texture2D>("PlayAgain");
            m_continueTexture = Content.Load<Texture2D>("continueButton");
            m_theEndTexture = Content.Load<Texture2D>("theEnd");



        }


        /// <summary>
        /// draw menu background image.
        /// </summary>
        public void DrawMenu()
        {
            Rectangle menuRectangel = new Rectangle(0, 0, m_graphics.Viewport.Width, m_graphics.Viewport.Height);
            m_spriteBatch.Draw(m_MenuTexture, menuRectangel, Color.White * m_Transparent);
        }

        /// <summary>
        /// Draw pause background image.
        /// </summary>
        public void DrawPaused()
        {
            Rectangle pausedRectangel = new Rectangle(0, 0, m_graphics.Viewport.Width, m_graphics.Viewport.Height);
            m_spriteBatch.Draw(m_PausedTexture, pausedRectangel, Color.White * m_Transparent);
        }

        /// <summary>
        /// Draw gameover background image
        /// </summary>
        public void DrawGameOver()
        {
            Rectangle gameoverRectangel = new Rectangle(0, 0, m_graphics.Viewport.Width, m_graphics.Viewport.Height);
            m_spriteBatch.Draw(m_GameOverTexture, gameoverRectangel, Color.White * m_Transparent);
        }

        /// <summary>
        /// Draw completed levels image
        /// </summary>
        public void DrawCompletedLevel()
        {
            Rectangle completedRectangel = new Rectangle(0, 0, m_graphics.Viewport.Width, m_graphics.Viewport.Height);
            m_spriteBatch.Draw(m_completedTexture, completedRectangel, Color.White * m_Transparent);
        }

        public void DrawTheEnd()
        {
            Rectangle endOfTheGameRectangel = new Rectangle(0, 0, m_graphics.Viewport.Width, m_graphics.Viewport.Height);
            m_spriteBatch.Draw(m_theEndTexture, endOfTheGameRectangel, Color.White);
        }

        /// <summary>
        /// Draw information background image.
        /// </summary>
        public void DrawOpstion()
        {
            Rectangle opstionRectangel = new Rectangle(0, m_graphics.Viewport.Height / 2, m_graphics.Viewport.Width, m_graphics.Viewport.Height / 2);
            m_spriteBatch.Draw(m_OpitionsTexture, opstionRectangel, Color.White * m_Transparent);
        }


        /// <summary>
        /// Draw play, information and exit images.
        /// </summary>
        public void DrawButtons()
        {
            m_spriteBatch.Draw(m_buttonTexture, m_menuController.PlayRectangel(), Color.White * m_Transparent);
            m_spriteBatch.Draw(m_HowToPlayTexture, m_menuController.HowToPlayRectangel(), Color.White * m_Transparent);
            m_spriteBatch.Draw(m_QuitTexture, m_menuController.quitRectangel(), Color.White * m_Transparent);
        }

        /// <summary>
        /// Draw image for menu.
        /// </summary>
        public void DrawReturnButton()
        {
            m_spriteBatch.Draw(m_backToMenuTextue, m_menuController.BackButtonRectangel(), Color.White * m_Transparent);
        }


        /// <summary>
        /// Draw image for resume button
        /// </summary>
        public void DrawResumeButton()
        {
            m_spriteBatch.Draw(m_ResumeTexture, m_menuController.resumeRectangel(), Color.White * m_Transparent);
        }

        /// <summary>
        /// Draw pause button image
        /// </summary>
        public void DrawPauseTexture()
        {
            m_spriteBatch.Draw(m_PauseTexture, m_menuController.pauseBtnRectangel(), Color.White * m_Transparent);
        }




        /// <summary>
        /// draw replay button.
        /// </summary>
        public void DrawRePlayTexture()
        {
            m_spriteBatch.Draw(m_RePlayTexture, m_menuController.rePlayBtnRectangle(), Color.White * m_Transparent);
        }

        /// <summary>
        /// draw playAgain button.
        /// </summary>
        public void DrawPlayAgainBtn()
        {
            m_spriteBatch.Draw(m_PlayAginTexture, m_menuController.playAgainRectangle(), Color.White * m_Transparent);
        }


        /// <summary>
        /// draw continue button.
        /// </summary>
        public void DrawContinueBtn()
        {
            m_spriteBatch.Draw(m_continueTexture, m_menuController.continueRectangle(), Color.White * m_Transparent);
        }

        /// <summary>
        /// Draw Exit button.
        /// </summary>
        public void drawExit()
        {
            m_spriteBatch.Draw(m_QuitTexture, m_menuController.quitRectangel(), Color.White * m_Transparent);
        }


    }
}
