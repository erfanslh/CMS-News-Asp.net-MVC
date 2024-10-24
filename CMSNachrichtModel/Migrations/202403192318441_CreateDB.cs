namespace CMSNachrichtModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Author",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        Mobilenumber = c.String(nullable: false, maxLength: 15),
                        Password = c.String(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        BaseDescription = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.T_Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        NewsId = c.Int(nullable: false),
                        BaseDescription = c.String(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.T_News", t => t.NewsId, cascadeDelete: true)
                .Index(t => t.NewsId);
            
            CreateTable(
                "dbo.T_News",
                c => new
                    {
                        NewsId = c.Int(nullable: false, identity: true),
                        NewsTitle = c.String(nullable: false, maxLength: 35),
                        NewsDescription = c.String(nullable: false),
                        ImageName = c.String(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        See = c.Int(nullable: false),
                        Like = c.Int(nullable: false),
                        NewsGroupId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        BaseDescription = c.String(),
                    })
                .PrimaryKey(t => t.NewsId)
                .ForeignKey("dbo.T_Author", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.T_NewsGroup", t => t.NewsGroupId, cascadeDelete: true)
                .Index(t => t.NewsGroupId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.T_NewsGroup",
                c => new
                    {
                        NewsGroupId = c.Int(nullable: false),
                        NewsGroupTitle = c.String(nullable: false),
                        NewsGroupImage = c.String(nullable: false),
                        BaseDescription = c.String(),
                    })
                .PrimaryKey(t => t.NewsGroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_Comment", "NewsId", "dbo.T_News");
            DropForeignKey("dbo.T_News", "NewsGroupId", "dbo.T_NewsGroup");
            DropForeignKey("dbo.T_News", "AuthorId", "dbo.T_Author");
            DropIndex("dbo.T_News", new[] { "AuthorId" });
            DropIndex("dbo.T_News", new[] { "NewsGroupId" });
            DropIndex("dbo.T_Comment", new[] { "NewsId" });
            DropTable("dbo.T_NewsGroup");
            DropTable("dbo.T_News");
            DropTable("dbo.T_Comment");
            DropTable("dbo.T_Author");
        }
    }
}
