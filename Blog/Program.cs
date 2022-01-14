﻿using System;
using Blog.Models;
using Blog.Repositories;
using Blog.Services;
using Blog.Views;

//TODO DESAFIO
//[x] Cadastrar um usuário
//[ ] Cadastrar um perfil
//[ ] Vincular um usuário a um perfil 
//[ ] Cadastrar uma categoria
//[ ] Cadastrar uma tag
//[ ] Cadastrar um post
//[ ] Vincular um post a uma tag
//[ ] Listar os usuários (Nome, Email e perfis separados por vírgula)
//[ ] Listar categorias com quantidades de posts
//[ ] Listar tags com quantidades de posts
//[ ] Listar os posts de uma categoria
//[ ] Listar todos os posts com sua categoria
//[ ] Listar os posts com suas tags (separadas por vírgula)

namespace Blog
{
    public static class Program
    {
        private static void Main()
        {
            Menu.Show();

            // ConnectionService.GetInstance().Connection.Open();
            // var cat = new Category();
            // cat.Posts.Add(new Post());
            // System.Console.WriteLine("Hello!");
            // /*
            // ReadUser(1);
            // ReadRoles();
            // ReadTags();
            // System.Console.WriteLine();
            // ReadUser();
            // CreateUser();
            // UpdateUser();
            // DeleteUser();
            // ReadUsers();
            // UpdateUser();
            // */

            ConnectionService.GetInstance().Connection.Close();
        }

        public static void ReadUsers()
        {
            var repository = new UserRepository();
            var items = repository.ReadWithRoles();
            foreach (var item in items)
            {
                System.Console.WriteLine(item.Name);
                foreach (Role role in item.Roles) System.Console.WriteLine($"- {role.Name}");
            }
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
