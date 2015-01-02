using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using ProjectGame.model;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace ProjectGame.view
{
    class SplitterView
    {
         private SpriteBatch m_spriteBatch;
        private Texture2D m_SplitterTexture;
        private Camera camera;
        private SplitterSystem splitterSystem;

        public float XPosition = 0.7f;
        public float YPosition = 0.8f;

        internal Vector2 getStartPosition()
        {
            return new Vector2(XPosition, YPosition);
        }

        public SplitterView(GraphicsDevice graphicsDevice, ContentManager content)
        {
            camera = new Camera(graphicsDevice.Viewport);
            m_spriteBatch = new SpriteBatch(graphicsDevice);
            splitterSystem = new SplitterSystem(getStartPosition());
            m_SplitterTexture = content.Load<Texture2D>("glass");

        }


        internal void draw(float gameTime)
        {
            splitterSystem.Update(gameTime);

            m_spriteBatch.Begin();
            splitterSystem.Draw(m_spriteBatch, camera, m_SplitterTexture);
            m_spriteBatch.End();
        }
    }
}
