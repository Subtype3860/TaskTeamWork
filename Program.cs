using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskTeamWork.Data;
using TaskTeamWork.Models;
using Microsoft.Extensions.DependencyInjection;

namespace TaskTeamWork;
class Program
{

    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //ад
        string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection))
        .AddIdentity<User, IdentityRole>(opts =>
        {
            opts.Password.RequiredLength = 5;
            opts.Password.RequireNonAlphanumeric = false;
            opts.Password.RequireLowercase = false;
            opts.Password.RequireUppercase = false;
            opts.Password.RequireDigit = false;
        })
            .AddEntityFrameworkStores<ApplicationDbContext>();

        var mapperConfig = new MapperConfiguration((v) =>
        {
            v.AddProfile(new MappingProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();

        builder.Services.AddSingleton(mapper);

        builder.Services.AddControllers(
    options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

        builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
       //builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
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
        //app.MapRazorPages();

        app.Run();
    } 
}