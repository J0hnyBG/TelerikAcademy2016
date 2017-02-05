namespace _02_Todo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id);

            this.CreateTable(
                "dbo.Todoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 1000),
                        Body = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            this.DropTable("dbo.Todoes");
            this.DropTable("dbo.Categories");
        }
    }
}
