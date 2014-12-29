using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using ProjectGame.controller;
using System.IO;

namespace ProjectGame.model
{
    class Level
    {
        // some of Code took from (https://code.google.com/p/1dv437arkanoid/source/browse/trunk/Collisions/Collisions2/Model/Level.cs).

        public const int g_levelWidth = 140;
        public const int g_levelHeight = 15;

        private string m_levels;

        internal TileType[,] m_tiles = new TileType[g_levelWidth, g_levelHeight];
        private  string levelString;
        private bool isGameOver;

        //public Level(string levels)
        //{
        //    m_levels = levels;
        //    GenerateLevel();
        //}

        public Level(string levelString)
        {
            // TODO: Complete member initialization
            m_levels = levelString;
           // this.isGameOver = isGameOver;
            GenerateLevel();
        }

        private void GenerateLevel()
        {
            for (int x = 0; x < g_levelWidth; x++)
            {
                for (int y = 0; y < g_levelHeight; y++)
                {
                    int index = y * g_levelWidth + x;

                    if (m_levels[index] == '1')
                    {
                        m_tiles[x, y] = TileType.BLOCKED;
                    }

                    if (m_levels[index] == '2')
                    {
                        m_tiles[x, y] = TileType.Background;
                    }

                    if (m_levels[index] == '3')
                    {
                        m_tiles[x, y] = TileType.Water;
                    }
                }
            }
        }

        internal bool IsCollidingAt(FloatRectangle a_rect)
        {
           Vector2 tileSize = new Vector2(1, 1);
            for (int x = 0; x < g_levelWidth; x++)
            {
                for (int y = 0; y < g_levelHeight; y++)
                {
                    FloatRectangle rect = FloatRectangle.createFromTopLeft(new Vector2(x, y), tileSize);
                    if (a_rect.isIntersecting(rect))
                    {
                        if (m_tiles[x, y] == TileType.BLOCKED || m_tiles[x,y] == TileType.Background)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }




        /// <summary>
        /// Read to the end of lines to make a level map.
        /// </summary>
        /// <param name="currentLevel"></param>
        /// <returns></returns>
        public static string Maps(int currentLevel)
        {

            using (StreamReader sr = new StreamReader(System.IO.Path.GetFullPath(String.Format("Content/Level{0}.txt", currentLevel))))
            {
                string lines = sr.ReadToEnd();
                while (IndexOfN(lines) != -1 && IndexOfR(lines) != -1)
                {
                    if (IndexOfN(lines) != -1)
                    {
                        lines = lines.Remove(IndexOfN(lines), 1);
                    }

                    if (IndexOfR(lines) != -1)
                    {
                        lines = lines.Remove(IndexOfR(lines), 1);
                    }
                }
                return lines;
            }
        }

        private static int IndexOfR(string lines)
        {
            return lines.IndexOf("\r");
        }

        private static int IndexOfN(string lines)
        {
            return lines.IndexOf("\n");
        }

    }
}
