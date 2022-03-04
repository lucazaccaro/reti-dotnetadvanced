using System;
using System.Collections.Generic;

namespace NET6.EF.ReverseEngineering
{
    public partial class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int BlogId { get; set; }
        public int? AuthorId { get; set; }

        public virtual Author? Author { get; set; }
        public virtual Blog Blog { get; set; } = null!;
    }
}
