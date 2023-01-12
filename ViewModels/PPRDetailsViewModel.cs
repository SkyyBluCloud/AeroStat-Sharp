using AeroStat_Sharp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Markup;
using System.Windows.Media;

namespace AeroStat_Sharp.ViewModels
{
    public class PPRDetailsViewModel : BindableBase, IDialogAware
    {
        public static FontFamily titleFont => new("Segoe UI Black");
        public static FontFamily bodyFont => new("Segoe UI");
        public event Action<IDialogResult>? RequestClose;
        public DelegateCommand? cmdClose;
        public void CloseDialog(string param)
        {
            ButtonResult buttonResult = ButtonResult.Abort;

            RaiseRequestClose (new DialogResult(buttonResult));
        }
        public void RaiseRequestClose(IDialogResult result)
        {
            RequestClose?.Invoke(result);
        }
        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            strPPR = parameters.GetValue<string>("ppr");
            var pprExists = DA.pprExists(strPPR);
            newRec = !pprExists;
            var dPPR = !newRec ? DA.getPPR(strPPR): new();
            dPPR.loadServices();

            List<string> strSVC = new();
            if (dPPR.pprServices != null)
            {
                foreach (PPRService p in dPPR.pprServices)
                    if (p.requested) strSVC.Add(p.service ?? "");

                if (strSVC.Count > 0) servicesHeader = $"Services: {string.Join(", ", strSVC)}";
            }

            ppr = dPPR;
            pprHeader = newRec ? "PPR" : $"{ppr.pprNumber} | {ppr.callsign}";
            serviceList = DA.getPPRServices();
        }

        public PPRDetailsViewModel() => DA = new();
        public PPR ppr
        {
            get => _ppr ?? new();
            set => SetProperty(ref _ppr, value);
        }
        public string pprHeader
        {
            get => _pprHeader ?? (newRec ? "PPR" : $"{ppr?.pprNumber} - {ppr?.callsign}");
            set => SetProperty(ref _pprHeader, value);
        }
        public string servicesHeader
        {
            get => _servicesHeader ?? "Services";
            set => SetProperty(ref _servicesHeader, value);
        }
        public string strPPR
        {
            get => _strPPR ?? "<NEW>";
            set => SetProperty(ref _strPPR, value);
        }
        public List<PPRService> serviceList
        {
            get => _ppr?.pprServices ?? _serviceList ?? new();
            set => SetProperty(ref _serviceList, value);
        }
        public string Title => pprHeader;

        private PPR? _ppr;
        private string? _strPPR;
        private string? _pprHeader;
        private List<PPRService>? _serviceList;
        private readonly DataAccess DA;
        private bool newRec;
        private string? _servicesHeader;

        
    }
}
