using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ProjectGame.view
{
    class RainView
    {

        private Texture2D m_RainTexture;
        private Vector2 m_RainPosition;
        private Vector2 m_Velocity;

        /// <summary>
        /// Construct
        /// </summary>
        /// <param name="newTexture"></param>
        /// <param name="newPosition"></param>
        /// <param name="newVelocity"></param>
        public RainView(Texture2D newTexture, Vector2 newPosition, Vector2 newVelocity)
        {
            m_RainTexture = newTexture;
            m_RainPosition = newPosition;
            m_Velocity = newVelocity;
        }

        /// <summary>
        /// update rain positions.
        /// </summary>
        public void Update()
        {
            m_RainPosition += m_Velocity;
        }

        /// <summary>
        /// Draw rain texture.
        /// </summary>
        /// <param name="sprite"></param>
        public void DrawRain(SpriteBatch sprite,Color color)
        {
            Rectangle rainRectangle = new Rectangle((int)m_RainPosition.X, (int)m_RainPosition.Y, 7, 7);
            sprite.Draw(m_RainTexture, rainRectangle, color);
        }


        public Vector2 Position
        {
            get
            {
                return m_RainPosition;
            }
        }
    }
}
