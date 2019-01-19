using SampSharp.GameMode.Display;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;
using SilentCreekRoleplay.DataLayer;
using SilentCreekRoleplay.DataLayer.Managers;
using SilentCreekRoleplay.Server.Source;
using System;

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
                                            @"Welcome to {ServerUtils.ServerName}                                             
                                            \nPlease login by entering password into the inputbox below:",
                                            true,
                                            "Login");

        public void ShowRegisterDialog(BasePlayer player)
        {
            registerDialog.Response += RegisterDialogResponse;
            registerDialog.Show(player);
        }

        public void ShowLoginDialog(BasePlayer player)
        {
            registerDialog.Response += LoginDialogResponse;
            loginDialog.Show(player);
        }

        private void RegisterDialogResponse(object sender, DialogResponseEventArgs response)
        {
            if (response.InputText.Length < 6 && response.InputText.Length > 32)
            {
                using (SilentCreekRoleplayContext db = new SilentCreekRoleplayContext())
                {
                    try
                    {
                        var player = sender as BasePlayer;
                        _playerManager.RegisterPlayer(db, player.Name, response.InputText);
                        db.SaveChanges();
                    }
                    catch (Exception)
                    {
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
        }
    }
}
