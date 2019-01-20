using System;
using System.Timers;

namespace SilentCreekRoleplay.Server.Source.World
{
    class WorldTimerState
    {
        public int Counter;
    }

    public static class WorldTick
    {
        private static readonly int updateTimeInterval = (int)TimeSpan.FromHours(1).TotalMilliseconds;
        private static readonly int updateWorldWeatherInterval = (int)TimeSpan.FromHours(4).TotalMilliseconds;

        public static void TickWorld(object timerState)
        {
            var state = timerState as WorldTimerState;

            if (state.Counter % updateTimeInterval == 0 || state.Counter == 1)
            {
                Time.Update();
            }
            if (state.Counter % updateWorldWeatherInterval == 0 || state.Counter == 1)
            {
                Weather.Update();
            }

            state.Counter ++;
        }

        public static void SetupTimer()
        {
            Timer ServerTick = new Timer();
            var serverTickTimerState = new WorldTimerState { Counter = 0 };

            ServerTick.Elapsed += (sender, e) => TickWorld(serverTickTimerState);
            ServerTick.Interval = 1000;
            ServerTick.Start();
        }
    }
}
