using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEA.AccountCreation.Collabaration.Abstraction;
using WEA.AccountCreation.Collabaration.Realization;
using WEA.AccountCreation.Gateway.Abstraction;
using WEA.AccountCreation.Gateway.Realization;
using WEA.AuthenticationPersistance.Collabration.Abstraction;
using WEA.AuthenticationPersistance.Collabration.Realization;
using WEA.AuthenticationPersistance.Gateway.Abstraction;
using WEA.AuthenticationPersistance.Gateway.Realization;
using WEA.AuthorisedNGO.Collabration.Abstraction;
using WEA.AuthorisedNGO.Collabration.Realization;
using WEA.AuthorisedNGO.Gateway.Abstraction;
using WEA.AuthorisedNGO.Gateway.Realization;
using WEA.AuthorisedUser.Collabration.Abstraction;
using WEA.AuthorisedUser.Collabration.Realization;
using WEA.AuthorisedUser.Gateway.Abstraction;
using WEA.AuthorisedUsersFilter.Gateway.Realization;
using WEA.CourseFilter.Collabration.Abstraction;
using WEA.CourseFilter.Collabration.Realization;
using WEA.CourseFilter.Gateway.Abstraction;
using WEA.CourseFilter.Gateway.Realization;
using WEA.CoursePersistance.Collabaration.Abstraction;
using WEA.CoursePersistance.Collabaration.Realization;
using WEA.CoursePersistance.Gateway.Abstraction;
using WEA.CoursePersistance.Gateway.Realization;
using WEA.FAQServices.Collabration.Abstraction;
using WEA.FAQServices.Collabration.Realization;
using WEA.FAQServices.Gateway.Abstraction;
using WEA.FAQServices.Gateway.Realization;
using WEA.FinanceAccount.Collabration.Abstraction;
using WEA.FinanceAccount.Collabration.Realization;
using WEA.FinanceAccount.Gateway.Abstraction;
using WEA.Financial.Account.Gateway.Repository;
using WEA.Persistance.WEADbContext;
using WEA.Profile.Collabaration.Abstraction;
using WEA.Profile.Collabaration.Realization;
using WEA.Profile.Gateway.Abstraction;
using WEA.Profile.Gateway.Realization;

namespace WEA_DEV
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<WEAContext>(options => 
            {
                options.UseSqlServer(Configuration.GetConnectionString("WEA_Connection"));
            });
            services.AddScoped<IAccountCreationPersistance, AccountCreationPersistance>();
            services.AddScoped<IAccountCreationRepository, AccountCreationRepository>();
            services.AddScoped<IAuthenticationPersistance, AuthenticationPersistance>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<IProfilePersistance, ProfilePersistance>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<ICoursePersistance, CoursePersistance>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IFAQPersistance, FAQPersistance>();
            services.AddScoped<IFAQRepository, FAQRepository>();
            services.AddScoped<ICourseFilterPersistance, CourseFilterPersistance>();
            services.AddScoped<ICourseFilterRepository, CourseFilterRepository>();
            services.AddScoped<IFinancialPersistance, FinancialPersistance>();
            services.AddScoped<IFinancialRepository, FinancialAccountRepository>();

            services.AddScoped<INGODetailPersistance, NGODetailPersistance>();
            services.AddScoped<INGODetailRepository, NGODetailRepository>();
            services.AddScoped<IAuthoriseUserPersistance, AuthoriseUserPersistance>();
            services.AddScoped<IAuthoriseUserRepository, AuthoriseUserRepository>();
            services.AddSession();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Authentication}/{action=Index}/{id?}");
            });
        }
    }
}
