namespace ProjectApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "UserId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "UserId", c => c.Int(nullable: false));
        }
    }
}
