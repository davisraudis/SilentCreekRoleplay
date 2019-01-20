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
        private List<PlayerSession> _playerSessions = new List<PlayerSession>();

        private InputDialog registerDialog = new InputDialog("Register",
                                            $@"Welcome to {ServerUtils.ServerName}                                               
                                            \nPlease register by typing password below:",
                                            true,
                                            "Register");
        private InputDialog loginDialog = new InputDialog("Login",
                                            @"Welcome to {ServerUtils.ServerName}                                             
                                            \nPlease login by entering password into the inputbox below:",
                                            true,
                                            "Login");

        public AuthenticationController(List<PlayerSession> playerSessions)
        {
            _playerSessions = playerSessions;
            registerDialog.Response += RegisterDialogResponse;
            loginDialog.Response += LoginDialogResponse;
        }

        public void ShowRegisterDialog(BasePlayer player)
        {
            registerDialog.Show(player);
        }

        public void ShowLoginDialog(List<PlayerSession> loginSessions, BasePlayer player)
        {
            loginDialog.Show(player);
        }

        private void RegisterDialogResponse(object sender, DialogResponseEventArgs response)
        {
            if (response.InputText.Length > 6 && response.InputText.Length < 32)
            {
                using (SilentCreekRoleplayContext db = new SilentCreekRoleplayContext())
                {
                    try
                    {
                        _playerManager.RegisterPlayer(db, response.Player.Name, response.InputText);
                        db.SaveChanges();

                        loginDialog.Show(response.Player);
                    }
                    catch (Exception)
                    {
                        Message.SendServerMessageToPlayer(response.Player, MessageType.Error, "There has been an error on the server, please try again.");
                        registerDialog.Show(response.Player);
                    }
                }
            }
            else
            {
                registerDialog.Show(response.Player);
            }
        }

        private void LoginDialogResponse(object sender, DialogResponseEventArgs response)
        {
            using (SilentCreekRoleplayContext db = new SilentCreekRoleplayContext())
            {
                try
                {
                    _playerManager.LoginPlayer(db, response.Player.Name, response.InputText);
                    Message.SendServerMessageToPlayer(response.Player, MessageType.Information, $"You have logged in as {response.Player.Name}.");
                    _playerSessions.Add(new PlayerSession
                    {
                        Player = response.Player,
                        Authenticated = true
                    });
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
    }
}
