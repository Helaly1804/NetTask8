using Microsoft.EntityFrameworkCore;
using NetTask8.BusinessLogic.Profiles;
using NetTask8.BusinessLogic.Services;
using NetTask8.DataAccess.Data.Context;
using NetTask8.DataAccess.Repositories.Approvals;
using NetTask8.DataAccess.Repositories.File;

namespace NetTask8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                options.UseLazyLoadingProxies();
            }
            );
            builder.Services.AddScoped<IFileRepository, FileRepository>();
            builder.Services.AddScoped<IApprovalRepository, ApprovalRepository>();
            builder.Services.AddScoped<IFileService, FileService>();           
            builder.Services.AddScoped<IApprovalService, ApprovalService>();
            builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfiles()));
            builder.Services.AddSession();
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
            app.UseSession();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
