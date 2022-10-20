using DnDBook.Database;

namespace DnDBook.Models
{
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