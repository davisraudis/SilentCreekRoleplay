using SampSharp.GameMode; // Contains BaseMode class
using SampSharp.GameMode.Controllers; // Contains ControllerCollection class
using SilentCreekRoleplay.Server.source;
using SilentCreekRoleplay.Server.Source.Events;
using System;
using SilentCreekRoleplay.DataLayer;
using SilentCreekRoleplay.Server;
using System.Collections.Generic;
using SilentCreekRoleplay.Server.Source;

public class GameMode : BaseMode
{
    #region Overrides of BaseMode

    public List<PlayerSession> PlayerSessions = new List<PlayerSession>();

    protected override void OnInitialized(EventArgs e)
    {
        Console.WriteLine("\n----------------------------------");
        Console.WriteLine(" Blank Gamemode by your name here");
        Console.WriteLine("----------------------------------\n");

        SetGameModeText($"{ServerUtils.ServerName} {ServerUtils.ServerVersion}");
        base.OnInitialized(e);
    }

    protected override void LoadControllers(ControllerCollection controllers)
    {
        base.LoadControllers(controllers);

        // Register events
        controllers.Add(new OnPlayerConnect(PlayerSessions));
        controllers.Add(new OnPlayerRequestClass());
        controllers.Add(new OnPlayerDisconnect(PlayerSessions));
    }
    #endregion
}