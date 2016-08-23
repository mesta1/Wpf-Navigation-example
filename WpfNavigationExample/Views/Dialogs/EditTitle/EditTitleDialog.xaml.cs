using System;
using System.ComponentModel;
using System.Windows;

namespace WpfNavigationExample.Views.Dialogs.EditTitle
{
    public interface IEditTitleDialog
    {
        string ViewModelTitle { get; }

        bool? ShowDialog();
    }
    
    public partial class EditTitleDialog : Window, IEditTitleDialog
    {
        public string ViewModelTitle { get; private set; }

        private readonly EditTitleDialogViewModel _dialogViewModel;

        public EditTitleDialog(EditTitleDialogViewModel dialogViewModel)
        {
            InitializeComponent();
            this.Owner = App.Current.MainWindow;
            this.DataContext = _dialogViewModel = dialogViewModel;
            _dialogViewModel.ConfirmCommand.CommandExecuted += ConfirmCommand_CommandExecuted;
        }

        void ConfirmCommand_CommandExecuted(object sender, EventArgs e)
        {
            ViewModelTitle = _dialogViewModel.Title;
            this.DialogResult = true;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _dialogViewModel.ConfirmCommand.CommandExecuted -= ConfirmCommand_CommandExecuted;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _dialogViewModel.CancelCommand.Execute(null);
            this.DialogResult = false;
        }
    }
}
