using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ProjectGame.view
{
    class SplitterSystem
    {
        private SplitterParticle[] splitterParticles;
        private const int NUM_PARTICLES = 100;

        public SplitterSystem(Vector2 systemModelStartPosition)
        {
            splitterParticles = new SplitterParticle[NUM_PARTICLES];

            for (int i = 0; i < NUM_PARTICLES; i++)
            {
                splitterParticles[i] = new SplitterParticle(i, systemModelStartPosition);
            }
        }

        internal void Draw(SpriteBatch m_spriteBatch, Camera camera, Texture2D m_SplitterTexture)
        {
            for (int i = 0; i < NUM_PARTICLES; i++)
            {
                splitterParticles[i].Draw(m_spriteBatch, camera, m_SplitterTexture);
            }
        }

        internal void Update(float gameTime)
        {


            for (int i = 0; i < NUM_PARTICLES; i++)
            {
                splitterParticles[i].Update(gameTime);
            }


        }
    }
}
