using System;
using Blog.Models;
using Blog.Repositories;
using Blog.Services;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True";
        static void Main(string[] args)
        {
            ConnectionService.GetInstance().connection.Open();

            ReadUser(1);
            ReadRoles();
            ReadTags();
            System.Console.WriteLine();
            // ReadUser();
            // CreateUser();
            // UpdateUser();
            DeleteUser();
            ReadUsers();
            // UpdateUser();

            ConnectionService.GetInstance().connection.Close();
        }

        public static void ReadUsers()
        {
            var repository = new Repository<User>();
            var items = repository.Read();
            foreach (var item in items) System.Console.WriteLine(item.Name);
        }
        public static void ReadUser(int id)
        {
            var repository = new Repository<User>();
            var item = repository.Read(id);
            Console.WriteLine(item.Name);
        }
        public static void CreateUser()
        {
            var user = new User()
            {
                Name = "Equipe Balta",
                Bio = "Equipe Balta",
                Email = "hello@balta.io",
                Image = "https://...",
                PasswordHash = "Hash",
                Slug = "equipe-balta"
            };
            var repository = new Repository<User>();
            repository.Create(user);
        }
        public static void ReadRoles()
        {
            var repository = new Repository<Role>();
            var items = repository.Read();
            foreach (var item in items) System.Console.WriteLine(item.Name);
        }
        public static void ReadTags()
        {
            var repository = new Repository<Tag>();
            var items = repository.Read();
            foreach (var item in items) System.Console.WriteLine(item.Name);
        }

        public static void UpdateUser()
        {
            var user = new User()
            {
                Id = 5,
                Name = "Equipe de suporte Balta",
                Bio = "Equipe | Balta",
                Email = "hello@balta.io",
                Image = "https://...",
                PasswordHash = "Hash",
                Slug = "equipe-balta"
            };
            var repository = new Repository<User>();
            repository.Update(user);
        }

        public static void DeleteUser()
        {
            var repository = new Repository<User>();
            repository.Delete(5);
            // System.Console.WriteLine("Deleção realizada com sucesso.");
        }
    }
}
