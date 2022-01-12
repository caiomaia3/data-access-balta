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
            Console.WriteLine("Hello World!");
            ReadUsers();
            // ReadUser();
            // CreateUser();
            // UpdateUser();
            // DeleteUser();
        }

        public static void ReadUsers()
        {
            var repository = new UserRepository();
            // var repository2 = new UserRepository();
            // System.Console.WriteLine(repository._connection == repository2._connection);
            var users = repository.Get();
            foreach (var user in users) System.Console.WriteLine(user.Name);
        }

        public static void ReadUser()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(1);
                System.Console.WriteLine(user.Name);
            }

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
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Insert<User>(user);
                System.Console.WriteLine("Cadastro realizado com sucesso.");
            }

        }


        public static void UpdateUser()
        {
            var user = new User()
            {
                Id = 3,
                Name = "Equipe de suporte Balta",
                Bio = "Equipe | Balta",
                Email = "hello@balta.io",
                Image = "https://...",
                PasswordHash = "Hash",
                Slug = "equipe-balta"
            };
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Update<User>(user);
                System.Console.WriteLine("Cadastro realizado com sucesso.");
            }

        }

        public static void DeleteUser()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(3);
                connection.Delete<User>(user);
                System.Console.WriteLine("Deleção realizada com sucesso.");
            }
        }
    }
}
