using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace BlogProjesi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // yeni sisteme göre benim eklediklerim.
            builder.Services.AddDbContext<Context>();
            builder.Services.AddIdentity<AppUser, AppRole>
           (x =>
           {
               x.Password.RequireUppercase = false;
               x.Password.RequireNonAlphanumeric = false;
           }

                ).AddEntityFrameworkStores<Context>();
            builder.Services.AddControllersWithViews();



            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(200);
                options.AccessDeniedPath = new PathString("/Login/AccessDenied");
                options.LoginPath = "/Login/Index/";
                options.SlidingExpiration = true; 
            });
            /*x=>{
            x.Password.RequireUppercase = false;
            x.Password.RequireNonAlphanumeric = false;
             }*/
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }



            app.UseHttpsRedirection();


            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseStatusCodePagesWithReExecute("/ErorPage/Eror1", "?code={0}");
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
               name: "areas",
               pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
             );

                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
            app.Run();






















            //yorumda gördüm orjinale ait deðil


            //builder.Services.AddMvc(config =>
            // {
            //     var policy = new AuthorizationPolicyBuilder()
            //                     .RequireAuthenticatedUser()
            //                     .Build();
            //     config.Filters.Add(new AuthorizeFilter(policy));
            // });  



            //             public IConfiguration Configuration { get; }

            //public void ConfigureServices(IServiceCollection services)
            //{

            //    services.AddControllersWithViews();
            //    services.AddSession();

            //    services.AddMvc(confing =>
            //    {
            //        var policy = new AuthorizationPolicyBuilder()
            //        .RequireAuthenticatedUser()
            //        .Build();
            //        confing.Filters.Add(new AuthorizeFilter(policy));

            //    });

            //} 


            //  app.UseSession();

        }

    }
}










/* program.cs geldiðinde ilk böyle geliyor. 
 * 
 *  public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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
*/