using Blog.Interfaces;
using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[PostTag]")]
    public class PostTag : IHasId
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int TagId { get; set; }
    }
}