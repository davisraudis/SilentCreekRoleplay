﻿using SampSharp.GameMode;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.World;
using SilentCreekRoleplay.DataLayer;
using SilentCreekRoleplay.DataLayer.Managers;
using System;

namespace SilentCreekRoleplay.Server.Source.Events
{
    class OnPlayerRequestClass : IEventListener, IController
    {
        private PlayerManager _playerManager = new PlayerManager();

        public void RegisterEvents(BaseMode gameMode)
        {
            gameMode.PlayerRequestClass += spawnPlayer;
        }

        private void spawnPlayer(object sender, EventArgs e)
        {
            var player = sender as BasePlayer;

            using (SilentCreekRoleplayContext db = new SilentCreekRoleplayContext())
            {
                var playerEntity = _playerManager.GetPlayerEntityByPlayerName(db, player.Name);

                if(playerEntity != null)
                {
                    var spawnCoordinates = new Vector3(playerEntity.X, playerEntity.Y, playerEntity.Z);
                    var spawnRotation = 269.1F;

                    player.SetSpawnInfo(0, 12, spawnCoordinates, spawnRotation);
                    player.Spawn();
                }
                else
                {
                    player.Kick();
                }
            }
        }
    }
}
