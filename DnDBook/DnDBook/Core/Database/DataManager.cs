using DnDBook.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDBook.Core.Database
{
    public static class DataManager
    {
        public static async Task<T> GetAsync<T>(int id) where T : DBEntity
        {
            var db = new DatabaseContext();

            var value = await db.FindAsync<T>(id);

            await db.DisposeAsync();

            return value;
        }

        public static IEnumerable<T> GetCollection<T>() where T : DBEntity
        {
            var db = new DatabaseContext();

            var collection = db.Set<T>();

            db.Dispose();

            return collection;
        }

        public static async Task AddAsync<T>(T value) where T : DBEntity
        {
            using (var db = new DatabaseContext())
            {
                await db.AddAsync(value);
                await db.SaveChangesAsync();
            }
        }

        public static async Task RemoveAsync<T>(T value) where T : DBEntity
        {
            using (var db = new DatabaseContext())
            {
                db.Remove(value);
                await db.SaveChangesAsync();
            }
        }

        public static async Task UpdateAsync<T>(T value) where T : DBEntity
        {
            using (var db = new DatabaseContext())
            {
                db.Update(value);
                await db.SaveChangesAsync();
            }
        }

        public static Task<List<Character>> GetCharactersByUserAsync(int userID)
        {
            var dbContext = new DatabaseContext();

            var list = dbContext.Characters.Include("Spells").ToList();

            var characters = from character in list where character.OwnerID == userID select character;

            dbContext.DisposeAsync();

            return Task.FromResult(characters.ToList());
        }

        public static User TryAddUser(string name, string password, out string errorMessage)
        {
            var dbContext = new DatabaseContext();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
            {
                errorMessage = "Вы не ввели данные";
                return null;
            }

            if (dbContext.Users.Any(u => u.Name == name))
            {
                errorMessage = "Такой пользователь уже существует";
                return null;
            }

            var user = new User(name, password);

            dbContext.Users.Add(user);

            errorMessage = string.Empty;

            dbContext.SaveChanges();
            dbContext.Dispose();

            return user;
        }

        public static User TryValidateUserLogin(string name, string password, out string errorMessage)
        {
            User findedUser;

            using (var db = new DatabaseContext())
            {
                findedUser = db.Users.FirstOrDefault(u => u.Name == name);
            }

            if (findedUser is null)
            {
                errorMessage = "Такого пользователя не существует";
                return null;
            }

            if (findedUser.Password != password)
            {
                errorMessage = "Неверный пароль";
                return null;
            }

            errorMessage = string.Empty;

            return findedUser;
        }
    }
}