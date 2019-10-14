using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GuitarTabsAndChords.Model.Requests
{
    public class UsersUpdateRequest
    {
        public DateTime DateOfBirth { get; set; }
        public byte[] ProfilePicture { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z0-9_]+", ErrorMessage = "Username may only contain letters, numbers and underscores.")]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
