using System.ComponentModel.DataAnnotations;
using System.Numerics;

/*
 C:\Users\Davis\source\repos\SilentCreekRoleplay\ClassLibrary1>dotnet ef migrations add InitialCreate --startup-project ../SilentCreekRoleplay/
*/
namespace SilentCreekRoleplay.DataLayer.Entities
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 6)]
        public string Password { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }
    }
}
