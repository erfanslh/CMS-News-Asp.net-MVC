using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CMSNachrichtModel.Model;

namespace CMSNachrichtModel.Context
{
    public class DbNachrichtContext : DbContext
    {
        public DbSet<Author> authors { get; set; }
        public DbSet<NewsGroup> newsGroups { get; set; }
        public DbSet<News> newses { get; set; }
        public DbSet<Comment> comments { get; set; }
    }
}
