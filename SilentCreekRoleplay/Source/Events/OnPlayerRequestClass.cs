using SampSharp.GameMode;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.World;
using System;

namespace SilentCreekRoleplay.Server.Source.Events
{
    class OnPlayerRequestClass : IEventListener, IController
    {
        public void RegisterEvents(BaseMode gameMode)
        {
            gameMode.PlayerRequestClass += spawnPlayer;
        }

        private void spawnPlayer(object sender, EventArgs e)
        {
            var player = sender as BasePlayer;
            var spawnCoordinates = new Vector3(1958.33, 1343.12, 15.36);
            var spawnRotation = 269.1F;

            player.SetSpawnInfo(0, 12, spawnCoordinates, spawnRotation);
            player.Spawn();
        }
    }
}
