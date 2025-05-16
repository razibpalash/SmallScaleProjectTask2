using SmallScaleProjectTask2.Dots;
using SmallScaleProjectTask2.Records;
using System.Collections.Concurrent;

namespace SmallScaleProjectTask2.Endpoints;

public static class TodoItemEndpoints
{
    private static readonly ConcurrentDictionary<Guid, TodoItem> todos = new()
    {
        [Guid.NewGuid()] = new TodoItem(Guid.NewGuid(), "Test Data 1", false, DateTime.UtcNow),
        [Guid.NewGuid()] = new TodoItem(Guid.NewGuid(), "Test Data 2", true, DateTime.UtcNow.AddDays(-1)),
        [Guid.NewGuid()] = new TodoItem(Guid.NewGuid(), "Test Data 3", false, DateTime.UtcNow.AddHours(-2)),
        [Guid.NewGuid()] = new TodoItem(Guid.NewGuid(), "Test Data 3", false, DateTime.UtcNow.AddHours(-3)),
        [Guid.NewGuid()] = new TodoItem(Guid.NewGuid(), "Test Data 4", false, DateTime.UtcNow.AddHours(-4)),
        [Guid.NewGuid()] = new TodoItem(Guid.NewGuid(), "Test Data 5", false, DateTime.UtcNow.AddHours(-5))
    };

    public static void MapTodoItemEndpoints(this WebApplication app)
    {
        //var todoGroup = app.MapGroup("/task2");

        //todoGroup.MapGet("/todos", GetAll).WithName(nameof(GetAll));
        //todoGroup.MapGet("/todos/{id}", GetById).WithName(nameof(GetById));
        //todoGroup.MapPost("/todos", Create).WithName(nameof(Create));
        //todoGroup.MapPut("/todos/{id}", Update).WithName(nameof(Update));
        //todoGroup.MapDelete("/todos/{id}", Delete).WithName(nameof(Delete));

        app.MapGet("/todos", GetAll).WithName(nameof(GetAll));
        app.MapGet("/todos/{id}", GetById).WithName(nameof(GetById));
        app.MapPost("/todos", Create).WithName(nameof(Create));
        app.MapPut("/todos/{id}", Update).WithName(nameof(Update));
        app.MapDelete("/todos/{id}", Delete).WithName(nameof(Delete));
    }

    public static async Task<IResult> GetAll()
    {
        return await Task.FromResult(Results.Json(new
        {
            Data = todos.Values,
            Message = "Get all TodoItems successfully",
            StatusCode = 200
        }));
    }

    public static async Task<IResult> GetById(Guid id)
    {
        return await Task.FromResult(todos.TryGetValue(id, out var item)
            ? Results.Json(new { Data = item, Message = "Get TodoItem successfully", StatusCode = 200 })
            : Results.NotFound(new { Message = "TodoItem not found", StatusCode = 404 }));
    }

    public static async Task<IResult> Create(TodoItemDto request)
    {
        var aModel = new TodoItem(Guid.NewGuid(), request.Text, false, DateTime.UtcNow);
        todos[aModel.Id] = aModel;
        return await Task.FromResult(Results.Created($"/task2/todos/{aModel.Id}", new
        {
            Data = aModel,
            Message = "Save TodoItem successfully",
            StatusCode = 201
        }));
    }

    public static async Task<IResult> Update(Guid id, TodoItemDto request)
    {
        if (todos.TryGetValue(id, out var existing))
        {
            var aModel = existing with { Text = request.Text, IsComplete = request.IsComplete };
            todos[id] = aModel;
            return await Task.FromResult(Results.Ok(new
            {
                Data = aModel,
                Message = "Updated TodoItem successfully",
                StatusCode = 200
            }));
        }
        return await Task.FromResult(Results.NotFound(new { Message = "TodoItem not found", StatusCode = 404 }));
    }

    public static async Task<IResult> Delete(Guid id)
    {
        return await Task.FromResult(todos.TryRemove(id, out _)
            ? Results.NoContent()
            : Results.NotFound(new { Message = "TodoItem not found", StatusCode = 404 }));
    }

}
