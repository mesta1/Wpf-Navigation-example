namespace WpfNavigationExample.Views.Dialogs.EditTitle
{
    public interface IEditTitleDialogFactory
    {
        IEditTitleDialog Create(string title);
    }

    public class EditTitleDialogFactory : IEditTitleDialogFactory
    {
        private readonly EditTitleDialogViewModel _dialogViewModel;

        public EditTitleDialogFactory(EditTitleDialogViewModel dialogViewModel)
        {
            _dialogViewModel = dialogViewModel;
        }

        public IEditTitleDialog Create(string title)
        {
            _dialogViewModel.Title = title;
            return new EditTitleDialog(_dialogViewModel);
        }
    }
}
