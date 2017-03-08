namespace OP.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Monitor20170302 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MonitorConditions", "MonitorID", c => c.Guid(nullable: false));
            DropColumn("dbo.MonitorConditions", "Editor");
            DropColumn("dbo.MonitorConditions", "EditTime");
            DropColumn("dbo.MonitorConditions", "Auditor");
            DropColumn("dbo.MonitorConditions", "AuditTime");
            DropColumn("dbo.MonitorConditions", "IsAudit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MonitorConditions", "IsAudit", c => c.Boolean(nullable: false));
            AddColumn("dbo.MonitorConditions", "AuditTime", c => c.DateTime());
            AddColumn("dbo.MonitorConditions", "Auditor", c => c.String());
            AddColumn("dbo.MonitorConditions", "EditTime", c => c.DateTime());
            AddColumn("dbo.MonitorConditions", "Editor", c => c.String());
            DropColumn("dbo.MonitorConditions", "MonitorID");
        }
    }
}
