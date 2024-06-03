using Assignment.Application.Common.Interfaces;
using Assignment.Application.TodoLists.Commands.CreateTodoList;
using Assignment.Domain.Entities.Todo;
using AutoFixture;
using Moq;

namespace Application.UnitTests.TodoLists;
public class CreateTodoListCommandHandlerTest
{
    [Fact]
    public async Task ShouldCreateTodoListSuccesfully()
    {
        //Arrange
        var fixture = new Fixture();

        var command = fixture.Create<CreateTodoListCommand>();

        var context = new Mock<IApplicationDbContext>();

        context.Setup(x => x.TodoLists.AddAsync(It.IsAny<TodoList>(), It.IsAny<CancellationToken>()))
               .Verifiable();

        context.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
               .Verifiable();

        var handler = new CreateTodoListCommandHandler(context.Object);

        //Act
        var result = await handler.Handle(command, new CancellationToken());

        //Assert
        context.Verify();
    }
}
