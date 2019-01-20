using SampSharp.Core;
using System;

namespace SilentCreekRoleplay
{
    class Program
    {
        static void Main(string[] args)
        {
            // GameModeStartBehaviour.FakeGmx - A fake GMX is particularly useful while you are developing your game mode. 
            // GameModeStartBehaviour.Gmx - This is the default start behaviour and should be used for servers running in production.
            #pragma warning disable CS0437 // Type conflicts with imported namespace
            new GameModeBuilder().UseStartBehaviour(GameModeStartBehaviour.FakeGmx).Use<GameMode>().Run();
            #pragma warning restore CS0437 // Type conflicts with imported namespace
        }
    }
}
