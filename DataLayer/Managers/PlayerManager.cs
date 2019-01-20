using SilentCreekRoleplay.DataLayer.Entities;
using SilentCreekRoleplay.DataLayer.Exceptions;
using System;
using System.Linq;


namespace SilentCreekRoleplay.DataLayer.Managers
{
    public class PlayerManager
    {
        public Exception LoginFailedException { get; private set; }

        public Player GetPlayerEntityByPlayerName(SilentCreekRoleplayContext db, string playerName)
        {
            var databasePlayer = db.Players.FirstOrDefault(p => p.Name == playerName);
            return databasePlayer;
        }

        public void RegisterPlayer(SilentCreekRoleplayContext db, string name, string password)
        {
            var exist = db.Players.Any(p => p.Name == name);
            if (!exist)
            {
                var player = new Player
                {
                    Name = name,
                    Password = Utils.CreateMD5(password)
                };

                db.Players.Add(player);
            }
        }

        public void LoginPlayer(SilentCreekRoleplayContext db, string name, string password)
        {
            var md5Password = Utils.CreateMD5(password);
            var succesfulLogin = db.Players.Any(p => p.Name == name && p.Password == md5Password);

            if (succesfulLogin)
            {

            }
            else
            {
                throw new FailedLoginException();
            }
        }

        public void SavePlayer(SilentCreekRoleplayContext db, Player player)
        {
            var foundPlayer = db.Players.FirstOrDefault(p => p.Name == player.Name);

            if(foundPlayer != null)
            {
                foundPlayer.X = player.X;
                foundPlayer.Y = player.Y;
                foundPlayer.Z = player.Z;
                foundPlayer.A = player.A;
            }
        }
    }
}
