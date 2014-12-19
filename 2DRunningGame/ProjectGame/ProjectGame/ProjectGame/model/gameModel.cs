using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace ProjectGame.model
{
    class gameModel
    {

        private float frame = 0;
        private Vector2 position;
        private bool hasJumped;
        private Vector2 velocity;


        public gameModel()
        {
            hasJumped = true;
            position = new Vector2(0,20);
            velocity = new Vector2(0,0);
        }


        private Level m_level = new Level();

        internal Level GetLevel()
        {
            return m_level;
        }


        // Auto running to the right
        public void characterAutoMovingToRight()
        {
            position.X += 0.1f;
            
            if (frame >= 7)
            {
                frame = 0;
            }
            else
            {
                frame = frame + 0.1f;
            }
        }

        // player running faster.
        public void characterMovingFasterToRight()
        {
            
            position.X += 0.2f;

            if (frame >= 7)
            {
                frame = 0;
            }
            else
            {
                frame = frame + 0.2f;
            }
        }

        //Player running slowly.
        public void charcterMovingSlowlyToRight()
        {
            
            position.X += 0.05f;
           
            if (frame >= 7)
            {
                frame = 0;
            }
            else
            {
                frame = frame + 0.05f;
            }
        }

        //minus vlaue to jumping .
        public void charcterIsJumping()
        {

            velocity.Y = -0.22f;

            hasJumped = true;
        }

       public void isJumping()
       {
             position += velocity;
             if (hasJumped == true)
              {
                 // Give the veclocity the same value when it was before jumping.
                velocity.Y += 0.01f * 1;
                // No animation when jumping
                frame = 0;
              }
       }

       public void isPositionXLargerThanWindowsH()
       { 
           // player is not jumping player y position lager or equals level height
            if (position.Y  >= Level.g_levelHeight)
            {
                hasJumped = false;
            }
       }

    
       public void isNotJumping()
       {
           if (hasJumped == false)
           {
               velocity.Y = 0f;
           }
       }

        public Vector2 getVelocity()
        {
            return velocity;
        }


        public float getFrame()
        {
            return frame;
        }

        public bool getHasJumped()
        {
            return hasJumped;
        }

        internal Vector2 getPosition()
        {
            return position;
        }

    }
}
