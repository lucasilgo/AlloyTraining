using AlloyTraining.Business.Initializers;
using EPiServer.Cms.Shell;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Routing;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ServiceDescriptor = Microsoft.Extensions.DependencyInjection.ServiceDescriptor;

namespace AlloyTraining
{
    public class Startup
    {
        private readonly IWebHostEnvironment _webHostingEnvironment;

        public Startup(IWebHostEnvironment webHostingEnvironment)
        {
            _webHostingEnvironment = webHostingEnvironment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            if (_webHostingEnvironment.IsDevelopment())
            {
                AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(_webHostingEnvironment.ContentRootPath, "App_Data"));

                services.Configure<SchedulerOptions>(options => options.Enabled = false);

                services.TryAddEnumerable(ServiceDescriptor.Singleton(
                    typeof(IFirstRequestInitializer), typeof(AddPagesInitializer)));
            }

            services.Configure<DisplayOptions>(options =>
            {
                options.Add(id: SiteTags.Full, name: "Full", tag: SiteTags.Full);
                options.Add(id: SiteTags.Wide, name: "Wide", tag: SiteTags.Wide);
                options.Add(id: SiteTags.Narrow, name: "Narrow", tag: SiteTags.Narrow);
            });

            services
                .AddCmsAspNetIdentity<ApplicationUser>()
                .AddCms()
                .AddFind()
                .AddAdminUserRegistration()
                .AddEmbeddedLocalization<Startup>()
                .AddDetection();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapContent();
            });
        }
    }
}