namespace myProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompaniesBranches",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        CompanyId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Kind = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompaniesBranches", "CompanyId", "dbo.Companies");
            DropIndex("dbo.CompaniesBranches", new[] { "CompanyId" });
            DropTable("dbo.Companies");
            DropTable("dbo.CompaniesBranches");
        }
    }
}
