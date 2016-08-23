using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WpfNavigationExample.Messages;
using WpfNavigationExample.Views.First;

namespace WpfNavigationExample.Views.Third
{
    public class ThirdViewModel : ViewModelBase
    {
        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }
        private string _name;

        public RelayCommand ShowFirstViewCommand { get; private set; }

        public ThirdViewModel()
        {
            Name = "Hello from Third ViewModel";
            ShowFirstViewCommand= new RelayCommand(ShowFirstView);
        }

        private void ShowFirstView()
        {
            Messenger.Default.Send(new ChangePage(typeof(FirstViewModel)));
        }
    }
}
