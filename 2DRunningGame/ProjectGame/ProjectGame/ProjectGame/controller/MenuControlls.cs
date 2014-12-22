﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ProjectGame.controller
{
    class MenuControlls
    {

        private Rectangle m_PlayRectangel, m_HowToPlayRectangel, m_mouseRectangel, m_BackButtonRectangel, m_quitRectangel, m_ResumeRectangel, m_PauseRectangelBtn;
        private Vector2 m_PlayPosition, m_HowToPlayPosition, m_MenuPosition, m_quitPosition, m_ResumePosition, m_pauseBtnPosition, m_ButtonsImgSize;
        public bool isCklickedToPlay, isCklickedToSeInfo, isCklickedToReturn, isClickedToQuit, isClickedToResume, isClickedToCMenu;
        private GraphicsDevice GraphicsDevice;


        /// <summary>
        /// Construct (Set Positions for rectangels)
        /// </summary>
        /// <param name="GraphicsDevice"></param>
        public MenuControlls(GraphicsDevice GraphicsDevice)
        {
            // TODO: Complete member initialization
            this.GraphicsDevice = GraphicsDevice;

            m_PlayPosition = new Vector2(GraphicsDevice.Viewport.Width / 3, GraphicsDevice.Viewport.Height / 4);
            m_HowToPlayPosition = new Vector2(GraphicsDevice.Viewport.Width / 3, GraphicsDevice.Viewport.Height / 2.5f);
            m_quitPosition = new Vector2(GraphicsDevice.Viewport.Width / 3, GraphicsDevice.Viewport.Height / 1.8f);
            m_ResumePosition = new Vector2(GraphicsDevice.Viewport.Width / 3, GraphicsDevice.Viewport.Height / 4);
            m_ButtonsImgSize = new Vector2(GraphicsDevice.Viewport.Width / 4, GraphicsDevice.Viewport.Height / 8);
            m_pauseBtnPosition = new Vector2(1, 1);
            m_MenuPosition = new Vector2(50, 2);
        }


        /// <summary>
        /// return rectangel for play button.
        /// </summary>
        /// <returns>m_PlayRectangel</returns>
        public Rectangle PlayRectangel()
        {
            return m_PlayRectangel = new Rectangle((int)m_PlayPosition.X, (int)m_PlayPosition.Y, (int)m_ButtonsImgSize.X, (int)m_ButtonsImgSize.Y);
        }

        /// <summary>
        /// return rectangel for inforamtion button.
        /// </summary>
        /// <returns>m_HowToPlayRectangel</returns>
        public Rectangle HowToPlayRectangel()
        {
            return m_HowToPlayRectangel = new Rectangle((int)m_HowToPlayPosition.X, (int)m_HowToPlayPosition.Y, (int)m_ButtonsImgSize.X / 2, (int)m_ButtonsImgSize.Y);
        }


        /// <summary>
        /// return rectangel for menu button.
        /// </summary>
        /// <returns>m_BackButtonRectangel</returns>
        public Rectangle BackButtonRectangel()
        {
            return m_BackButtonRectangel = new Rectangle((int)m_MenuPosition.X, (int)m_MenuPosition.Y, (int)m_ButtonsImgSize.X / 4, (int)m_ButtonsImgSize.Y / 2);
        }


        /// <summary>
        /// return rectangel for exit button.
        /// </summary>
        /// <returns>m_quitRectangel</returns>
        public Rectangle quitRectangel()
        {
            return m_quitRectangel = new Rectangle((int)m_quitPosition.X, (int)m_quitPosition.Y, (int)m_ButtonsImgSize.X / 2, (int)m_ButtonsImgSize.Y);
        }


        /// <summary>
        /// return rectangel for resume button.
        /// </summary>
        /// <returns>m_ResumeRectangel</returns>
        public Rectangle resumeRectangel()
        {
            return m_ResumeRectangel = new Rectangle((int)m_ResumePosition.X, (int)m_ResumePosition.Y, (int)m_ButtonsImgSize.X, (int)m_ButtonsImgSize.Y);
        }

        /// <summary>
        /// return rectangel for pause button.
        /// </summary>
        /// <returns>m_PauseRectangelBtn</returns>
        public Rectangle pauseBtnRectangel()
        {
            return m_PauseRectangelBtn = new Rectangle((int)m_pauseBtnPosition.X, (int)m_pauseBtnPosition.Y, (int)m_ButtonsImgSize.X / 4, (int)m_ButtonsImgSize.Y / 2);
        }

        /// <summary>
        /// Get mouse state position.
        /// </summary>
        /// <param name="mouse"></param>
        public void mousePosition(MouseState mouse)
        {

            m_mouseRectangel = new Rectangle(mouse.X, mouse.Y, 1, 1);

            // if the mouse is over the rectangel area ...
            if (m_mouseRectangel.Intersects(PlayRectangel()))
            {
                //...and mouse is clicked then play is true.
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    isCklickedToPlay = true;
                }

            }


            if (m_mouseRectangel.Intersects(HowToPlayRectangel()))
            {

                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    isCklickedToSeInfo = true;
                }
            }


            if (m_mouseRectangel.Intersects(BackButtonRectangel()))
            {

                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    isCklickedToReturn = true;

                }
            }


            if (m_mouseRectangel.Intersects(quitRectangel()))
            {

                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    isClickedToQuit = true;
                }
            }


            if (m_mouseRectangel.Intersects(resumeRectangel()))
            {

                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    isClickedToResume = true;
                }
            }

            if (m_mouseRectangel.Intersects(pauseBtnRectangel()))
            {
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    isClickedToCMenu = true;
                }
            }


        }

    }
}