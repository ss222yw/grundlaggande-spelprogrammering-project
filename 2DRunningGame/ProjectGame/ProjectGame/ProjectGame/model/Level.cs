using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectGame.model
{
    class Level
    {
        // Code took from (https://code.google.com/p/1dv437arkanoid/source/browse/trunk/Collisions/Collisions2/Model/Level.cs).
        public const int g_levelWidth = 80;
        public const int g_levelHeight = 20;

        internal Tile[,] m_tiles = new Tile[g_levelWidth, g_levelHeight];

        internal Level()
        {
            GenerateLevel();
        }

        private void GenerateLevel()
        {   
            // Random rand = new Random();
            for (int x = 0; x < g_levelWidth; x++)
            {
                for (int y = 0; y < g_levelHeight; y++)
                {

                    m_tiles[x, y] = Tile.createEmpty();
                }

            }
        }

    }
}
