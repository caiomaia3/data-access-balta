using System.Collections.Generic;
using Blog.Interfaces;
using Blog.Models;
using Blog.Services;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class Repository<TModel> where TModel : class, IHasId
    {
        public Repository() => _connection = ConnectionService.GetInstance().connection;

        public readonly SqlConnection _connection;

        public void Create(TModel model)
        {
            model.Id = 0;
            _connection.Insert<TModel>(model);
        }
        public TModel Read(int id) => _connection.Get<TModel>(id);
        public IEnumerable<TModel> Read() => _connection.GetAll<TModel>();
        public void Update(TModel model)
        {
            if (model.Id != 0) _connection.Update<TModel>(model);
        }
        public void Delete(TModel model)
        {
            if (model.Id != 0) _connection.Delete<TModel>(model);
        }
        public void Delete(int id)
        {
            if (id == 0) return;
            var model = _connection.Get<TModel>(id);
            _connection.Delete<TModel>(model);
        }
    }
}