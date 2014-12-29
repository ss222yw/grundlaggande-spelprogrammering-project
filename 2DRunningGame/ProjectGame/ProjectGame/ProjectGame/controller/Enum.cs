using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectGame.controller
{
    /// <summary>
    /// gamestate enum.
    /// </summary>
    enum GameState
    {
        MainMenu,
        Pause,
        Options,
        GameOver,
        Playing,
        Finish
    }

    /// <summary>
    /// tile type enum.
    /// </summary>
    enum TileType
    {
        EMPTY = 0,
        BLOCKED,
        Background,
        Water
    };
}
