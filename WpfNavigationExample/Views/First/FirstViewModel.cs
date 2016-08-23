using System;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WpfNavigationExample.Framework;
using WpfNavigationExample.Messages;
using WpfNavigationExample.Views.Dialogs;
using WpfNavigationExample.Views.Dialogs.EditTitle;
using WpfNavigationExample.Views.Second;

namespace WpfNavigationExample.Views.First
{
    public class FirstViewModel : ViewModelBase
    {
        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }
        private string _name;

        public IMessageBoxService MessageBoxService { get; set; }

        public RelayCommand ShowSecondViewCommand { get; private set; }

        public RelayCommand ShowDialogCommand { get; private set; }

        private readonly IEditTitleDialogFactory _dialogFactory;

        [Obsolete("Only for design data", true)]
        public FirstViewModel() : this(null)
        {
            if (!this.IsInDesignMode)
            {
                throw new Exception("Use only for design mode");
            }
        }


        public FirstViewModel(IEditTitleDialogFactory dialogFactory)
        {
            _dialogFactory = dialogFactory;
            Name = "Hello from First ViewModel";
            ShowSecondViewCommand = new RelayCommand(ShowSecondView);
            ShowDialogCommand = new RelayCommand(ShowDialog);
        }

        private void ShowSecondView()
        {
            var result = MessageBoxService.Show("Are you sure you want to navigate to the second view ?", 
                "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Messenger.Default.Send(new ChangePage(typeof(SecondViewModel)));
            }
        }

        private void ShowDialog()
        {
            var dialog = _dialogFactory.Create(Name);
            if (dialog.ShowDialog() == true)
            {
                this.Name = dialog.ViewModelTitle;
            }
        }
    }
}
