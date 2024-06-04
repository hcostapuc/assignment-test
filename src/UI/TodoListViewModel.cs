using System.Windows.Input;
using Assignment.Application.TodoLists.Commands.CreateTodoList;
using Assignment.UI.Models;
using Caliburn.Micro;
using MediatR;
using ValidationException = Assignment.Application.Common.Exceptions.ValidationException;

namespace Assignment.UI;
public class TodoListViewModel : Screen
{
    private readonly ISender _sender;
    private readonly IWindowManager _windowManager;

    private string _title;
    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            NotifyOfPropertyChange(() => Title);
        }
    }

    private int _id;
    public int Id
    {
        get => _id;
        set
        {
            _id = value;
            NotifyOfPropertyChange(() => Id);
        }
    }


    public ICommand SaveCommand { get; }
    public ICommand CloseCommand { get; }

    public TodoListViewModel(ISender sender,
                            IWindowManager windowManager)
    {
        _sender = sender;
        _windowManager = windowManager;
        SaveCommand = new RelayCommand(SaveExecute);
        CloseCommand = new RelayCommand(CloseExecute);
    }

    private async void SaveExecute(object parameter)
    {
        try
        {
            Id = await _sender.Send(new CreateTodoListCommand(Title));
            await TryCloseAsync(true);
        }
        catch (ValidationException validationException)
        {
            var popUpValidationError = new PopUpValidationErrorViewModel(new PopUpValidationErrorModel
            {
                MessageErrorCollection = validationException.Errors.Values.SelectMany(a => a).ToList()
            });
            await _windowManager.ShowDialogAsync(popUpValidationError);
        }
    }

    private async void CloseExecute(object parameter) =>
        await TryCloseAsync(false);
}
