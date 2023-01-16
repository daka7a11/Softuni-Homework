﻿using BattleCards.Data;
using BattleCards.Models;
using System.Linq;

namespace BattleCards.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(string username, string email, string password)
        {
            User user = new User()
            {
                Username = username,
                Email = email,
                Password = Hash(password),
            };
            db.Users.Add(user);
            db.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            var user = db.Users.FirstOrDefault(x => x.Username == username);
            if (user?.Password != Hash(password))
            {
                return null;
            }

            return user.Id;
        }

        public bool IsUsernameValid(string username)
        {
            return !db.Users.Any(x => x.Username == username);
        }

        public bool IsEmailValid(string email)
        {
            return !db.Users.Any(x => x.Email == email);
        }

        private static string Hash(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }
    }
}