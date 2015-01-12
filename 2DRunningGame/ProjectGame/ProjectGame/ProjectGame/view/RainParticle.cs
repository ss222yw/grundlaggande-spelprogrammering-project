using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ProjectGame.view
{
    class RainParticle
    {

        private Texture2D m_rainTexture;
        private float space;
        private List<RainView> rainView;
        private float m_seconds;
        private Random random1, random2;
        private GraphicsDevice GraphicsDevice;
 
        /// <summary>
        /// Construct
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="GraphicsDevice"></param>
        /// <param name="newSpace"></param>
        public RainParticle(Microsoft.Xna.Framework.Content.ContentManager Content, Microsoft.Xna.Framework.Graphics.GraphicsDevice GraphicsDevice, int newSpace)
        {
            // TODO: Complete member initialization
            rainView = new List<RainView>();
            this.m_rainTexture = Content.Load<Texture2D>("rain");
            this.GraphicsDevice = GraphicsDevice;
            this.space = newSpace;
            random1 = new Random();
            random2 = new Random();
        }



        /// <summary>
        /// update rain particles
        /// </summary>
        /// <param name="elapased"></param>
        public void Update(float elapased)
        {
            m_seconds += elapased;
            while (m_seconds > 1)
            {
                m_seconds -= 1 / space;
                AddParticles();
            }

            for (int i = 0; i < rainView.Count; i++)
            {
                rainView[i].Update();

                if (rainView[i].Position.Y > GraphicsDevice.Viewport.Height)
                {
                    rainView.RemoveAt(i);
                    i--;
                }
            }
        }

        /// <summary>
        /// re add rain particles.
        /// </summary>
        public void AddParticles()
        {
            Vector2 randomOne =  new Vector2(100 + (float)random1.NextDouble() * GraphicsDevice.Viewport.Width, -10);
            Vector2 randomTwo = new Vector2(-5, (float)random2.NextDouble() + 10);
            rainView.Add(new RainView(m_rainTexture,randomOne,randomTwo));
        }


        /// <summary>
        /// spritebatch to rainView.
        /// </summary>
        /// <param name="sprite"></param>
        public void Draw(SpriteBatch sprite,Color color)
        {
            foreach (RainView rain in rainView)
            {
                rain.DrawRain(sprite,color);
            }
        }
    }
}
