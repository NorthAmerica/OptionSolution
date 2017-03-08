namespace OP.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Monitor201703022 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Monitors",
                c => new
                    {
                        MonitorID = c.Guid(nullable: false),
                        MonitorName = c.String(),
                        Contract = c.String(),
                        MonitorDate = c.DateTime(nullable: false),
                        Editor = c.String(),
                        EditTime = c.DateTime(nullable: true),
                        Auditor = c.String(),
                        AuditTime = c.DateTime(nullable:true),
                        IsAudit = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MonitorID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Monitors");
        }
    }
}
