namespace WebForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropColumn("dbo.Posts", "UserId");
            RenameColumn(table: "dbo.Posts", name: "User_Id", newName: "UserId");
            AddColumn("dbo.Posts", "TimeOfCreateOrLastUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Topics", "TimeOfCreateOrLastUpdate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Posts", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Topics", "AuthorId", c => c.String());
            CreateIndex("dbo.Posts", "UserId");
            DropColumn("dbo.Posts", "TimeCreatePost");
            DropColumn("dbo.Topics", "TimeCreateTopic");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Topics", "TimeCreateTopic", c => c.DateTime(nullable: false));
            AddColumn("dbo.Posts", "TimeCreatePost", c => c.DateTime(nullable: false));
            DropIndex("dbo.Posts", new[] { "UserId" });
            AlterColumn("dbo.Topics", "AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Topics", "TimeOfCreateOrLastUpdate");
            DropColumn("dbo.Posts", "TimeOfCreateOrLastUpdate");
            RenameColumn(table: "dbo.Posts", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Posts", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "User_Id");
        }
    }
}
