using System.Data.Entity;
using OP.Entities.Models;
using OP.Repository.Migrations;

namespace OP.Repository
{
    /// <summary>
    /// 数据上下文
    /// </summary>
    public class EFDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<FuturesFund> FuturesFunds { get; set; }
        public DbSet<FuturesTradeVolume> FuturesTradeVolumes { get; set; }
        public DbSet<FallRole> FallRoles { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<RiseRole> RiseRoles { get; set; }
        public DbSet<OptionsProduct> OptionsProducts { get; set; }
        public DbSet<NumberType> NumberTypes { get; set; }
        public DbSet<OptionType> OptionTypes { get; set; }
        public DbSet<PartType> PartTypes { get; set; }
        public DbSet<OptionTrade> OptionTrades { get; set; }
        public DbSet<OptionTradeSum> OptionTradeSums { get; set; }
        public DbSet<FundStatus> FundStatus { get; set; }
        public DbSet<ManageStatus> ManageStatus { get; set; }
        public DbSet<EventLog> EventLogs { get; set; }
        public DbSet<FuturePrice> FuturePrices { get; set; }
        public DbSet<Tday> Tdays { get; set; }
        public DbSet<CallPriceType> CallPriceTypes { get; set; }
        public DbSet<TradeOrder> TradeOrders { get; set; }
        public DbSet<ONOFFSet> ONOFFSets { get; set; }
        public DbSet<ONTime> ONTimes { get; set; }
        public DbSet<GuestBook> GuestBooks { get; set; }
        public DbSet<Brochure> Brochures { get; set; }
        public DbSet<GoodsMarketing> GoodsMarketings { get; set; }
        public DbSet<GoodsPurchase> GoodsPurchases { get; set; }
        public DbSet<GoodsFuture> GoodsFutures { get; set; }
        public DbSet<GoodsPayment> GoodsPayments { get; set; }
        public DbSet<GoodsProfit> GoodsProfits { get; set; }
        public DbSet<RoleAction> RoleActions { get; set; }
        public DbSet<MenuAction> MenuActions { get; set; }
        public EFDbContext()
            : base("name=EFDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFDbContext, Configuration>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EFDbContext>());

        }
        //自定义RiseCompensate小数点长度
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<OptionTrade>().Property(c => c.RiseCompensate).HasPrecision(20,3);
        //}
    }
}
