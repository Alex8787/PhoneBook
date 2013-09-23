namespace PhoneBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abonent",
                c => new
                    {
                        AbonentId = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AbonentId);
            
            CreateTable(
                "dbo.Number",
                c => new
                    {
                        NumberId = c.Int(nullable: false, identity: true),
                        Phone = c.String(nullable: false, maxLength: 10),
                        AbonentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NumberId)
                .ForeignKey("dbo.Abonent", t => t.AbonentId, cascadeDelete: true)
                .Index(t => t.AbonentId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Number", new[] { "AbonentId" });
            DropForeignKey("dbo.Number", "AbonentId", "dbo.Abonent");
            DropTable("dbo.Number");
            DropTable("dbo.Abonent");
        }
    }
}
