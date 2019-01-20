using SampSharp.GameMode.World;
using SilentCreekRoleplay.DataLayer.Entities;

namespace SilentCreekRoleplay.Server
{
    public class PlayerSession
    {
        public BasePlayer Player { get; set; }

        public Player PlayerData { get; set; }

        public bool Authenticated { get; set; }
    }
}
