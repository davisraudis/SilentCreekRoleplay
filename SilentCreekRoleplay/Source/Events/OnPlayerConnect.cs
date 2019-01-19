using SampSharp.GameMode;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.World;
using SampSharp.GameMode.SAMP;
using System;
using SilentCreekRoleplay.DataLayer;
using SilentCreekRoleplay.DataLayer.Managers;
using SilentCreekRoleplay.Server.Controllers;
using SilentCreekRoleplay.Server.Source;
using ServerUtils = SilentCreekRoleplay.Server.Source.ServerUtils;

namespace SilentCreekRoleplay.Server.source
{
    class OnPlayerConnect : IEventListener, IController
    {
        private PlayerManager _playerManager = new PlayerManager();
        private AuthenticationController _authenticationController = new AuthenticationController(); 

        public void RegisterEvents(BaseMode gameMode)
        {
            gameMode.PlayerConnected += loadPlayerFromDatabase;
        }

        private void loadPlayerFromDatabase(object sender, EventArgs e)
        {
            var player = sender as BasePlayer;
            using (SilentCreekRoleplayContext db = new SilentCreekRoleplayContext())
            {
                var playerEntity = _playerManager.GetPlayerEntityByPlayerName(db, player.Name);
    
                if (playerEntity != null)
                {
                    Message.SendServerMessageToPlayer(player, Enums.MessageType.Information, $"Welcome back to {ServerUtils.ServerName}!");
                    Message.SendServerMessageToPlayer(player, Enums.MessageType.Information, $"Please login, input the password to your account in the dialog in order to proceed.");
                    _authenticationController.ShowLoginDialog(player);
                }
                else
                {
                    Message.SendServerMessageToPlayer(player, Enums.MessageType.Information, $"Welcome {player.Name} to {ServerUtils.ServerName}! Enjoy your stay!");
                    Message.SendServerMessageToPlayer(player, Enums.MessageType.Information, $"Registration is mandatory, please input the password for your account in the dialog.");
                    _authenticationController.ShowRegisterDialog(player);
                }
            }
        }
    }
}
