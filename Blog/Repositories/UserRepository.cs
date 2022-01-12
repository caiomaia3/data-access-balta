using System.Collections.Generic;
using Blog.Models;
using Blog.Services;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository
    {
        public SqlConnection _connection;
        public UserRepository() => _connection = ConnectionService.GetInstance().connection;
        public IEnumerable<User> Get() => _connection.GetAll<User>();
        public User Get(int id) => _connection.Get<User>(id);
        public void Create(User user) => _connection.Insert<User>(user);
    }
}