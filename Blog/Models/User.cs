using System;
using System.Collections.Generic;
using Blog.Interfaces;
using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[User]")]
    public class User : IHasId
    {
        public User() => Roles = new List<Role>();

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
        [Write(false)]
        public List<Role> Roles { get; set; }

        public static explicit operator List<object>(User v)
        {
            throw new NotImplementedException();
        }
    }
}