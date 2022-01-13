using System.Collections.Generic;
using Blog.Models;
using Blog.Services;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository
    {
        public UserRepository() => _connection = ConnectionService.GetInstance().Connection;

        public readonly SqlConnection _connection;

        public void Create(User user)
        {
            user.Id = 0;
            _connection.Insert<User>(user);
        }
        public User Read(int id) => _connection.Get<User>(id);
        public IEnumerable<User> Read() => _connection.GetAll<User>();
        public void Update(User user)
        {
            if (user.Id != 0) _connection.Update<User>(user);
        }
        public void Delete(int id)
        {
            if (id == 0) return;
            var user = _connection.Get<User>(id);
            _connection.Delete<User>(user);
        }
    }
}