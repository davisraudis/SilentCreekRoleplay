using SampSharp.GameMode; // Contains BaseMode class
using SampSharp.GameMode.Controllers; // Contains ControllerCollection class
using SilentCreekRoleplay.Server.source;
using SilentCreekRoleplay.Server.Source.Events;
using System;
using SilentCreekRoleplay.Server;
using System.Collections.Generic;
using SilentCreekRoleplay.Server.Source;
using SilentCreekRoleplay.Server.Source.World;
using System.Timers;

public class GameMode : BaseMode
{
    #region Overrides of BaseMode
    protected override void OnInitialized(EventArgs e)
    {
        Console.WriteLine("\n----------------------------------");
        Console.WriteLine(" Silent Creek Roleplay by Dāvis");
        Console.WriteLine("----------------------------------\n");

        SetGameModeText($"{ServerUtils.ServerName} {ServerUtils.ServerVersion}");
        WorldTick.SetupTimer();
        base.OnInitialized(e);
    }

    protected override void LoadControllers(ControllerCollection controllers)
    {
        base.LoadControllers(controllers);

        // Register events
        controllers.Add(new OnPlayerConnect());
        controllers.Add(new OnPlayerRequestClass());
        controllers.Add(new OnPlayerDisconnect());
        
    }
    #endregion
}