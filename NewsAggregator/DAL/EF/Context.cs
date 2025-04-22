using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TrendingMetric> TrendingMetrics { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookMark> BookMarks { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
        public DbSet<Article> Articles { get; set; }

       protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure the foreign key relationship for BookMarks

            //why error here?
            modelBuilder.Entity<BookMark>()
                .HasRequired(b => b.User)
                .WithMany(u => u.BookMarks)
                .HasForeignKey(b => b.UserId)
                .WillCascadeOnDelete(false);

            // Configure many-to-many relationship between BookMark and Article
            modelBuilder.Entity<BookMark>()
                .HasMany(b => b.Articles)
                .WithMany(a => a.BookMarks)
                .Map(m =>
                {
                    m.ToTable("BookMarkArticles");
                    m.MapLeftKey("BookMarkId");
                    m.MapRightKey("ArticleId");
                });

            base.OnModelCreating(modelBuilder);
        }



    }
}
