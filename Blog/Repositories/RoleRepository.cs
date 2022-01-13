using System.Collections.Generic;
using Blog.Models;
using Blog.Services;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class RoleRepository
    {
        public RoleRepository() => _connection = ConnectionService.GetInstance().connection;

        public readonly SqlConnection _connection;

        public void Create(Role role)
        {
            role.Id = 0;
            _connection.Insert<Role>(role);
        }
        public Role Read(int id) => _connection.Get<Role>(id);
        public IEnumerable<Role> Read() => _connection.GetAll<Role>();
        public void Update(Role role)
        {
            if (role.Id != 0) _connection.Update<Role>(role);
        }
        public void Delete(int id)
        {
            if (id == 0) return;
            var role = _connection.Get<Role>(id);
            _connection.Delete<Role>(role);
        }
    }
}