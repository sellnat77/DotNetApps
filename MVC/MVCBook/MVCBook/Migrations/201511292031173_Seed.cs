namespace MVCBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Copyright", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "LastName", c => c.String());
            AlterColumn("dbo.Books", "Copyright", c => c.String());
            AlterColumn("dbo.Books", "Title", c => c.String());
        }
    }
}
