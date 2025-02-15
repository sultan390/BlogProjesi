using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Match = EntityLayer.Concrete.Match;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=BlogProjesi;uid=sa;password=Asd123asd.;trusted_connection=false;TrustServerCertificate=true");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasOne(x => x.HomeTeam)
                .WithMany(y => y.HomeMatches)
                .HasForeignKey(z => z.HomeTeamID)
                .OnDelete(DeleteBehavior.ClientSetNull);



            modelBuilder.Entity<Match>()
                .HasOne(x => x.GuestTeam)
                .WithMany(y => y.AwayMatches)
                .HasForeignKey(z => z.GuestTeamID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message2>()
               .HasOne(x => x.SenderUser)
               .WithMany(y => y.WriterSender)
               .HasForeignKey(z => z.SenderID)
               .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<Message2>()
              .HasOne(x => x.ReceiverUser)
              .WithMany(y => y.WriterReceiver)
              .HasForeignKey(z => z.ReceiverID)
              .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);

            // HomeMatches > WriterSender
            // AwayMatches > WriterReceiver 
            // HomeTeam > SenderUser
            // GuestTeam > ReceiverUser 
        }



        //  server =ServerName;database=CoreBlogDb; integrated security = true; TrustServerCertificate=true;
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<BlogRayting> BlogRaytings { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Message2> Message2s { get; set; }
        public DbSet<Admin> Admins { get; set; }







        // username=sa; password=Asd123asd. 

        // optionsBuilder.UseSqlServer("server=localhost;database=CoreBlogDb;trusted_connection=false;uid=sa;password=Asd123asd.");
        //  server yerine localhost
        //  database yerine kendi db ni ve uid yerine sa password yerine de Asd123asd.

        // eski kod bağlantısı
        // optionsBuilder.UseSqlServer("server=localhost;database=CoreBlogDb; integrated security=true; TrustServerCertificate=true");

    }

}
