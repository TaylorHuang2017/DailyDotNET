using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MockSchoolManagement.CustomerMiddlewares.Utils;
using MockSchoolManagement.DataRepositories;
using MockSchoolManagement.Infrastructure;
using MockSchoolManagement.Models;

namespace MockSchoolManagement
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
           
            //???Sqlserver????????IConfiguration????????????????????"MockStudentDBConnection"?????????????????
            services.AddDbContextPool<AppDbContext>(
            options => options.UseSqlServer(_configuration.GetConnectionString("MockStudentDBConnection")));

            services.AddControllersWithViews(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                              .RequireAuthenticatedUser()
                                              .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            }
            ).AddXmlSerializerFormatters();

          
            services.AddScoped<IStudentRepository, SQLStudentRepository>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
               
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()              
                .AddEntityFrameworkStores<AppDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //?????????Development serve Developer Exception Page
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } 
            //else???????????????????????????????????
            else if (env.IsStaging() || env.IsProduction() || env.IsEnvironment("UAT"))
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }
            
            //???????????????????????????????????????
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseRouting();
         
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }



        // app.UseMvcWithDefaultRoute();
        //  app.UseMvc();



        ////else???????????????????????????????????
        //else if (env.IsStaging() || env.IsProduction() || env.IsEnvironment("UAT"))
        //{
        //    app.UseExceptionHandler("/Error");
        //}

        //routeBuilder.MapGet("hello/{name}", context =>
        //{
        //    var name = context.GetRouteValue("name");
        //    // The route handler when HTTP GET "hello/<anything>" matches
        //    // To match HTTP GET "hello/<anything>/<anything>, 
        //    // use routeBuilder.MapGet("hello/{*name}"
        //    return context.Response.WriteAsync($"Hi, {name}!");
        //});



        //var trackPackageRouteHandler = new RouteHandler(context =>
        //{
        //    var routeValues = context.GetRouteData().Values;
        //    return context.Response.WriteAsync(
        //        $"Hello! Route values: {string.Join(", ", routeValues)}");
        //});

        //var routeBuilder = new RouteBuilder(app, trackPackageRouteHandler);

        //routeBuilder.MapRoute(
        //    "Track Package Route",
        //    "package/{operation:regex(^track|create$)}/{id:int}");

        //routeBuilder.MapGet("hello/{name}", context =>
        //{
        //    var name = context.GetRouteValue("name");
        //    // The route handler when HTTP GET "hello/<anything>" matches
        //    // To match HTTP GET "hello/<anything>/<anything>, 
        //    // use routeBuilder.MapGet("hello/{*name}"
        //    return context.Response.WriteAsync($"Hi, {name}!");
        //});

        //var routes = routeBuilder.Build();

        //app.UseRouter(routes);

        //app.UseEndpoints(endpoints =>
        //{
        //    endpoints.MapControllerRoute(
        //        name: "default",
        //        pattern: "{controller=Home}/{action=Index}/{id?}");
        //});



    }
}