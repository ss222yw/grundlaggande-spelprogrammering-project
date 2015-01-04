using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ProjectGame.model
{
    class BombModel
    {

        private Vector2 bombPosition;
        private Vector2 velocity;
        public bool isHidden = false;
        private int m_currentLeve;

        /// <summary>
        /// Counstruct
        /// </summary>
        /// <param name="bombOldPosition"></param>
        public BombModel(Vector2 bombOldPosition,int currentLevel)
        {
            bombPosition = bombOldPosition;
            velocity = new Vector2(-1.4f, 2.4f);
            this.m_currentLeve = currentLevel;
        }

        /// <summary>
        /// set new position for bomb texture.
        /// </summary>
        public void Update()
        {
            bombPosition += velocity;
            if (m_currentLeve == 2)
            {
        
                if (bombPosition.Y > Level.g_levelHeight * 23)
                {
                    velocity.Y = -2.4f;
                }
            }

            if (bombPosition.Y  < 30)
            {
                isHidden = true;
            }

        }

        /// <summary>
        /// get bomb position
        /// </summary>
        public Vector2 BombPosition
        {
            get
            {
                return bombPosition;
            }
            set
            {
                bombPosition = value;
            }
        }

    }
}
