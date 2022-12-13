using AeroStat_Sharp.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;


namespace AeroStat_Sharp.Modules
{
    public class MainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var region = containerProvider.Resolve<IRegionManager>();
            region.RegisterViewWithRegion("MainRegion", typeof(TrafficLog));
            region.RegisterViewWithRegion("ToolbarRegion", typeof(Toolbar));
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<TrafficLog>();

            containerRegistry.RegisterDialog<PPRDetails>();
        }
    }
}
