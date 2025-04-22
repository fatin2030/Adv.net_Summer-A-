namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INITV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200, unicode: false),
                        Content = c.String(nullable: false, maxLength: 8000, unicode: false),
                        AuthorId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.BookMarks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ArticleId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        UserName = c.String(nullable: false, maxLength: 10, unicode: false),
                        Email = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Password = c.String(nullable: false, maxLength: 100, unicode: false),
                        Role = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Status = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArticleTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        ArticleTag_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArticleTags", t => t.ArticleTag_Id)
                .Index(t => t.ArticleTag_Id);
            
            CreateTable(
                "dbo.TrendingMetrics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        Views = c.Int(nullable: false),
                        Likes = c.Int(nullable: false),
                        Shares = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
            CreateTable(
                "dbo.BookMarkArticles",
                c => new
                    {
                        BookMarkId = c.Int(nullable: false),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookMarkId, t.ArticleId })
                .ForeignKey("dbo.BookMarks", t => t.BookMarkId, cascadeDelete: true)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.BookMarkId)
                .Index(t => t.ArticleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrendingMetrics", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Tags", "ArticleTag_Id", "dbo.ArticleTags");
            DropForeignKey("dbo.ArticleTags", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Articles", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.Articles", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.BookMarks", "UserId", "dbo.Users");
            DropForeignKey("dbo.BookMarkArticles", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.BookMarkArticles", "BookMarkId", "dbo.BookMarks");
            DropIndex("dbo.BookMarkArticles", new[] { "ArticleId" });
            DropIndex("dbo.BookMarkArticles", new[] { "BookMarkId" });
            DropIndex("dbo.TrendingMetrics", new[] { "ArticleId" });
            DropIndex("dbo.Tags", new[] { "ArticleTag_Id" });
            DropIndex("dbo.ArticleTags", new[] { "ArticleId" });
            DropIndex("dbo.BookMarks", new[] { "UserId" });
            DropIndex("dbo.Articles", new[] { "CategoryId" });
            DropIndex("dbo.Articles", new[] { "AuthorId" });
            DropTable("dbo.BookMarkArticles");
            DropTable("dbo.TrendingMetrics");
            DropTable("dbo.Tags");
            DropTable("dbo.ArticleTags");
            DropTable("dbo.Categories");
            DropTable("dbo.Users");
            DropTable("dbo.BookMarks");
            DropTable("dbo.Articles");
        }
    }
}
