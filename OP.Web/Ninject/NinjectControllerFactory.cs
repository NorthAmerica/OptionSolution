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
            ninjectKernel.Bind<IUserRepository>().To<UserRepository>();
            ninjectKernel.Bind<IMenuRepository>().To<MenuRepository>();
            ninjectKernel.Bind<IRoleMenuRepository>().To<RoleMenuRepository>();
            ninjectKernel.Bind<IRoleRepository>().To<RoleRepository>();
            ninjectKernel.Bind<IUserRoleRepository>().To<UserRoleRepository>();
            ninjectKernel.Bind<IFuturesFundRepository>().To<FuturesFundRepository>();
            ninjectKernel.Bind<IFuturesTradeVolumeRepository>().To<FuturesTradeVolumeRepository>();
            ninjectKernel.Bind<IFuturePriceRepository>().To<FuturePriceRepository>();
            ninjectKernel.Bind<IFallRoleRepository>().To<FallRoleRepository>();
            ninjectKernel.Bind<IOptionsProductRepository>().To<OptionsProductRepository>();
            ninjectKernel.Bind<IPartnerRepository>().To<PartnerRepository>();
            ninjectKernel.Bind<InterfaceRiseRoleRepository>().To<RiseRoleRepository>();
            ninjectKernel.Bind<INumberTypeRepository>().To<NumberTypeRepository>();
            ninjectKernel.Bind<IOptionTypeRepository>().To<OptionTypeRepository>();
            ninjectKernel.Bind<IPartTypeRepository>().To<PartTypeRepository>();
            ninjectKernel.Bind<IOptionTradeRepository>().To<OptionTradeRepository>();
            ninjectKernel.Bind<IOptionTradeSumRepository>().To<OptionTradeSumRepository>();
            ninjectKernel.Bind<IFundStatusRepository>().To<FundStatusRepository>();
            ninjectKernel.Bind<IManageStatusRepository>().To<ManageStatusRepository>();
            ninjectKernel.Bind<IEventLogRepository>().To<EventLogRepository>();
            ninjectKernel.Bind<ITdaysRepository>().To<TdaysRepository>();
            ninjectKernel.Bind<ICallPriceTypeRepository>().To<CallPriceTypeRepository>();
            ninjectKernel.Bind<IONOFFSetRepository>().To<ONOFFSetRepository>();
            ninjectKernel.Bind<IONTimeRepository>().To<ONTimeRepository>();
            ninjectKernel.Bind<IBrochureRepository>().To<BrochureRepository>();
            ninjectKernel.Bind<IGuestBookRepository>().To<GuestBookRepository>();
            ninjectKernel.Bind<IGoodsMarketingRepository>().To<GoodsMarketingRepository>();
            ninjectKernel.Bind<IGoodsPurchaseRepository>().To<GoodsPurchaseRepository>();
            ninjectKernel.Bind<IGoodsFutureRepository>().To<GoodsFutureRepository>();
            ninjectKernel.Bind<IGoodsPaymentRepository>().To<GoodsPaymentRepository>();
            ninjectKernel.Bind<IGoodsProfitRepository>().To<GoodsProfitRepository>();
            ninjectKernel.Bind<IMenuActionRepository>().To<MenuActionRepository>();
            ninjectKernel.Bind<IRoleActionRepository>().To<RoleActionRepository>();
            ninjectKernel.Bind<IMonitorRepository>().To<MonitorRepository>();
            ninjectKernel.Bind<IMonitorConditionRepository>().To<MonitorConditionRepository>();
            //put bindings here
        }
    }
}