using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectGame.model
{
    class Tile
    {
        private enum TileType
        {
            EMPTY = 0,
            BLOCKED,
            TRAP
        };

        internal static Tile createBlocked()
        {
            return new Tile(TileType.BLOCKED);

        }

        internal static Tile createEmpty()
        {
            return new Tile(TileType.EMPTY);
        }

        private Tile(TileType a_type)
        {
            m_type = a_type;
        }
        TileType m_type;

        internal bool isBlocked()
        {
            return m_type == TileType.BLOCKED;
        }
    }
}
