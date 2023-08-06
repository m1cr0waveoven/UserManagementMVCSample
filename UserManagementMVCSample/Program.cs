using Microsoft.AspNetCore.Authentication.Cookies;
using UserManagementMVCSample.Core.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Account/Login/";
        });
builder.Services.AddKendo();
builder.Services.AddCsvReaderWithFactory();
builder.Services.AddCsvWriterWithFactory();
builder.Services.AddSingleton<IDataAccess>(x => new DataAccess(x.GetService<ICsvReaderFactory>()!, x.GetService<ICsvWriterFactory>()!, "people.csv"));
builder.Services.AddControllersWithViews()
            // Maintain property names during serialization.
            // See: https://github.com/aspnet/Announcements/issues/194
            .AddJsonOptions(options =>
                options.JsonSerializerOptions.PropertyNamingPolicy = null);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
