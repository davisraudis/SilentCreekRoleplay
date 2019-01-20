using SampSharp.GameMode;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;
using SilentCreekRoleplay.DataLayer.Managers;
using SilentCreekRoleplay.Server.Source.Controllers;
using System;
using System.Collections.Generic;

namespace SilentCreekRoleplay.Server.Source.Events
{
    class OnPlayerTextEvent : BaseMode, IEventListener, IController
    {
        private PlayerManager _playerManager = new PlayerManager();
        private InCharacterChatController _inCharacterChatController;

        public OnPlayerTextEvent()
        {
            _inCharacterChatController = new InCharacterChatController();
        }

        public void RegisterEvents(BaseMode gameMode)
        {
            gameMode.PlayerText += HandleMessage;
        }

        private void HandleMessage(object sender, EventArgs e)
        {
            var player = sender as BasePlayer;

            if (player.State != PlayerState.None 
                && player.State != PlayerState.Wasted 
                && player.State != PlayerState.Spectating)
            {
                _inCharacterChatController.SendInCharacterLocalMessage(player, e.ToString());
            }
        }

        protected override void OnPlayerText(BasePlayer player, TextEventArgs e)
        {
            if (player.State != PlayerState.None || player.State != PlayerState.Wasted)
            {
                //base.OnPlayerText(player, e);
            }
        }
    }
}
