using AeroStat_Sharp.Models;
using AeroStat_Sharp.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AeroStat_Sharp.ViewModels
{
    public class TrafficLogViewModel : BindableBase
    {
        private readonly DataAccess DA = new();
        private readonly IDialogService DIALOG;
        public TrafficLogViewModel(IDialogService dialogService) 
        {
            var lstPPR = DA.getPPRsTrafficLog(true);
            ObservableCollection<PPR> ocPPR = new();
            foreach (PPR p in lstPPR) { ocPPR.Add(p); }
            _pprList = ocPPR;
            DIALOG = dialogService;
        }
        
        private ObservableCollection<PPR> _pprList;
        public ObservableCollection<PPR> pprList
        {
            get => _pprList;
            set => SetProperty(ref _pprList, value);
        }
        private DelegateCommand? _cmdNewPPR;
        public DelegateCommand cmdNewPPR => _cmdNewPPR ??= new DelegateCommand(newPPR);
        private DelegateCommand<object> _cmdShowPPR;
        public DelegateCommand<object> cmdShowPPR => _cmdShowPPR ??= new DelegateCommand<object>((obj) => DataGrid_MouseDoubleClick(obj));
        private void newPPR()
        {
            DIALOG.ShowDialog("PPRDetails", new DialogParameters
            {
                {"ppr","<NEW>" }
            },
            null);
        }
        private void DataGrid_MouseDoubleClick(object sender)
        {
            try
            {
                if (sender == null) return;
                //DataGrid dataGrid = (DataGrid)sender;
                PPR ppr = (PPR)sender;
                if (ppr == null) return;

                DIALOG.ShowDialog("PPRDetails", new DialogParameters
                {
                    {"ppr",ppr.pprNumber }
                },
                null); 
                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private object _selectedPPR;

        public object selectedPPR { get => _selectedPPR; set => SetProperty(ref _selectedPPR, value); }

    }
}
