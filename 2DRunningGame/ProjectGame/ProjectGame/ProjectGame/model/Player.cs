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
        private int m_lifes = 4;


        internal void Update(float a_elapsedTime)
        {
            Vector2 gravityAcceleration = new Vector2(0.0f, 11);
            //integrate position
            playerPosition = playerPosition + m_speed * a_elapsedTime;
            //integrate speed
            m_speed = m_speed + a_elapsedTime * gravityAcceleration;
        }

        /// <summary>
        /// player x position moving to the right.
        /// for level one
        /// </summary>
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


        /// <summary>
        /// player x position moving faster to the right.
        /// for level one
        /// </summary>
        internal void characterMovingFasterToRight()
        {
            SetSpeed(new Vector2(+4.0f, GetSpeed().Y));

            if (frame >= 7)
            {
                frame = 0;
            }
            else
            {
                frame = frame + 0.2f;
            }
        }


        /// <summary>
        /// player x position moving slowly to the right.
        /// </summary>
        internal void charcterMovingSlowlyToRight()
        {
            SetSpeed(new Vector2(+2.0f, GetSpeed().Y));

            if (frame >= 7)
            {
                frame = 0;
            }
            else
            {
                frame = frame + 0.05f;
            }
        }


        /// <summary>
        /// give - value to player y position for jumping.
        /// </summary>
        internal void charcterIsJumping()
        {
            m_speed.Y = -5;
        }

        /// <summary>
        /// get player x and y position.
        /// </summary>
        /// <returns></returns>
        internal Vector2 GetPosition()
        {
            return playerPosition;
        }


        /// <summary>
        /// set player new x and y position.
        /// </summary>
        /// <param name="a_pos"></param>
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

        /// <summary>
        /// return number of frames.
        /// </summary>
        /// <returns>frame</returns>
        internal float getFrame()
        {
            return frame;
        }


        /// <summary>
        /// get and set player position.
        /// </summary>
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


        /// <summary>
        /// get and set number of players lifes.
        /// </summary>
        public int Lifes
         {
            get
            {
                return m_lifes;
            }
            set
            {
                m_lifes = value;
            }
        }


        /// <summary>
        /// player x position moving to the right.
        /// for level 2
        /// </summary>
        internal void characterAutoMovingToRight2()
        {
            SetSpeed(new Vector2(+4.0f, GetSpeed().Y));

            if (frame >= 7)
            {
                frame = 0;
            }
            else
            {
                frame = frame + 0.2f;
            }
        }


        /// <summary>
        /// player x position moving faster to the right.
        /// for level two
        /// </summary>
        internal void characterMovingFasterToRight2()
        {
            SetSpeed(new Vector2(+5.0f, GetSpeed().Y));

            if (frame >= 7)
            {
                frame = 0;
            }
            else
            {
                frame = frame + 0.25f;
            }
        }


        /// <summary>
        /// player x position moving slowly to the right.
        /// for level two
        /// </summary>
        internal void charcterMovingSlowlyToRight2()
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



        /// <summary>
        /// player x position moving to the right.
        /// for level 3
        /// </summary>
        internal void characterAutoMovingToRight3()
        {
            SetSpeed(new Vector2(+5.0f, GetSpeed().Y));

            if (frame >= 7)
            {
                frame = 0;
            }
            else
            {
                frame = frame + 0.25f;
            }
        }


        /// <summary>
        /// player x position moving faster to the right.
        /// for level three
        /// </summary>
        internal void characterMovingFasterToRight3()
        {
            SetSpeed(new Vector2(+6.0f, GetSpeed().Y));

            if (frame >= 7)
            {
                frame = 0;
            }
            else
            {
                frame = frame + 0.3f;
            }
        }


        /// <summary>
        /// player x position moving slowly to the right.
        /// for level three
        /// </summary>
        internal void charcterMovingSlowlyToRight3()
        {
            SetSpeed(new Vector2(+4.0f, GetSpeed().Y));

            if (frame >= 7)
            {
                frame = 0;
            }
            else
            {
                frame = frame + 0.2f;
            }
        }
    }

}

