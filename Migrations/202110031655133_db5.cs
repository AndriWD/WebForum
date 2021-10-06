namespace WebForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Topics", "UserId", c => c.String());
            DropColumn("dbo.Topics", "AuthorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Topics", "AuthorId", c => c.String());
            DropColumn("dbo.Topics", "UserId");
        }
    }
}
