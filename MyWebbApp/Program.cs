using MyWebbApp;
using MyWebbApp.Pages;
using MyWebbApp.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient<F1PredictorController>();

// 1. Dodanie sesji do kontenera us³ug.
builder.Services.AddDistributedMemoryCache(); // add cache
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // how long session will be alive
    options.Cookie.HttpOnly = true; 
    options.Cookie.IsEssential = true; 
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 2. Dodanie middleware obs³uguj¹cego sesje.
app.UseSession();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
