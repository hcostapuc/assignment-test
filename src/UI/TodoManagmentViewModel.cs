using System.Windows.Input;
using Assignment.Application.Common.Interfaces;
using Assignment.Application.TodoItems.Commands.DoneTodoItem;
using Assignment.Application.TodoLists.Queries.GetTodo;
using Assignment.Application.TodoLists.Queries.GetTodos;
using Caliburn.Micro;
using MediatR;

namespace Assignment.UI;
internal class TodoManagmentViewModel : Screen
{
    private readonly ISender _sender;
    private readonly IWindowManager _windowManager;
    private readonly IMemoryCache _memoryCache;


    private IList<TodoListDto> _todoLists;
    public IList<TodoListDto> TodoLists
    {
        get
        {
            return _todoLists;
        }
        set
        {
            _todoLists = value;
            NotifyOfPropertyChange(() => TodoLists);
        }
    }

    private TodoListDto _selectedTodoList;
    public TodoListDto SelectedTodoList
    {
        get => _selectedTodoList;
        set
        {
            _selectedTodoList = value;
            NotifyOfPropertyChange(() => SelectedTodoList);
        }
    }

    private TodoItemDto _selectedItem;
    public TodoItemDto SelectedItem
    {
        get => _selectedItem;
        set
        {
            _selectedItem = value;
            NotifyOfPropertyChange(() => SelectedItem);
            IsDoneButtonVisible = _selectedItem is not null && !_selectedItem.Done;
        }
    }

    private bool _isDoneButtonVisible = false;

    public bool IsDoneButtonVisible
    {
        get => _isDoneButtonVisible;
        set
        {
            if (_isDoneButtonVisible != value)
            {
                _isDoneButtonVisible = value;
                NotifyOfPropertyChange(() => IsDoneButtonVisible);
            }
        }
    }

    public ICommand AddTodoListCommand { get; private set; }
    public ICommand AddTodoItemCommand { get; private set; }
    public ICommand DoneTodoItemCommand { get; private set; }

    public TodoManagmentViewModel(ISender sender,
                                  IWindowManager windowManager,
                                  IMemoryCache memoryCache)
    {
        _sender = sender;
        _memoryCache = memoryCache;
        _windowManager = windowManager;
        Initialize();
    }

    private async void Initialize()
    {
        await RefereshTodoListsAsync();

        AddTodoListCommand = new RelayCommand(AddTodoList);
        AddTodoItemCommand = new RelayCommand(AddTodoItem);
        DoneTodoItemCommand = new RelayCommand(DoneTodoItem);
    }

    private async Task RefereshTodoListsAsync()
    {
        var selectedListId = SelectedTodoList?.Id;

        if (_memoryCache.TryGetValue<IList<TodoListDto>>(nameof(TodoLists), out var todoListCached))
        {
            TodoLists = todoListCached;
        }
        else
        {
            TodoLists = await _sender.Send(new GetTodosQuery());

            _memoryCache.Set(nameof(TodoLists), TodoLists, new TimeSpan(0, 2, 0));//TODO: For static values set on appsettings.
        }

        if (selectedListId.HasValue && selectedListId.Value > 0)
        {
            SelectedTodoList = TodoLists.FirstOrDefault(list => list.Id == selectedListId.Value);
        }
    }

    private async Task RefereshTodoListSelectedAsync()
    {
        var selectedListId = SelectedTodoList?.Id;

        if (selectedListId.HasValue && selectedListId.Value > 0)
        {
            var selectedTodoListUpdated = await _sender.Send(new GetTodoQuery(selectedListId.Value));

            if(_memoryCache.TryGetValue<IList<TodoListDto>>(nameof(TodoLists), out var todoListsCached))
            {
                var selectedTodoListOutdated = todoListsCached.First(x => x.Id == selectedListId.Value);

                var indexToAddTodoListUpdated = TodoLists.IndexOf(selectedTodoListOutdated);

                TodoLists.RemoveAt(indexToAddTodoListUpdated);
                TodoLists.Insert(indexToAddTodoListUpdated,selectedTodoListUpdated);
                
                TodoLists = [.. TodoLists];
                
                SelectedTodoList = selectedTodoListUpdated;

                _memoryCache.Set(nameof(TodoLists), TodoLists, new TimeSpan(0, 2, 0));//TODO: For static values set on appsettings.
            }
        }
    }
    private async void AddTodoList(object obj)
    {
        var todoList = new TodoListViewModel(_sender);

        await _windowManager.ShowDialogAsync(todoList)
                            .ContinueWith(prevTask => RefereshTodoListsAsync());
    }

    private async void AddTodoItem(object obj)
    {
        var todoItem = new TodoItemViewModel(_sender, SelectedTodoList.Id);
        await _windowManager.ShowDialogAsync(todoItem)
                            .ContinueWith(prevTask => RefereshTodoListSelectedAsync());
    }

    private async void DoneTodoItem(object obj)
    {
        await _sender.Send(new DoneTodoItemCommand(SelectedItem.Id))
                     .ContinueWith(prevTask => RefereshTodoListSelectedAsync());
    }
}
