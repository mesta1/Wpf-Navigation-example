using System;
using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WpfNavigationExample;
using WpfNavigationExample.Framework;
using WpfNavigationExample.Views;
using WpfNavigationExample.Views.Dialogs;
using WpfNavigationExample.Views.Dialogs.EditTitle;
using WpfNavigationExample.Views.First;
using WpfNavigationExample.Views.Second;
using WpfNavigationExample.Views.Third;

namespace WpfApplicationExample.Tests
{
    [TestClass]
    public class ApplicationTests
    {
        [TestMethod]
        public void TestHierarchicalNavigation()
        {
            var firstViewModel = new FirstViewModel(null);
            var secondViewModel = new SecondViewModel();
            var thirdViewModel = new ThirdViewModel();
            MainWindowViewModel mainViewModel = new MainWindowViewModel(firstViewModel, secondViewModel, thirdViewModel);
            Assert.AreEqual(firstViewModel, mainViewModel.CurrentViewModel);

            mainViewModel.ShowSecondViewCommand.Execute(null);
            Assert.AreEqual(secondViewModel, mainViewModel.CurrentViewModel);

            mainViewModel.ShowThirdViewCommand.Execute(null);
            Assert.AreEqual(thirdViewModel, mainViewModel.CurrentViewModel);
        }

        [TestMethod]
        public void TestFirstViewModelConfirmEditTitle()
        {
            var dialogMock = new Mock<IEditTitleDialog>();
            dialogMock.Setup(dialog => dialog.ViewModelTitle).Returns("Edited title");
            dialogMock.Setup(dialog => dialog.ShowDialog()).Returns(true);

            var factoryMock = new Mock<IEditTitleDialogFactory>();
            factoryMock.Setup(factory => factory.Create(It.IsAny<string>())).Returns(dialogMock.Object);

            var firstViewModel = new FirstViewModel(factoryMock.Object);
            Assert.AreEqual("Hello from First ViewModel", firstViewModel.Name);

            firstViewModel.ShowDialogCommand.Execute(null);
            Assert.AreEqual("Edited title", firstViewModel.Name);
        }

        [TestMethod]
        public void TestFirstViewModelNavigation()
        {
            var firstViewModel = new FirstViewModel(null);
            var secondViewModel = new SecondViewModel();
            var thirdViewModel = new ThirdViewModel();
            MainWindowViewModel mainViewModel = new MainWindowViewModel(firstViewModel, secondViewModel, thirdViewModel);
            Assert.AreEqual(firstViewModel, mainViewModel.CurrentViewModel);

            // we are in FirstViewModel, we click "Navigate to second" and in messagebox we click No
            var mock = new Mock<IMessageBoxService>();
            mock.Setup(messageBox => messageBox.Show(It.IsAny<string>(), It.IsAny<string>(), MessageBoxButton.YesNo, MessageBoxImage.Question))
                .Returns(MessageBoxResult.No);
            firstViewModel.MessageBoxService = mock.Object;
            firstViewModel.ShowSecondViewCommand.Execute(true);
            Assert.AreEqual(firstViewModel, mainViewModel.CurrentViewModel);

            // we are in FirstViewModel, we click "Navigate to second" and in the messagebox we click Yes
            mock = new Mock<IMessageBoxService>();
            mock.Setup(messageBox => messageBox.Show(It.IsAny<string>(), It.IsAny<string>(), MessageBoxButton.YesNo, MessageBoxImage.Question))
                .Returns(MessageBoxResult.Yes);
            firstViewModel.MessageBoxService = mock.Object;
            firstViewModel.ShowSecondViewCommand.Execute(true);
            Assert.AreEqual(secondViewModel, mainViewModel.CurrentViewModel);
        }

        [TestMethod]
        public void TestSecondViewModelAndThirdViewModelNavigation()
        {
            var firstViewModel = new FirstViewModel(null);
            var secondViewModel = new SecondViewModel();
            var thirdViewModel = new ThirdViewModel();
            MainWindowViewModel mainViewModel = new MainWindowViewModel(firstViewModel, secondViewModel, thirdViewModel);
            mainViewModel.CurrentViewModel = secondViewModel;

            secondViewModel.ShowThirdViewCommand.Execute(null);
            Assert.AreEqual(thirdViewModel, mainViewModel.CurrentViewModel);

            thirdViewModel.ShowFirstViewCommand.Execute(null);
            Assert.AreEqual(firstViewModel, mainViewModel.CurrentViewModel);
        }

        [TestMethod]
        public void TestFirstViewModelCancelEditTitle()
        {
            var dialogMock = new Mock<IEditTitleDialog>();
            dialogMock.Setup(dialog => dialog.ViewModelTitle).Returns("Edited title");
            dialogMock.Setup(dialog => dialog.ShowDialog()).Returns(false);

            var factoryMock = new Mock<IEditTitleDialogFactory>();
            factoryMock.Setup(factory => factory.Create(It.IsAny<string>())).Returns(dialogMock.Object);

            var firstViewModel = new FirstViewModel(factoryMock.Object);
            Assert.AreEqual("Hello from First ViewModel", firstViewModel.Name);

            firstViewModel.ShowDialogCommand.Execute(null);
            Assert.AreEqual("Hello from First ViewModel", firstViewModel.Name);
        }


    }
}
