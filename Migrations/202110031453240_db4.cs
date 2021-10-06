namespace WebForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "Topic_Id", "dbo.Topics");
            DropIndex("dbo.Posts", new[] { "Topic_Id" });
            RenameColumn(table: "dbo.Posts", name: "Topic_Id", newName: "TopicId");
            AlterColumn("dbo.Posts", "TopicId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "TopicId");
            AddForeignKey("dbo.Posts", "TopicId", "dbo.Topics", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "TopicId", "dbo.Topics");
            DropIndex("dbo.Posts", new[] { "TopicId" });
            AlterColumn("dbo.Posts", "TopicId", c => c.Int());
            RenameColumn(table: "dbo.Posts", name: "TopicId", newName: "Topic_Id");
            CreateIndex("dbo.Posts", "Topic_Id");
            AddForeignKey("dbo.Posts", "Topic_Id", "dbo.Topics", "Id");
        }
    }
}
