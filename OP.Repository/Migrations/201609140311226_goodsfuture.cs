namespace OP.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class goodsfuture : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.GoodsFutures",
            //    c => new
            //        {
            //            GoodsFuturesID = c.Guid(nullable: false),
            //            GoodsPurchaseID = c.Guid(nullable: false),
            //            Contract = c.String(),
            //            FundAccount = c.String(),
            //            Positions = c.String(),
            //            ContractNo = c.String(),
            //            BuyOpen = c.Decimal(precision: 18, scale: 2),
            //            SellClose = c.Decimal(precision: 18, scale: 2),
            //            SellOpen = c.Decimal(precision: 18, scale: 2),
            //            BuyClose = c.Decimal(precision: 18, scale: 2),
            //            PointCount = c.Decimal(precision: 18, scale: 2),
            //            Amount = c.Decimal(precision: 18, scale: 2),
            //            RecordTime = c.DateTime(),
            //            Noter = c.String(),
            //        })
            //    .PrimaryKey(t => t.GoodsFuturesID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GoodsFutures");
        }
    }
}
