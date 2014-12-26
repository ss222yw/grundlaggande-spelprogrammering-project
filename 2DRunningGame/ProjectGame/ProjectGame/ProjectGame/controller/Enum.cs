using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectGame.controller
{
    enum GameState
    {
        MainMenu,
        Pause,
        Options,
        End,
        GameOver,
        Playing
    }

    enum TileType
    {
        EMPTY = 0,
        BLOCKED,
        Background,
        Water
    };
}
