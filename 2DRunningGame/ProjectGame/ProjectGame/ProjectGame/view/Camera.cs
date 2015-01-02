using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectGame.model;

namespace ProjectGame.view
{
    class Camera
    {
        //Source code (https://code.google.com/p/1dv437arkanoid/source/browse/trunk/Collisions/Collisions2/View/Camera.cs)
        private Vector2 m_modelCenterPosition = new Vector2(0, 0);
        private float m_scale = 64;
        private float scale;
        private float scaleX;
        private float scaleY;
        private static int frame = 12;


        public float XPosition = 0.5f;
        public float YPosition = 0.6f;


        public Camera(Viewport port)
        {

            scaleX = port.Width - frame * 2;
            scaleY = port.Height - frame * 2;



            scale = scaleX;
            if (scaleY < scaleX)
            {
                scale = scaleY;
            }
        }

        internal float GetScale()
        {
            return m_scale;
        }

        internal Microsoft.Xna.Framework.Rectangle translatRec(float x, float y, float p_3)
        {
            float vX = p_3 * scaleX;
            float vY = p_3 * scaleY;

            int screenX = (int)((x * scaleX + XPosition) - vX);
            int screenY = (int)((y * scaleY + YPosition) - vY);

            return new Microsoft.Xna.Framework.Rectangle(screenX, screenY, (int)(vX * 1f), (int)(vY * 1f));
        }



        internal float toViewX(float x)
        {
            return x * scaleX;
        }

        internal float toViewY(float y)
        {
            return y * scaleY;
        }

        internal Vector2 GetViewPosition(float x, float y, Vector2 a_viewPortSize)
        {
            Vector2 modelPosition = new Vector2(x, y);

            Vector2 modelViewPortSize = new Vector2(a_viewPortSize.X / m_scale, a_viewPortSize.Y / m_scale);

            //get model top left position
            Vector2 modelTopLeftPosition = m_modelCenterPosition - modelViewPortSize / 2.0f;



            return (modelPosition - modelTopLeftPosition) * m_scale;
        }

        internal void SetZoom(float a_scale)
        {
            m_scale = a_scale;
        }

        internal void CenterOn(Vector2 a_newCenterPosition, Vector2 a_viewPortSize, Vector2 a_levelSize)
        {
            m_modelCenterPosition = a_newCenterPosition;

            Vector2 modelViewPortSize = new Vector2(a_viewPortSize.X / m_scale, a_viewPortSize.Y / m_scale);

            //check left
            if (m_modelCenterPosition.X < modelViewPortSize.X / 2.0f)
            {
                m_modelCenterPosition.X = modelViewPortSize.X / 2.0f;
            }

            //check bottom
            if (m_modelCenterPosition.Y > a_levelSize.Y - modelViewPortSize.Y / 2.0f)
            {
                m_modelCenterPosition.Y = a_levelSize.Y - modelViewPortSize.Y / 2.0f;
            }

            //check top
            if (m_modelCenterPosition.Y < modelViewPortSize.Y / 2.0f)
            {
                m_modelCenterPosition.Y = modelViewPortSize.Y / 2.0f;
            }
        }
    }
}
