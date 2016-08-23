using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WpfNavigationExample.Framework;

namespace WpfNavigationExample.Views.Dialogs.EditTitle
{
    public class EditTitleDialogViewModel : ViewModelBase
    {
        public string Title
        {
            get { return _title; }
            set { Set(ref _title, value); }
        }
        private string _title;

        public ObservableCommand ConfirmCommand { get; private set; }

        public RelayCommand CancelCommand { get; private set; }


        public EditTitleDialogViewModel()
        {
            ConfirmCommand = new ObservableCommand(Confirm);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void Confirm()
        {
            
        }

        private void Cancel()
        {
            
        }
        
    }
}
