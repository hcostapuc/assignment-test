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
    private const int TODOLIST_CACHE_MINUTE = 2;//TODO: For static values set on appsettings using options pattern

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
            TodoLists = todoListCached;
        else
        {
            TodoLists = await _sender.Send(new GetTodosQuery());

            _memoryCache.Set(nameof(TodoLists), TodoLists, new TimeSpan(0, TODOLIST_CACHE_MINUTE, 0));
        }

        if (selectedListId.HasValue && selectedListId.Value > 0)
            SelectedTodoList = TodoLists.FirstOrDefault(list => list.Id == selectedListId.Value);
    }

    private async Task RefereshTodoListAsync(int todoListId)
    {
        var selectedListId = SelectedTodoList?.Id;

        var todoListUpdated = await _sender.Send(new GetTodoQuery(todoListId));

        var todoListOutdated = TodoLists.FirstOrDefault(x => x.Id == todoListId);

        if (todoListOutdated != null)
        {
            var indexToAddTodoListUpdated = TodoLists.IndexOf(todoListOutdated);

            TodoLists.RemoveAt(indexToAddTodoListUpdated);
            TodoLists.Insert(indexToAddTodoListUpdated, todoListUpdated);
        }
        else
        {
            TodoLists.Add(todoListUpdated);
        }

        TodoLists = [.. TodoLists];

        if (selectedListId.HasValue && selectedListId.Value == todoListUpdated.Id)
            SelectedTodoList = todoListUpdated;

        _memoryCache.Set(nameof(TodoLists), TodoLists, new TimeSpan(0, TODOLIST_CACHE_MINUTE, 0));
    }
    private async void AddTodoList(object obj)
    {
        var todoList = new TodoListViewModel(_sender, _windowManager);

        await _windowManager.ShowDialogAsync(todoList)
                            .ContinueWith(prevTask => RefereshTodoListAsync(todoList.Id));
    }

    private async void AddTodoItem(object obj)
    {
        var todoItem = new TodoItemViewModel(_sender, SelectedTodoList.Id, _windowManager);
        await _windowManager.ShowDialogAsync(todoItem)
                            .ContinueWith(prevTask => RefereshTodoListAsync(SelectedTodoList.Id));
    }

    private async void DoneTodoItem(object obj)
    {
        await _sender.Send(new DoneTodoItemCommand(SelectedItem.Id))
                     .ContinueWith(prevTask => RefereshTodoListAsync(SelectedTodoList.Id));
    }
}
