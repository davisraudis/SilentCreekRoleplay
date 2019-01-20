using System;
using System.Collections.Generic;
using System.Text;

namespace SilentCreekRoleplay.Server.Source.World
{
    public static class Time
    {
        public static void Update()
        {
            var hour = DateTime.Now.Hour;
            SampSharp.GameMode.SAMP.Server.SetWorldTime(hour);
        }
    }
}
