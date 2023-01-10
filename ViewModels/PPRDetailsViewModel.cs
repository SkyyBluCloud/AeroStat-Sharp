using AeroStat_Sharp.Models;
using DryIoc;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Media;

namespace AeroStat_Sharp.ViewModels
{
    public class PPRDetailsViewModel : BindableBase, IDialogAware
    {
        public static FontFamily titleFont => new("Segoe UI Black");
        public static FontFamily bodyFont => new("Segoe UI");
        public static CultureInfo mil => new("hr-HR");
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

            ppr = dPPR;

            if (pprExists)
            {
                arrDatePicker = ppr.arrDate;
                depDatePicker = ppr.depDate;
                arrTimePicker = ppr.arrDate.ToString("t",mil);
                depTimePicker = ppr.depDate?.ToString("t",mil);
            }

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
        public DateTime arrDatePicker
        {
            get => _arrDatePicker;
            set => SetProperty(ref _arrDatePicker,value);
        }
        public DateTime? depDatePicker
        {
            get => _depDatePicker;
            set => SetProperty(ref _depDatePicker, value);
        }
        public string arrTimePicker
        {
            get => _arrTimePicker;
            set => SetProperty(ref _arrTimePicker, value);
        }
        public string? depTimePicker
        {
            get => _depTimePicker;
            set => SetProperty(ref _depTimePicker, value);
        }
        public string Title => pprHeader;

        private PPR? _ppr;
        private string? _strPPR;
        private string? _pprHeader;
        private List<PPRService>? _serviceList;
        private readonly DataAccess DA;
        private bool newRec;
        private DateTime _arrDatePicker;
        private DateTime? _depDatePicker;
        private string _arrTimePicker = "00:00".ToString(mil);
        private string? _depTimePicker = "00:00".ToString(mil);
    }
}
