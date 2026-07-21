var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var tasks = new List<TaskItem>
{
    new TaskItem { Id = 1, Title = "Learn ASP.NET Core", Done = false },
    new TaskItem { Id = 2, Title = "Build a Minimal API", Done = false },
    new TaskItem { Id = 3, Title = "Push project to GitHub", Done = false }
};

//READ
app.MapGet("/tasks",()=>tasks).WithSummary("Get all tasks");

app.MapGet("/tasks/{id}",(int id) =>
{
    var task = tasks.FirstOrDefault(t=>t.Id==id);
    if(task is null)
    {
        return Results.NotFound(new
        {
            error = $"Tast with id: {id} is not found!"
        });
    }
    return Results.Ok(task);
});

//CREATE
app.MapPost("/tasks",(CreateTaskRequestDTO requestDTO) =>
{
    if (string.IsNullOrWhiteSpace(requestDTO.Title))
    {
        return Results.BadRequest(new
        {
            error = "Title is required!"
        });
    }
    var newTask = new TaskItem
    {
        Id = tasks.Any() ? tasks.Max(t=>t.Id)+1 :1,
        Title = requestDTO.Title,
        Done = false
    };
    tasks.Add(newTask);
    return Results.Created($"/tasks/{newTask.Id}",newTask);
});

app.Run();

class TaskItem
{
    public int Id{get;set;}
    public string Title{get;set;} = string.Empty;
    public bool Done{get;set;}
}
class CreateTaskRequestDTO
{
    public string? Title{get;set;}
}