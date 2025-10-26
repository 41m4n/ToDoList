using Microsoft.EntityFrameworkCore;
using ToDoList.Components;
using ToDoList.Data;
using ToDoList.Repositories;
using ToDoList.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient();
builder.Services.AddDbContext<ToDoListDbContext>(options =>
    options.UseSqlite("Data Source=ToDoList.db"));

builder.Services.AddScoped<IToDoListRepositories, ToDoListRepositories>();
builder.Services.AddScoped<ToDoListService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ToDoListDbContext>();
    db.Database.EnsureCreated();
}

app.Run();
