using AuthorBookWebApp.BusinessLogic.Implementation;
using AuthorBookWebApp.BusinessLogic.Interfaces;
using AuthorBookWebApp.DbData;
using AuthorBookWebApp.Models;
using AuthorBookWebApp.Profiles;

namespace AuthorBookWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AbDbContext>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddScoped<IAuthorCrud<AuthorViewModel>, AuthorCrud>();
            builder.Services.AddScoped<IBookCrud<BookViewModel>, BookCrud>();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}