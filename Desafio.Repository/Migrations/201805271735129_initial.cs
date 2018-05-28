namespace Desafio.Repository.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adopter",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        AddressLine = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        AnimalType = c.String(nullable: false),
                        Weight = c.Single(nullable: false),
                        Age = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        AdoptedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Adopter", t => t.AdoptedBy)
                .Index(t => t.AdoptedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "AdoptedBy", "dbo.Adopter");
            DropIndex("dbo.Animals", new[] { "AdoptedBy" });
            DropTable("dbo.Animals");
            DropTable("dbo.Adopter");
        }
    }
}
