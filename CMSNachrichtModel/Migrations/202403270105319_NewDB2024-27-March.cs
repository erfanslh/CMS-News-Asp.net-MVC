namespace CMSNachrichtModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDB202427March : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.T_News", "NewsTitle", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.T_News", "NewsTitle", c => c.String(nullable: false, maxLength: 35));
        }
    }
}
