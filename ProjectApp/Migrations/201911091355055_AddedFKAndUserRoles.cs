namespace ProjectApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedFKAndUserRoles : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Text", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Name", c => c.String(nullable: false));
            Sql("INSERT INTO AspNetRoles(Id,Name) VALUES(1,'ADMIN')");
            Sql("INSERT INTO AspNetRoles(Id,Name) VALUES(2,'EMPLOYEE')");
            Sql("INSERT INTO AspNetRoles(Id,Name) VALUES(3,'GUEST')");
        }

        public override void Down()
        {
            AlterColumn("dbo.Projects", "Name", c => c.String());
            AlterColumn("dbo.Comments", "Text", c => c.String());
        }
    }
}
