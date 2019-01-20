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
        private List<PlayerSession> _loginSessions;

        public OnPlayerDisconnect(List<PlayerSession> loginSessions)
        {
            _loginSessions = loginSessions;
        }

        public void RegisterEvents(BaseMode gameMode)
        {
            gameMode.PlayerDisconnected += SavePlayerData;
        }

        private void SavePlayerData(object sender, EventArgs e)
        {
            var player = sender as BasePlayer;
            var session = _loginSessions.FirstOrDefault(l => ReferenceEquals(l.Player, player));

            if (session != null)
            {
                if (session.Authenticated)
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

                _loginSessions.Remove(session);
            }
            else
            {
                // The player was not logged in
            }
        }
    }
}
