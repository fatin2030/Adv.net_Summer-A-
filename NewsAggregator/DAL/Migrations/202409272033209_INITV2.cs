namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INITV2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookMarks", "ArticleId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BookMarks", "ArticleId", c => c.Int());
        }
    }
}
