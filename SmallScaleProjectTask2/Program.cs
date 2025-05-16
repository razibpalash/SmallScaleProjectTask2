using SmallScaleProjectTask2.Endpoints;

var builder = WebApplication.CreateBuilder(args);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Logging
app.Use(async (context, next) =>
{
    await next();
    Console.WriteLine($"{context.Request.Method} {context.Request.Path} {context.Response.StatusCode}");
});
// Enable Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Small Scale Project Task2");

// Map endpoints from the Controllers file
app.MapTodoItemEndpoints();

app.Run("http://localhost:5000");
