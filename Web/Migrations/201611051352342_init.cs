namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SessionID = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sessions", t => t.SessionID, cascadeDelete: false)
                .Index(t => t.SessionID);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FilmID = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Films", t => t.FilmID, cascadeDelete: false)
                .Index(t => t.FilmID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "SessionID", "dbo.Sessions");
            DropForeignKey("dbo.Sessions", "FilmID", "dbo.Films");
            DropIndex("dbo.Sessions", new[] { "FilmID" });
            DropIndex("dbo.Orders", new[] { "SessionID" });
            DropTable("dbo.Sessions");
            DropTable("dbo.Orders");
            DropTable("dbo.Films");
        }
    }
}
