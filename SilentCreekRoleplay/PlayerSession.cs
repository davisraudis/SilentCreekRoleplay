using SampSharp.GameMode.World;

namespace SilentCreekRoleplay.Server
{
    public class PlayerSession
    {
        public BasePlayer Player { get; set; }

        public bool Authenticated { get; set; }
    }
}
