namespace OP.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170621Monitor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Monitors", "Account", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Monitors", "Account");
        }
    }
}
