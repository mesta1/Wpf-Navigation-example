using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WpfNavigationExample.Messages;
using WpfNavigationExample.Views.First;
using WpfNavigationExample.Views.Second;
using WpfNavigationExample.Views.Third;

namespace WpfNavigationExample.Views
{
    public class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the current screen on the shell
        /// </summary>
        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { Set(ref _currentViewModel, value); }
        }
        private ViewModelBase _currentViewModel;

        public RelayCommand ShowFirstViewCommand { get; private set; }

        public RelayCommand ShowSecondViewCommand { get; private set; }

        public RelayCommand ShowThirdViewCommand { get; private set; }


        private readonly FirstViewModel _firstViewModel;
        private readonly SecondViewModel _secondViewModel;
        private readonly ThirdViewModel _thirdViewModel;

        [Obsolete("Only for design data", true)]
        public MainWindowViewModel() : this(new FirstViewModel(null), null, null)
        {
            if (!this.IsInDesignMode)
            {
                throw new Exception("Use only for design mode");
            }
        }
        
        public MainWindowViewModel(FirstViewModel firstViewModel, SecondViewModel secondViewModel, ThirdViewModel thirdViewModel)
        {
            _firstViewModel = firstViewModel;
            _secondViewModel = secondViewModel;
            _thirdViewModel = thirdViewModel;
            ShowFirstViewCommand = new RelayCommand(ShowFirstView);
            ShowSecondViewCommand = new RelayCommand(ShowSecondView);
            ShowThirdViewCommand = new RelayCommand(ShowThirdView);
            ShowFirstView();
            Messenger.Default.Register<ChangePage>(this, ChangePage);
        }

        private void ShowFirstView()
        {
            CurrentViewModel = _firstViewModel;
        }

        private void ShowSecondView()
        {
            CurrentViewModel = _secondViewModel;
        }

        private void ShowThirdView()
        {
            CurrentViewModel = _thirdViewModel;
        }

        private void ChangePage(ChangePage message)
        {
            if (message.ViewModelType == typeof (FirstViewModel))
            {
                ShowFirstView();
            }
            else if (message.ViewModelType == typeof(SecondViewModel))
            {
                ShowSecondView();
            }
            else if (message.ViewModelType == typeof(ThirdViewModel))
            {
                ShowThirdView();
            }
        }

    }
}
