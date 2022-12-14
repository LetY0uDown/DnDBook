using System.ComponentModel.DataAnnotations.Schema;

namespace DnDBook.Models
{
    [Table(nameof(User))]
    public class User : DBEntity
    {
        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public string Name { get; set; }
        public string Password { get; set; }
    }
}