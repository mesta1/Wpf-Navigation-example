using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WpfNavigationExample.Messages;
using WpfNavigationExample.Views.Third;

namespace WpfNavigationExample.Views.Second
{
    public class SecondViewModel : ViewModelBase
    {
        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }
        private string _name;

        public RelayCommand ShowThirdViewCommand { get; private set; }

        public SecondViewModel()
        {
            Name = "Hello from Second ViewModel";
            ShowThirdViewCommand = new RelayCommand(ShowThirdView);
        }

        private void ShowThirdView()
        {
            Messenger.Default.Send(new ChangePage(typeof(ThirdViewModel)));
        }
    }
}
