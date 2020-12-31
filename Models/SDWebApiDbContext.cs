using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SharpDevelopWebApi.Models
{
    public class SDWebApiDbContext : DbContext
    {
        public SDWebApiDbContext() : base("diaryDb") // name_of_dbconnection_string
        {
        }
        public DbSet<UserAccount> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Diary> Diaries { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Song> Songs { get; set; }
    }


}

