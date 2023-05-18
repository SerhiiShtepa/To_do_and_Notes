using Microsoft.EntityFrameworkCore;
using To_Do_and_Notes.Data;
using To_Do_and_Notes.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

#region ��� Database
builder.Services.AddDbContext<ToDoAndNotesDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
#endregion

#region ��� Session � ��������� Razor Page

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
#endregion

#region ��� Razor Component
builder.Services.AddHttpContextAccessor(); // ��� ������� �� ����� ���
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<FolderService>();
builder.Services.AddTransient<TaskService>();
builder.Services.AddTransient<NoteService>();
#endregion

var app = builder.Build();

#region ��� Session � ��������� Razor Page
app.UseSession();
#endregion

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseDefaultFiles(new DefaultFilesOptions()
{
    DefaultFileNames = new[] {"index.html"}
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapBlazorHub();

app.MapRazorPages();

app.Run();