using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ProjectGame.model;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace ProjectGame.view
{
    class View
    {
        // Some of code took from (https://code.google.com/p/1dv437arkanoid/source/browse/trunk/Collisions/Collisions2/View/View.cs).
        private SpriteBatch m_spriteBatch;
        private Texture2D m_Texture;
        private Texture2D m_TextureBackground;
 
 

        public View(GraphicsDevice GraphicsDevice, Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            m_spriteBatch = new SpriteBatch(GraphicsDevice);
            m_Texture = Content.Load<Texture2D>("run3");
            m_TextureBackground = Content.Load<Texture2D>("Tiles3");
       
        }

        public void DrawLevel(GraphicsDevice a_graphicsDevice,Level a_level, Camera a_camera,Vector2 postion,gameModel model)
        {
            Vector2 viewportSize = new Vector2(a_graphicsDevice.Viewport.Width, a_graphicsDevice.Viewport.Height);
            float scale = a_camera.GetScale();

            //draw all images
            m_spriteBatch.Begin();

            //draw level
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

            //Draw player
            Rectangle destrect = new Rectangle((int)(viewpos.X - scale/2),(int)(viewpos.Y - scale),(int)scale, (int)scale);
            Rectangle animationRect = new Rectangle(m_Texture.Width / 8 * (int)model.getFrame(), 0, m_Texture.Width / 8, m_Texture.Height/2);
            m_spriteBatch.Draw(m_Texture, destrect, animationRect, Color.White);

            m_spriteBatch.End();
        }
     

   
        //return bool if user has press a keyboard button or not.
        public bool IsCharacterMovingToRight()
        {
            return Keyboard.GetState().IsKeyDown(Keys.Right);
        }

        public bool IsCharacterMovingToLeft()
        {
            return Keyboard.GetState().IsKeyDown(Keys.Left);
        }

        public bool IsCharacterJumping()
        {
            return Keyboard.GetState().IsKeyDown(Keys.Space);
        }

    }
}
