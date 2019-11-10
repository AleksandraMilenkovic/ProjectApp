namespace ProjectApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminEnd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Comments", new[] { "ProjectId" });
            AddColumn("dbo.Comments", "Project_Id", c => c.Int());
            AddColumn("dbo.Projects", "Comments_Id", c => c.Int());
            CreateIndex("dbo.Comments", "Project_Id");
            CreateIndex("dbo.Projects", "Comments_Id");
            AddForeignKey("dbo.Projects", "Comments_Id", "dbo.Comments", "Id");
            AddForeignKey("dbo.Comments", "Project_Id", "dbo.Projects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Projects", "Comments_Id", "dbo.Comments");
            DropIndex("dbo.Projects", new[] { "Comments_Id" });
            DropIndex("dbo.Comments", new[] { "Project_Id" });
            DropColumn("dbo.Projects", "Comments_Id");
            DropColumn("dbo.Comments", "Project_Id");
            CreateIndex("dbo.Comments", "ProjectId");
            AddForeignKey("dbo.Comments", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
    }
}
