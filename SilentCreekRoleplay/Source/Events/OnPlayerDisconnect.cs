using SampSharp.GameMode;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.World;
using SilentCreekRoleplay.DataLayer;
using SilentCreekRoleplay.DataLayer.Entities;
using SilentCreekRoleplay.DataLayer.Managers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SilentCreekRoleplay.Server.Source.Events
{
    class OnPlayerDisconnect : IEventListener, IController
    {
        private PlayerManager _playerManager = new PlayerManager();

        public OnPlayerDisconnect()
        {
        }

        public void RegisterEvents(BaseMode gameMode)
        {
            gameMode.PlayerDisconnected += SavePlayerData;
        }

        private void SavePlayerData(object sender, EventArgs e)
        {
            var player = sender as PlayerSession;

            if (player != null)
            {
                if (player.Authenticated)
                {
                    using (SilentCreekRoleplayContext db = new SilentCreekRoleplayContext())
                    {
                        var playerData = new Player
                        {
                            Name = player.Name,
                            X = player.Position.X,
                            Y = player.Position.Y,
                            Z = player.Position.Z,
                            A = player.Angle,
                            Skin = player.Skin,
                            Health = player.Health
                        };

                        _playerManager.SavePlayer(db, playerData);
                        db.SaveChanges();
                    }
                }

            }
            else
            {
                // The player was not logged in
            }
        }
    }
}
