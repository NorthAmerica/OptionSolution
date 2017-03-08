namespace OP.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MonitorCondition : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MonitorConditions",
                c => new
                    {
                        MonitorConditionID = c.Guid(nullable: false),
                        Contract = c.String(),
                        MonitorDate = c.DateTime(nullable: false),
                        MainPosition = c.Int(nullable: false),
                        MinPosition = c.Int(nullable: false),
                        MaxPosition = c.Int(nullable: false),
                        MinPrice = c.Int(nullable: false),
                        MaxPrice = c.Int(nullable: false),
                        Editor = c.String(),
                        EditTime = c.DateTime(nullable: false),
                        Auditor = c.String(),
                        AuditTime = c.DateTime(nullable: false),
                        IsAudit = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MonitorConditionID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MonitorConditions");
        }
    }
}
