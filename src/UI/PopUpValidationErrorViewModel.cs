using System.Windows.Input;
using Assignment.UI.Models;
using Caliburn.Micro;

namespace Assignment.UI;
internal class PopUpValidationErrorViewModel : Screen
{
    private PopUpValidationErrorModel _popUpValidationErrorModel;
    public PopUpValidationErrorModel PopUpValidationErrorModel
    {
        get => _popUpValidationErrorModel; 
        set
        {
            _popUpValidationErrorModel = value;
            NotifyOfPropertyChange(() => PopUpValidationErrorModel);
        }
    }

    public ICommand CloseCommand { get; }

    public PopUpValidationErrorViewModel(PopUpValidationErrorModel popUpValidationErrorModel)
    {
        _popUpValidationErrorModel = popUpValidationErrorModel;
        CloseCommand = new RelayCommand(CloseExecute);
    }

    private async void CloseExecute(object parameter) =>
        await TryCloseAsync(false);
}
