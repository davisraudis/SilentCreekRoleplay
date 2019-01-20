using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;
using SilentCreekRoleplay.DataLayer;
using SilentCreekRoleplay.DataLayer.Exceptions;
using SilentCreekRoleplay.DataLayer.Managers;
using SilentCreekRoleplay.Server.Enums;
using SilentCreekRoleplay.Server.Source;
using System;
using System.Collections.Generic;

namespace SilentCreekRoleplay.Server.Controllers
{
    class AuthenticationController
    {

        private PlayerManager _playerManager = new PlayerManager();

        private InputDialog registerDialog = new InputDialog("Register",
                                            $@"Welcome to {ServerUtils.ServerName}                                              
                                            \nPlease register by typing password below:",
                                            true,
                                            "Register");
        private InputDialog loginDialog = new InputDialog("Login",
                                            $@"Welcome to {ServerUtils.ServerName}                                             
                                            \nPlease login by entering password into the inputbox below:",
                                            true,
                                            "Login");

        public AuthenticationController()
        {
            registerDialog.Response += RegisterDialogResponse;
            loginDialog.Response += LoginDialogResponse;
        }

        public void ShowRegisterDialog(BasePlayer player)
        {
            registerDialog.Show(player);
        }

        public void ShowLoginDialog(PlayerSession player)
        {
            loginDialog.Show(player);
        }

        private void RegisterDialogResponse(object sender, DialogResponseEventArgs response)
        {
            var player = response.Player as PlayerSession;
            if (response.DialogButton == DialogButton.Left)
            {
                if (response.InputText.Length > 6 && response.InputText.Length < 32)
                {
                    using (SilentCreekRoleplayContext db = new SilentCreekRoleplayContext())
                    {
                        try
                        {
                            _playerManager.RegisterPlayer(db, player.Name, response.InputText);
                            db.SaveChanges();

                            loginDialog.Show(response.Player);
                        }
                        catch (Exception)
                        {
                            Message.SendServerMessageToPlayer(player, MessageType.Error, "There has been an error on the server, please try again.");
                            registerDialog.Show(player);
                        }
                    }
                }
                else
                {
                    registerDialog.Show(player);
                }
            }
            else
            {
                registerDialog.Show(player);
            }
        }

        private void LoginDialogResponse(object sender, DialogResponseEventArgs response)
        {
            var player = response.Player as PlayerSession;
            if (response.DialogButton == DialogButton.Left)
            {              
                using (SilentCreekRoleplayContext db = new SilentCreekRoleplayContext())
                {
                    try
                    {
                        _playerManager.LoginPlayer(db, player.Name, response.InputText);

                        var playerEntity = _playerManager.GetPlayerEntityByPlayerName(db, player.Name);
                        Message.SendServerMessageToPlayer(response.Player, MessageType.Information, $"You have logged in as {response.Player.Name}.");

                        player.Authenticated = true;
                        player.PlayerData = playerEntity;
                    }
                    catch (FailedLoginException)
                    {
                        Message.SendServerMessageToPlayer(response.Player, MessageType.Error, "The credentials you have input in the dialog are invalid! Please try again.");
                        loginDialog.Show(response.Player);
                    }
                    catch (Exception)
                    {
                        Message.SendServerMessageToPlayer(response.Player, MessageType.Error, "There has been an error on the server, please try again.");
                        loginDialog.Show(response.Player);
                    }
                }
            }
            else
            {
                loginDialog.Show(player);
            }
        }
    }
}
