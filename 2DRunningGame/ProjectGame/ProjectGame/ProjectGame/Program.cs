using System;
using ProjectGame.controller;

namespace ProjectGame
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (MasterController game = new MasterController())
            {
                game.Run();
            }
        }
    }
#endif
}

