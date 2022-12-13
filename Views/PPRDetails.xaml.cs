using Prism.Services.Dialogs;
using System.ComponentModel;
using System.Windows;

namespace AeroStat_Sharp.Views
{
    /// <summary>
    /// Interaction logic for PPRDetails.xaml
    /// </summary>
    public partial class PPRDetails : Window, IView, IDialogWindow
    {
        public PPRDetails()
        {
            InitializeComponent();
        }

        public IDialogResult Result { get; set; }

        public bool? Open()
        {
            return this.ShowDialog();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            this.Visibility= Visibility.Collapsed;
            e.Cancel= true;
        }

    }
    public interface IView
    {
        bool? Open();
    }
}
