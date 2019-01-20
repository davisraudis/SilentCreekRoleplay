using SampSharp.GameMode; // Contains BaseMode class
using SampSharp.GameMode.Controllers; // Contains ControllerCollection class
using SilentCreekRoleplay.Server.source;
using SilentCreekRoleplay.Server.Source.Events;
using System;
using SilentCreekRoleplay.Server;
using System.Collections.Generic;
using SilentCreekRoleplay.Server.Source;
using System.Threading;
using SilentCreekRoleplay.Server.Source.World;

public class GameMode : BaseMode
{
    public List<PlayerSession> PlayerSessions = new List<PlayerSession>();
    private static Timer ServerTick;

    #region Overrides of BaseMode
    protected override void OnInitialized(EventArgs e)
    {
        var serverTickTimerState = new WorldTimerState { Counter = 0 };
        // ToDo single thread timer
        ServerTick = new Timer(new TimerCallback(WorldTick.TickWorld), serverTickTimerState, 0, 2000);

        Console.WriteLine("\n----------------------------------");
        Console.WriteLine(" Silent Creek Roleplay by Dāvis");
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