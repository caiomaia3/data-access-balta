using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Views
{
    internal class ListingView
    {

        internal static void Users()
        {
            //[x] Listar os usuários (Nome, Email e perfis separados por vírgula)
            // do
            // {
            ShareView.ShowScreen(WritePage);

            Console.ReadKey();
            ListingSelectionView.Show();

            static void WritePage()
            {
                var repository = new UserRepository();
                List<User> users = repository.ReadWithRoles();

                const int INITIAL_LINE = 1, INITIAL_COLUMN = 2;
                string stringLine = "";
                int lineCursor = INITIAL_LINE;
                var cursor = new ConsoleCursor(1, lineCursor++);

                cursor = ShareView.WriteFormField("RESULTADO", cursor); lineCursor += 2;
                foreach (User user in users)
                {
                    cursor.Set(INITIAL_COLUMN, lineCursor++);
                    stringLine = $" {user.Name}, {user.Email} [";
                    foreach (Role role in user.Roles)
                    {
                        stringLine += $"{role.Name}";
                    }
                    stringLine += "]";
                    ShareView.WriteFormField(stringLine, cursor);
                }
            }
        }

        internal static void Categories()
        {
            //[ ] Listar categorias com quantidades de posts
            throw new NotImplementedException();
        }

        internal static void TagsWithPostCount()
        {
            //[ ] Listar tags com quantidades de posts
            throw new NotImplementedException();
        }

        internal static void PostsByCategory()
        {
            //[ ] Listar os posts de uma categoria
            throw new NotImplementedException();
        }

        internal static void AllPostsWithCategories()
        {
            //[ ] Listar todos os posts com sua categoria
            throw new NotImplementedException();
        }

        internal static void AllPostsWithTags()
        {
            //[ ] Listar os posts com suas tags (separadas por vírgula)
            throw new NotImplementedException();
        }
    }
}