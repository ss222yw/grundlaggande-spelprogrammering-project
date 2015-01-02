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
        //Some of code created by Dainel Toll.
        private Level m_level;
        private Player m_player;
        private Ghost m_ghost;
        public bool m_hasCollidedWithGround = false, m_hasCollidedWidthTheLeft = false, m_positionLagerThanTheLevel = false;
        private Vector2 newPos;
        private Vector2 oldPos;
        public bool isLevelCompleted, isGameOver;


        class CollisionDetails
        {
            public Vector2 m_speedAfterCollision;
            public Vector2 m_positionAfterCollision;
            public bool m_hasCollidedWithGround = false, m_hasCollidedWidthTheLeft = false;

            public CollisionDetails(Vector2 a_oldPos, Vector2 a_velocity)
            {
                m_positionAfterCollision = a_oldPos;
                m_speedAfterCollision = a_velocity;

            }

        }

        /// <summary>
        /// counstruct.
        /// </summary>
        /// <param name="level"></param>
        public gameModel(string level)
        {
            m_player = new Player();
            m_level = new Level(level);
            m_ghost = new Ghost();
        }


        public void UpdatePlayer(float a_elapsedTime)
        {
            //Get the old position
            oldPos = m_player.GetPosition();

            //Get the new position
            m_player.Update(a_elapsedTime);

            m_ghost.Update(a_elapsedTime);

            newPos = m_player.GetPosition();

            //Collide
            m_hasCollidedWithGround = false;
            Vector2 speed = m_player.GetSpeed();

            if (didCollide(newPos, m_player.m_sizes))
            {
                CollisionDetails details = getCollisionDetails(oldPos, newPos, m_player.m_sizes, speed);
                m_hasCollidedWithGround = details.m_hasCollidedWithGround;
                m_hasCollidedWidthTheLeft = details.m_hasCollidedWidthTheLeft;
                //set the new speed and position after collision
                m_player.SetPosition(details.m_positionAfterCollision);
                //    m_player.SetSpeed(details.m_speedAfterCollision);
            }

        }


        private bool didCollide(Vector2 a_centerBottom, Vector2 a_size)
        {
            FloatRectangle occupiedArea = FloatRectangle.createFromCenterBottom(a_centerBottom, a_size);

            if (m_level.IsCollidingAt(occupiedArea))
            {
                return true;
            }
            return false;
        }



        private CollisionDetails getCollisionDetails(Vector2 a_oldPos, Vector2 a_newPosition, Vector2 a_size, Vector2 a_velocity)
        {
            CollisionDetails ret = new CollisionDetails(a_oldPos, a_velocity);

            Vector2 slidingXPosition = new Vector2(a_newPosition.X, a_oldPos.Y); //Y movement ignored
            Vector2 slidingYPosition = new Vector2(a_oldPos.X, a_newPosition.Y); //X movement ignored

            if (didCollide(slidingXPosition, a_size) == false)
            {

                return doOnlyXMovement(ref a_velocity, ret, ref slidingXPosition);
            }
            if (didCollide(slidingYPosition, a_size) == true)
            {
                ret.m_hasCollidedWidthTheLeft = true;
                return doOnlyYMovement(ref a_velocity, ret, ref slidingYPosition);
            }

            if (didCollide(slidingYPosition, a_size) == false)
            {

                return doOnlyYMovement(ref a_velocity, ret, ref slidingYPosition);
            }
            else
            {

                return doStandStill(ret, a_velocity);
            }

        }



        /// <summary>
        /// return if true or false that the player has collided width the left side of the tile.
        /// </summary>
        /// <returns>bool</returns>
        public bool hasCollidedWidthTheLeft()
        {
            return m_hasCollidedWidthTheLeft;
        }


        private static CollisionDetails doStandStill(CollisionDetails ret, Vector2 a_velocity)
        {
            if (a_velocity.Y > 0)
            {
                ret.m_hasCollidedWithGround = true;
            }
            return ret;
        }


        private static CollisionDetails doOnlyYMovement(ref Vector2 a_velocity, CollisionDetails ret, ref Vector2 slidingYPosition)
        {
            ret.m_positionAfterCollision = slidingYPosition;
            return ret;
        }

        private static CollisionDetails doOnlyXMovement(ref Vector2 a_velocity, CollisionDetails ret, ref Vector2 slidingXPosition)
        {
            ret.m_positionAfterCollision = slidingXPosition;
            //did we slide on ground?
            if (a_velocity.Y > 0)
            {
                ret.m_hasCollidedWithGround = true;
            }
            return ret;
        }


        /// <summary>
        /// get level
        /// </summary>
        /// <returns></returns>
        internal Level GetLevel()
        {
            return m_level;
        }


        /// <summary>
        /// get player position at current time.
        /// </summary>
        /// <returns></returns>
        internal Vector2 GetPlayerPosition()
        {
            return m_player.GetPosition();
        }

        // Auto running to the right
        public void characterAutoMovingToRight()
        {
            m_player.characterAutoMovingToRight();
        }

        // player running faster.
        public void characterMovingFasterToRight()
        {

            m_player.characterMovingFasterToRight();
        }

        //Player running slowly.
        public void charcterMovingSlowlyToRight()
        {

            m_player.charcterMovingSlowlyToRight();

        }

        /// <summary>
        /// get player Y position for jumping.
        /// </summary>
        public void charcterIsJumping()
        {

            m_player.charcterIsJumping();
        }

        /// <summary>
        /// get number of the frames
        /// </summary>
        /// <returns></returns>
        public float getFrame()
        {
            return m_player.getFrame();
        }

        /// <summary>
        /// return bool is player has collid the ground or not.
        /// </summary>
        /// <returns></returns>
        public bool getHasJumped()
        {
            return m_hasCollidedWithGround;
        }

        /// <summary>
        /// get the player default position.
        /// </summary>
        /// <returns></returns>
        public Vector2 getPlayerDefaultPosition()
        {
            return m_player.playerPosition = m_player.DefaultPlayerPosition;
        }


        /// <summary>
        /// cheack if the player is at the end of the map.
        /// </summary>
        public void endOfTheGame()
        {
            if (m_player.PlayerPosition.X >= Level.g_levelWidth)
            {
                isLevelCompleted = true;
            }
            else
            {
                isLevelCompleted = false;
            }
        }

        /// <summary>
        /// number of lifes method to print it out.
        /// </summary>
        /// <returns></returns>
        public int nrOfLifes()
        {
            if (m_positionLagerThanTheLevel == true)
            {
                return loseALife();
            }
            return m_player.Lifes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>players life - 1</returns>
        public int loseALife()
        {
            m_positionLagerThanTheLevel = false;
            return m_player.Lifes -= 1;
        }


        /// <summary>
        /// cheack if player is dead.
        /// </summary>
        /// <returns></returns>
        private bool isDead()
        {
            if (nrOfLifes() <= 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// return true or false if player Y position is less or more than level height
        /// </summary>
        /// <returns>bool</returns>
        public bool didLoselife()
        {
            if (m_player.PlayerPosition.Y >= Level.g_levelHeight)
            {

                return m_positionLagerThanTheLevel = true;
            }

            return m_positionLagerThanTheLevel = false;
        }

        /// <summary>
        /// cheack if game is over.
        /// </summary>
        public void gameOver()
        {

            if (isDead())
            {
                isGameOver = true;
            }
            else if (didLoselife())
            {
                GhostDefaultPosition();
                getPlayerDefaultPosition();

            }
            else
            {
                isGameOver = false;
            }

        }

        /// <summary>
        /// rest lifes
        /// </summary>
        public void newLifes()
        {
            m_player.Lifes = 5;
        }


        // Auto running to the right level 2
        public void characterAutoMovingToRight2()
        {
            m_player.characterAutoMovingToRight2();
        }

        // player running faster.level 2
        public void characterMovingFasterToRight2()
        {

            m_player.characterMovingFasterToRight2();
        }

        //Player running slowly.level 2
        public void charcterMovingSlowlyToRight2()
        {

            m_player.charcterMovingSlowlyToRight2();

        }


        // Auto running to the right level 3
        public void characterAutoMovingToRight3()
        {
            m_player.characterAutoMovingToRight3();
        }

        // player running faster.level 3
        public void characterMovingFasterToRight3()
        {

            m_player.characterMovingFasterToRight3();
        }

        //Player running slowly.level 3
        public void charcterMovingSlowlyToRight3()
        {

            m_player.charcterMovingSlowlyToRight3();

        }

        /// <summary>
        /// return ghost position.
        /// </summary>
        /// <returns></returns>
        public Vector2 getGhostPosition()
        {
            return m_ghost.GetGhostPosition();
        }

        /// <summary>
        /// ghost moving to the right .
        /// </summary>
        public void ghostMovingToRight()
        {
            m_ghost.ghostMovingToRight();
        }

        /// <summary>
        /// return default position for the ghost.
        /// </summary>
        /// <returns>ghost position</returns>
        public Vector2 GhostDefaultPosition()
        {
            return m_ghost.GetGhostDefaultPosition();
        }

        /// <summary>
        /// ghost moving faster to the right.
        /// </summary>
        public void ghostMovingFasterToRight()
        {
            m_ghost.ghostMovingFasterToRight();
        }

    }
}
