using SampSharp.GameMode.Pools;
using SampSharp.GameMode.World;
using SilentCreekRoleplay.DataLayer.Entities;

namespace SilentCreekRoleplay.Server
{
    [PooledType]
    public class PlayerSession : BasePlayer
    {
        public Player PlayerData { get; set; }

        public bool Authenticated { get; set; }
    }
}
