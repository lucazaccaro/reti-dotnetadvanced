using System;
using System.Collections.Generic;

namespace NET6.EF.ReverseEngineering
{
    public partial class Blog
    {
        public Blog()
        {
            Posts = new HashSet<Post>();
        }

        public int BlogId { get; set; }
        public string Url { get; set; } = null!;

        public virtual ICollection<Post> Posts { get; set; }
    }
}
