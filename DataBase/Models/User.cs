using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public ICollection<UserContent> UserContents { get; set; }
        public ICollection<UserFavoriteItem> UserFavoriteItems { get; set; }
    }
}
