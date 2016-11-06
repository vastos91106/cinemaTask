namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixStartingDateMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sessions", "StartingDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sessions", "StartingDate");
        }
    }
}
