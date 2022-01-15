using System;
using System.Collections.Generic;
using Blog.Models;

namespace Blog.Views
{
    public static class LinkingView
    {
        public static void Show()
        {

        }

        internal static void UserRole()
        {
            //[x] Vincular um usuário a um perfil 
            UserRole userRole;
            do
            {
                List<ConsoleCursor> cursors = ShareView.ShowScreen(WriteOptions);
                userRole = GetForm(cursors);
            } while (ShareView.ConfirmationScreen(ShareView.WriteConfirmationScreen));
            ShareView.SendToRepository(userRole);
            LinkSelectionView.Show();

            static List<ConsoleCursor> WriteOptions()
            {
                const int INITIAL_LINE = 1, INITIAL_COLUMN = 3;
                int lineCursor = INITIAL_LINE;
                var cursor = new ConsoleCursor(1, lineCursor++);
                var cursors = new List<ConsoleCursor>();

                cursor = ShareView.WriteFormField("CRIAÇÃO DE RELAÇÃO", cursor);
                lineCursor += 2;
                cursor.Set(INITIAL_COLUMN, lineCursor++);
                cursor = ShareView.WriteFormField("UserId:", cursor);
                cursors.Add(cursor);
                cursor.Set(INITIAL_COLUMN, lineCursor++);
                cursor = ShareView.WriteFormField("RoleId:", cursor);
                cursors.Add(cursor);
                return cursors;
            }

            static UserRole GetForm(List<ConsoleCursor> cursors)
            {
                const int FIRST_ELEMENT = 0;
                int userId, roleId;

                Console.SetCursorPosition(cursors[FIRST_ELEMENT].Left, cursors[FIRST_ELEMENT].Top);
                userId = int.Parse(Console.ReadLine());
                cursors.RemoveAt(FIRST_ELEMENT);

                Console.SetCursorPosition(cursors[FIRST_ELEMENT].Left, cursors[FIRST_ELEMENT].Top);
                roleId = int.Parse(Console.ReadLine());
                cursors.RemoveAt(FIRST_ELEMENT);

                return new UserRole
                {
                    UserId = userId,
                    RoleId = roleId
                };
            }

        }

        internal static void PostTag()
        {
            //[ ] Vincular um post a uma tag
            PostTag postTag;
            do
            {
                List<ConsoleCursor> cursors = ShareView.ShowScreen(WriteOptions);
                postTag = GetForm(cursors);
            } while (ShareView.ConfirmationScreen(ShareView.WriteConfirmationScreen));
            ShareView.SendToRepository(postTag);
            LinkSelectionView.Show();

            static List<ConsoleCursor> WriteOptions()
            {
                const int INITIAL_LINE = 1, INITIAL_COLUMN = 3;
                int lineCursor = INITIAL_LINE;
                var cursor = new ConsoleCursor(1, lineCursor++);
                var cursors = new List<ConsoleCursor>();

                cursor = ShareView.WriteFormField("CRIAÇÃO DE RELAÇÃO", cursor);
                lineCursor += 2;
                cursor.Set(INITIAL_COLUMN, lineCursor++);
                cursor = ShareView.WriteFormField("UserId:", cursor);
                cursors.Add(cursor);
                cursor.Set(INITIAL_COLUMN, lineCursor++);
                cursor = ShareView.WriteFormField("RoleId:", cursor);
                cursors.Add(cursor);
                return cursors;
            }

            static PostTag GetForm(List<ConsoleCursor> cursors)
            {
                const int FIRST_ELEMENT = 0;
                int postId, tagId;

                Console.SetCursorPosition(cursors[FIRST_ELEMENT].Left, cursors[FIRST_ELEMENT].Top);
                postId = int.Parse(Console.ReadLine());
                cursors.RemoveAt(FIRST_ELEMENT);

                Console.SetCursorPosition(cursors[FIRST_ELEMENT].Left, cursors[FIRST_ELEMENT].Top);
                tagId = int.Parse(Console.ReadLine());
                cursors.RemoveAt(FIRST_ELEMENT);

                return new PostTag
                {
                    PostId = postId,
                    TagId = tagId
                };
            }
        }
    }
}