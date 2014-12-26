using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ProjectGame.model
{
    class Player
    {
        public Vector2 DefaultPlayerPosition = new Vector2(2.5f, 13);
        public Vector2 playerPosition = new Vector2(2.5f, 13);
        private Vector2 m_speed = new Vector2(0, 0);
        public Vector2 m_sizes = new Vector2(0.95f, 0.95f);
        public float frame = 0;


        internal void Update(float a_elapsedTime)
        {
            Vector2 gravityAcceleration = new Vector2(0.0f, 11);
            //integrate position
            playerPosition = playerPosition + m_speed * a_elapsedTime;
            //integrate speed
            m_speed = m_speed + a_elapsedTime * gravityAcceleration;
        }


        internal void characterAutoMovingToRight()
        {
            SetSpeed(new Vector2(+3.0f, GetSpeed().Y));

            if (frame >= 7)
            {
                frame = 0;
            }
            else
            {
                frame = frame + 0.1f;
            }
        }

        internal void characterMovingFasterToRight()
        {
            SetSpeed(new Vector2(+5.0f, GetSpeed().Y));

            if (frame >= 7)
            {
                frame = 0;
            }
            else
            {
                frame = frame + 0.2f;
            }
        }

        internal void charcterMovingSlowlyToRight()
        {
            SetSpeed(new Vector2(+1.0f, GetSpeed().Y));

            if (frame >= 7)
            {
                frame = 0;
            }
            else
            {
                frame = frame + 0.05f;
            }
        }

        internal void charcterIsJumping()
        {
            m_speed.Y = -5;
        }

        internal Vector2 GetPosition()
        {
            return playerPosition;
        }

        internal void SetPosition(Vector2 a_pos)
        {
            playerPosition = a_pos;
        }

        internal Vector2 GetSpeed()
        {
            return m_speed;
        }

        internal void SetSpeed(Vector2 a_speed)
        {
            m_speed = a_speed;
        }

        internal float getFrame()
        {
            return frame;
        }


        public Vector2 PlayerPosition
        {
            get
            {
                return playerPosition;
            }
            set
            {
                playerPosition = value;
            }
        }
    }
}
