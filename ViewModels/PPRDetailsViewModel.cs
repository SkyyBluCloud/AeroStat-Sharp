using AeroStat_Sharp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;

namespace AeroStat_Sharp.ViewModels
{
    public class PPRDetailsViewModel : BindableBase, IDialogAware
    {
        public event Action<IDialogResult> RequestClose;
        public DelegateCommand cmdCLose { get; }

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            
            var strPPR = parameters.GetValue<string>("ppr");
            var pprExists = da.pprExists(strPPR);
            newRec = parameters.GetValue<bool>("newRec");
            _ppr = !newRec ? pprExists ? da.getPPR(strPPR) : new() : new();
            
        }

        public PPRDetailsViewModel()
        {
            cmdCLose = new DelegateCommand(() => RequestClose(null));
            da = new();
            _pprServices = da.getPPRServices();
        }
        public PPR? ppr
        {
            get => _ppr;
            //set => SetProperty(ref _ppr, value);
        }

        public List<PPRService> pprServices => _pprServices ?? new();
        public string pprHeader 
        { 
            get => newRec ? "PPR" : $"{_ppr.pprNumber} - {_ppr.callsign}";
        }

        public string Title => pprHeader;

        private PPR _ppr;
        private readonly List<PPRService>? _pprServices;
        private readonly DataAccess da;
        private bool newRec;

        
    }
}
