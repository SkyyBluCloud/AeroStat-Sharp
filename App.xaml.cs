using AeroStat_Sharp.Modules;
using AeroStat_Sharp.Views;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Windows;
using static AeroStat_Sharp.Views.PPRDetails;

namespace AeroStat_Sharp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Main>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<MainModule>();
        }
    }
}
