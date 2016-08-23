using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using WpfNavigationExample.Framework;
using WpfNavigationExample.Views;
using WpfNavigationExample.Views.Dialogs;
using WpfNavigationExample.Views.Dialogs.EditTitle;
using WpfNavigationExample.Views.First;
using WpfNavigationExample.Views.Second;
using WpfNavigationExample.Views.Third;

namespace WpfNavigationExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private WindsorContainer container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            container = new WindsorContainer();
            container.Register(Component.For<FirstViewModel>());
            container.Register(Component.For<SecondViewModel>());
            container.Register(Component.For<ThirdViewModel>());
            container.Register(Component.For<MainWindowViewModel>());
            container.Register(Component.For<MainWindow>());

            container.Register(Component.For<EditTitleDialogViewModel>());
            container.Register(Component.For<IEditTitleDialogFactory>().ImplementedBy<EditTitleDialogFactory>());

            container.Register(Component.For<IMessageBoxService>().ImplementedBy<MessageBoxService>());

            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.ShowDialog();
        }
    }
}
