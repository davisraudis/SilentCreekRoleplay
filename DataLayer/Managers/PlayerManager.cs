using SilentCreekRoleplay.DataLayer.Entities;
using System.Linq;


namespace SilentCreekRoleplay.DataLayer.Managers
{
    public class PlayerManager
    {
        public Player GetPlayerEntityByPlayerName(SilentCreekRoleplayContext db, string playerName)
        {
            var databasePlayer = db.Players.FirstOrDefault(p => p.Name == playerName);
            return databasePlayer;
        }

        public void RegisterPlayer(SilentCreekRoleplayContext db, string name, string password)
        {
            var player = new Player
            {
                Name = name,
                Password = Utils.CreateMD5(password)
            };

            db.Players.Add(player);
        }
    }
}
