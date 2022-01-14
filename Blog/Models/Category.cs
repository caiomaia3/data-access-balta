using System.Collections.Generic;
using Blog.Interfaces;
using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[Category]")]
    public class Category : IHasId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        [Write(false)]
        public List<Post> Posts { get; set; }

        public Category() => Posts = new List<Post>();
    }
}