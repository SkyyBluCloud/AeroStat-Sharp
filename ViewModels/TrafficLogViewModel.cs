using AeroStat_Sharp.Models;
using AeroStat_Sharp.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Collections.Generic;

namespace AeroStat_Sharp.ViewModels
{
    public class TrafficLogViewModel : BindableBase
    {
        private readonly DataAccess da = new();
        private readonly IDialogService _dialogService;
        public TrafficLogViewModel(IDialogService dialogService) 
        {
            _pprList = da.getCurrentDayPPRs(true);
            _dialogService = dialogService;

        }
        
        private List<PPR> _pprList;
        public List<PPR> pprList
        {
            get
            {
                _pprList = da.getCurrentDayPPRs(true);
                return _pprList;
            }
            set => SetProperty(ref _pprList, value);
        }
        private DelegateCommand? _cmdNewPPR;
        public DelegateCommand cmdNewPPR => _cmdNewPPR ??= new DelegateCommand(newPPR);
        public DelegateCommand ShowDialog { get; }

        private void newPPR()
        {
            _dialogService.ShowDialog("PPRDetails", new DialogParameters
            {
                {"newrec",true }
            },
            null);
        }
    }
}
