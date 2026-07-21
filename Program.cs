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

app.MapGet("/",()=>new{name = "Fitness App",version = "1.0", endpoints = new[]{"/tasks"}});

app.MapGet("/health", () => new
{
    status = "ok"
});


app.Run();

class TaskItem
{
    public int Id{get;set;}
    public string Title{get;set;} = string.Empty;
    public bool Done{get;set;}
}