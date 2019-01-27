using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BlogWebsite.Models;
using BlogWebsite.Data;
using Microsoft.AspNetCore.Identity;

namespace BlogWebsite.Data
{

        public class ApplicationDbContext : IdentityDbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
            {
            }

          }

    }
