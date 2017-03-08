namespace OP.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MonitorCondition_update : DbMigration
    {
        public override void Up()
        {

            AlterColumn("dbo.MonitorConditions", "MaxPrice", c => c.Int(nullable: true));
            AlterColumn("dbo.MonitorConditions", "MinPrice", c => c.Int(nullable: true));
            AlterColumn("dbo.MonitorConditions", "MaxPosition", c => c.Int(nullable: true));
            AlterColumn("dbo.MonitorConditions", "MinPosition", c => c.Int(nullable: true));
            AlterColumn("dbo.MonitorConditions", "MainPosition", c => c.Int(nullable: true));
            AlterColumn("dbo.MonitorConditions", "EditTime", c => c.DateTime(nullable:true));
            AlterColumn("dbo.MonitorConditions", "AuditTime", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MonitorConditions", "AuditTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MonitorConditions", "EditTime", c => c.DateTime(nullable: false));
        }
    }
}
