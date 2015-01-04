using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ProjectGame.model
{
    class Ghost
    {
        public Vector2 DefaultChostrPosition = new Vector2(0.1f, 18);
        public Vector2 ghostPosition = new Vector2(0.1f, 18);
        private Vector2 m_speed = new Vector2(0, 0);

        /// <summary>
        /// Update ghost position.
        /// </summary>
        /// <param name="a_elapsedTime"></param>
        internal void Update(float a_elapsedTime)
        {
            ghostPosition = ghostPosition + m_speed * a_elapsedTime;
        }


        /// <summary>
        /// ghost moving to the right.
        /// </summary>
        public void ghostMovingToRight()
        {
            SetGhostSpeed(new Vector2(+4.8f, GetGhostSpeed().Y));
        }

        /// <summary>
        /// ghost moving faster to the right.
        /// </summary>
        public void ghostMovingFasterToRight()
        {
            SetGhostSpeed(new Vector2(+5.8f, GetGhostSpeed().Y));
        }

        /// <summary>
        /// return .
        /// </summary>
        /// <returns>ghost position</returns>
        internal Vector2 GetGhostPosition()
        {
            return ghostPosition;
        }

        /// <summary>
        /// return ghost speed.
        /// </summary>
        /// <returns></returns>
        internal Vector2 GetGhostSpeed()
        {
            return m_speed;
        }

        /// <summary>
        /// set ghost speed.
        /// </summary>
        /// <param name="a_speed"></param>
        internal void SetGhostSpeed(Vector2 a_speed)
        {
            m_speed = a_speed;
        }

        /// <summary>
        /// get ghost defalut position.
        /// </summary>
        /// <returns></returns>
        public Vector2 GetGhostDefaultPosition()
        {
            return ghostPosition = DefaultChostrPosition;
        }
    }
}
