using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace StraussDA.BlogLib
{
    public class BlogDbContext: DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) :base(options)
        {

        }

        public DbSet<Post> Post { get; set; }
    }
}
