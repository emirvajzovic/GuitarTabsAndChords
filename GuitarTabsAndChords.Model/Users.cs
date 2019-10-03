using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarTabsAndChords.Model
{
    public class Users
    {
        public int Id { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NameLastname { get => Name + " " + LastName; }
        public DateTime? BannedUntil { get; set; }
        public int RoleId { get; set; }
        public Roles Role { get; set; }

        public override string ToString()
        {
            return NameLastname;
        }
    }
}
