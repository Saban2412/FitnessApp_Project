var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Task API v1");
});

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

//UPDATE
app.MapPut("/tasks/{id}",(int id, UpdateTaskRequestDTO requestDTO) =>
{
    var task = tasks.FirstOrDefault(t=>t.Id==id);
    if(task is null)
    {
        return Results.NotFound(new
        {
            error = $"Task with id: {id} is not found!"
        });
    }
    if(requestDTO.Title is null && requestDTO.Done is null)
    {
       return Results.BadRequest(new
        {
            error = "At least one filed must be provided!"
        });
    }
    if(requestDTO.Title is not null)
    {
        if (string.IsNullOrWhiteSpace(requestDTO.Title))
        {
           return Results.BadRequest(new{error = "Title is required!"});
        }
        task.Title = requestDTO.Title;
    }
    if(requestDTO.Done is not null)
    {
        task.Done=requestDTO.Done.Value;
    }
    return Results.Ok(task);
}).WithSummary("Update a task.");

//DELETE
app.MapDelete("/tasks/{id}",(int id) =>
{
   var task = tasks.FirstOrDefault(t=>t.Id==id);

   if(task is null){
       return Results.NotFound(new{
            error=$"Task with id {id} is not found"
            });
    }; 
    tasks.Remove(task);
    return Results.NoContent();
}).WithSummary("Delete a task");
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
class UpdateTaskRequestDTO
{
    public string? Title{get;set;}
    public bool? Done{get;set;}
}