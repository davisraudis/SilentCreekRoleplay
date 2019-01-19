using SampSharp.GameMode; // Contains BaseMode class
using SampSharp.GameMode.Controllers; // Contains ControllerCollection class
using SilentCreekRoleplay.Server.source;
using SilentCreekRoleplay.Server.Source.Events;
using System;
using SilentCreekRoleplay.DataLayer;
using SilentCreekRoleplay.Server;

public class GameMode : BaseMode
{
    #region Overrides of BaseMode

    protected override void OnInitialized(EventArgs e)
    {
        Console.WriteLine("\n----------------------------------");
        Console.WriteLine(" Blank Gamemode by your name here");
        Console.WriteLine("----------------------------------\n");

        SetGameModeText("sasa");
        /*
         * TODO: Do your initialisation and loading of data here.
         */
        base.OnInitialized(e);
    }

    protected override void LoadControllers(ControllerCollection controllers)
    {
        base.LoadControllers(controllers);

        // Register events
        controllers.Add(new OnPlayerConnect());
        controllers.Add(new OnPlayerRequestClass());
    }
    #endregion
}