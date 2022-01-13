using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[Post]")]
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string Slug { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public Category Category { get; set; }
    }
}