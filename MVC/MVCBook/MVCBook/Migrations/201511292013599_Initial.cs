namespace MVCBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "EditionNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "EditionNumber", c => c.String());
        }
    }
}
