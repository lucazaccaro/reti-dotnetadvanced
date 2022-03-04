using System;
using System.Collections.Generic;

namespace NET6.EF.ReverseEngineering
{
    public partial class Author
    {
        public Author()
        {
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
