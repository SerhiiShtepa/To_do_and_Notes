using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using To_Do_and_Notes.Data;
using To_Do_and_Notes.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

#region Для Database
builder.Services.AddDbContext<ToDoAndNotesDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
#endregion

#region Для Session у звичайних Razor Page

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
#endregion

#region Для Razor Component
builder.Services.AddHttpContextAccessor(); // для доступу до даних сесії
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<FolderService>();
builder.Services.AddTransient<TaskService>();
builder.Services.AddTransient<NoteService>();
builder.Services.AddTransient<UserService>();
#endregion

var app = builder.Build();

#region Для Session у звичайних Razor Page
app.UseSession();
#endregion

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseDefaultFiles(new DefaultFilesOptions()
//{
//    DefaultFileNames = new[] { "signin.html" }
//});
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapRazorPages();
//    endpoints.MapDefaultControllerRoute();
//    endpoints.MapFallbackToPage("/SignIn");
//});
//builder.Services.AddMvc().AddRazorPagesOptions(options =>
//{
//    options.Conventions.AddPageRoute("/SignIn", "");
//});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapBlazorHub();

app.MapRazorPages();

app.Run();