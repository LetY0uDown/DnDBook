using DnDBook.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDBook.Database
{
    public static class DataManager
    {
        public static IDataCollection<Character> Characters { get; } = new DataCollection<Character>();

        public static IDataCollection<Spell> Spells { get; } = new DataCollection<Spell>();

        public static IDataCollection<User> Users { get; } = new DataCollection<User>();
                
        public static Task<List<Character>> GetCharactersByUserAsync(int userID)
        {
            var charactersList = Characters.Values;
            var characters = from character in charactersList where character.OwnerID == userID select character;

            return Task.FromResult(characters.ToList());
        }

        public static User TryAddUser(string name, string password, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
            {
                errorMessage = "Вы не ввели данные";
                return null;
            }

            if (Users.Values.Exists(u => u.Name == name))
            {
                errorMessage = "Такой пользователь уже существует";
                return null;
            }

            var user = new User(name, password);

            Users.AddAsync(user);

            errorMessage = string.Empty;

            return user;
        }

        public static User TryValidateUserLogin(string name, string password, out string errorMessage)
        {
            var users = Users.Values;

            var user = users.Find(u => u.Name == name);

            if (user is null)
            {
                errorMessage = "Такого пользователя не существует";
                return null;
            }

            if (user.Password != password)
            {
                errorMessage = "Неверный пароль";
                return null;
            }

            errorMessage = string.Empty;

            return user;
        }        
    }
}