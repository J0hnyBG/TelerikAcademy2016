namespace WebArchive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                        "dbo.Files",
                        c => new
                             {
                                 Id = c.Int(nullable: false, identity: true),
                                 Content = c.String(nullable: false),
                                 FileName = c.String(nullable: false),
                                 ArchiveName = c.String(nullable: false),
                             })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Files");
        }
    }
}
