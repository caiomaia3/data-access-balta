using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Blog.Services;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository() : base() { }
        public List<User> ReadWithRoles()
        {
            const string query = @"
            SELECT
                *
            FROM
                [User]
            LEFT JOIN 
                [UserRole] 
                    ON [User].[Id] = [UserRole].[UserId]
            LEFT JOIN 
                [Role]
                ON [UserRole].[RoleId] = [Role].[Id]";

            var users = new List<User>();

            var myList = base._connection.Query<User, Role, User>
            (
                query,
                (user, role) =>
                    {
                        User usr = users.Find(x => x.Id == user.Id);
                        if (usr == null)
                        {
                            usr = user;
                            if (role != null) usr.Roles.Add(role);
                            users.Add(usr);
                        }
                        else
                        {
                            if (role != null) usr.Roles.Add(role);
                        }
                        return user;
                    },
                splitOn: "Id"
            );
            return users;
        }
    }
}