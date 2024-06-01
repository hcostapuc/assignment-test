using Assignment.Application.Common.Interfaces;

namespace Assignment.Application.TodoItems.Commands.CreateTodoItem;

public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
{
    private readonly IApplicationDbContext _context;
    private record BriefTodoItem(int ListId, string Title);

    public CreateTodoItemCommandValidator(IApplicationDbContext context)
    {
        RuleFor(v => v.Title)
            .MaximumLength(200).WithMessage("Title must be less than 200 characters")
            .NotEmpty().WithMessage("Title is required");

        RuleFor(v => new BriefTodoItem(v.ListId, v.Title))
            .MustAsync(BeUniqueTitle)
                .WithMessage("'{PropertyName}' must be unique.")
                .WithErrorCode("Unique");

        _context = context;
    }

    private async Task<bool> BeUniqueTitle(BriefTodoItem todoItem, CancellationToken cancellationToken) =>
        !await _context.TodoItems
            .AnyAsync(l => l.Title.ToLower() == todoItem.Title.ToLower() && 
                           l.ListId == todoItem.ListId, cancellationToken);
}
