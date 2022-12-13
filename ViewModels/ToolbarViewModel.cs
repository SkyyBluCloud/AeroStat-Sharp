using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace AeroStat_Sharp.ViewModels
{
    public class ToolbarViewModel : BindableBase
    {
        public DelegateCommand TrafficLogCommand { get; set; }
        public DelegateCommand SettingsCommand { get; set; }

        private IRegionManager _regionManager;

        public ToolbarViewModel(IRegionManager regionManager)
        {
            TrafficLogCommand = new DelegateCommand(gotoTrafficLog);
            SettingsCommand = new DelegateCommand(gotoSettings);
            _regionManager = regionManager;
        }

        private void gotoTrafficLog() => _regionManager.RequestNavigate("MainRegion", "TrafficLog");

        private void gotoSettings() => _regionManager.RequestNavigate("MainRegion", "TabView");
    }
}
