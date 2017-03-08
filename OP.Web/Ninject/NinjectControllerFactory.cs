using System;
using Ninject;
using System.Web.Mvc;
using System.Web.Routing;
using OP.Repository;
using OP.Repository.Implementations;

namespace OP.Web.Ninject
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext
            requestContext, Type controllerType)
        {

            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<InterfaceUserRepository>().To<UserRepository>();
            ninjectKernel.Bind<InterfaceMenuRepository>().To<MenuRepository>();
            ninjectKernel.Bind<InterfaceRoleMenuRepository>().To<RoleMenuRepository>();
            ninjectKernel.Bind<InterfaceRoleRepository>().To<RoleRepository>();
            ninjectKernel.Bind<InterfaceUserRoleRepository>().To<UserRoleRepository>();
            ninjectKernel.Bind<InterfaceFuturesFundRepository>().To<FuturesFundRepository>();
            ninjectKernel.Bind<InterfaceFuturesTradeVolumeRepository>().To<FuturesTradeVolumeRepository>();
            ninjectKernel.Bind<InterfaceFuturePriceRepository>().To<FuturePriceRepository>();
            ninjectKernel.Bind<InterfaceFallRoleRepository>().To<FallRoleRepository>();
            ninjectKernel.Bind<InterfaceOptionsProductRepository>().To<OptionsProductRepository>();
            ninjectKernel.Bind<InterfacePartnerRepository>().To<PartnerRepository>();
            ninjectKernel.Bind<InterfaceRiseRoleRepository>().To<RiseRoleRepository>();
            ninjectKernel.Bind<InterfaceNumberTypeRepository>().To<NumberTypeRepository>();
            ninjectKernel.Bind<InterfaceOptionTypeRepository>().To<OptionTypeRepository>();
            ninjectKernel.Bind<InterfacePartTypeRepository>().To<PartTypeRepository>();
            ninjectKernel.Bind<InterfaceOptionTradeRepository>().To<OptionTradeRepository>();
            ninjectKernel.Bind<InterfaceOptionTradeSumRepository>().To<OptionTradeSumRepository>();
            ninjectKernel.Bind<InterfaceFundStatusRepository>().To<FundStatusRepository>();
            ninjectKernel.Bind<InterfaceManageStatusRepository>().To<ManageStatusRepository>();
            ninjectKernel.Bind<InterfaceEventLogRepository>().To<EventLogRepository>();
            ninjectKernel.Bind<InterfaceTdaysRepository>().To<TdaysRepository>();
            ninjectKernel.Bind<InterfaceCallPriceTypeRepository>().To<CallPriceTypeRepository>();
            ninjectKernel.Bind<InterfaceONOFFSetRepository>().To<ONOFFSetRepository>();
            ninjectKernel.Bind<InterfaceONTimeRepository>().To<ONTimeRepository>();
            ninjectKernel.Bind<InterfaceBrochureRepository>().To<BrochureRepository>();
            ninjectKernel.Bind<InterfaceGuestBookRepository>().To<GuestBookRepository>();
            ninjectKernel.Bind<InterfaceGoodsMarketingRepository>().To<GoodsMarketingRepository>();
            ninjectKernel.Bind<InterfaceGoodsPurchaseRepository>().To<GoodsPurchaseRepository>();
            ninjectKernel.Bind<InterfaceGoodsFutureRepository>().To<GoodsFutureRepository>();
            ninjectKernel.Bind<InterfaceGoodsPaymentRepository>().To<GoodsPaymentRepository>();
            ninjectKernel.Bind<InterfaceGoodsProfitRepository>().To<GoodsProfitRepository>();
            ninjectKernel.Bind<InterfaceMenuActionRepository>().To<MenuActionRepository>();
            ninjectKernel.Bind<InterfaceRoleActionRepository>().To<RoleActionRepository>();
            ninjectKernel.Bind<InterfaceMonitorRepository>().To<MonitorRepository>();
            ninjectKernel.Bind<InterfaceMonitorConditionRepository>().To<MonitorConditionRepository>();
            //put bindings here
        }
    }
}