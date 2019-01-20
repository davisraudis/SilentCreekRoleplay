using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SilentCreekRoleplay.Server.Source.World
{
    class WorldTimerState
    {
        public int Counter;
    }

    public static class WorldTick
    {
        public static void TickWorld(object timerState)
        {
            var state = timerState as WorldTimerState;
            Interlocked.Increment(ref state.Counter);

            var updateTimeInterval = (int)TimeSpan.FromHours(1).TotalMilliseconds;
            var updateWorldWeatherInterval = (int)TimeSpan.FromHours(4).TotalMilliseconds;
            if (state.Counter % updateTimeInterval == 0 || state.Counter == 1)
            {
                Time.Update();
            }
            if (state.Counter % updateWorldWeatherInterval == 0 || state.Counter == 1)
            {
                Weather.Update();
            }
        }
    }
}
