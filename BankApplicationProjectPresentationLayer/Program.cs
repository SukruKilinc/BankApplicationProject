using BankApplicationProjectBusinessLayer.Abstract;
using BankApplicationProjectBusinessLayer.Concrete;
using BankApplicationProjectDataAccessLayer.Abstract;
using BankApplicationProjectDataAccessLayer.Concrete;
using BankApplicationProjectDataAccessLayer.EntityFramework;
using BankApplicationProjectEntityLayer.Concrete;
using BankApplicationProjectPresentationLayer.Models;

namespace BankApplicationProjectPresentationLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Context>();
            builder.Services.AddIdentity<AppUser,Approle>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>();

            builder.Services.AddScoped<ICustomerAccountProcessDal, EfCustomerAccountProcessDal>();
            builder.Services.AddScoped<ICustomerAccountProcessService, CustomerAccountProcessManager>();

            builder.Services.AddScoped<ICustomerAccountDal, EfCustomerAccountDal>();
            builder.Services.AddScoped<ICustomerAccountService, CustomerAccountManager>();

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
        }
    }
}