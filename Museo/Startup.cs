using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Museo.Models;
using Museo.Models.Repository;
using Museo.Models.Repository.Interfaces;
using Museo.Models.Security;
using Museo.Security;

namespace Museo
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
            services.AddDbContextPool<ApplicationDBContext>(options => 
                options.UseSqlServer(Configuration["Data:Project:ConnectionString"]));
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireNonAlphanumeric = false;  
                options.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<ApplicationDBContext>();

            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }).AddXmlSerializerFormatters();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ManageRolePolicy",
                    policy => policy.AddRequirements(new ManageEntriesRequirement("Modificar rol")));
                options.AddPolicy("ManageOtherUsersRolesPolicy",
                    policy => policy.AddRequirements(new ManageOtherUsersRolesRequirement()));
                options.AddPolicy("AddUserPolicy",
                    policy => policy.AddRequirements(new ManageEntriesRequirement("Añadir usuario")));
                options.AddPolicy("EditUserPolicy",
                    policy => policy.AddRequirements(new ManageEntriesRequirement("Editar usuario")));
                options.AddPolicy("DeleteUserPolicy",
                    policy => policy.AddRequirements(new ManageEntriesRequirement("Eliminar usuario")));
                options.AddPolicy("ManageVisitPolicy",
                    policy => policy.AddRequirements(new ManageEntriesRequirement("Modificar visita")));
                options.AddPolicy("ManageResidentPolicy",
                    policy => policy.AddRequirements(new ManageEntriesRequirement("Modificar residente")));
                options.AddPolicy("ManageActivityPolicy",
                    policy => policy.AddRequirements(new ManageEntriesRequirement("Modificar actividad")));
                options.AddPolicy("ManagePositionPolicy",
                    policy => policy.AddRequirements(new ManageEntriesRequirement("Modificar cargo")));
                options.AddPolicy("ManageAreaPolicy",
                    policy => policy.AddRequirements(new ManageEntriesRequirement("Modificar área")));
                options.AddPolicy("ManageNewsPolicy",
                    policy => policy.AddRequirements(new ManageEntriesRequirement("Modificar noticia")));
                options.AddPolicy("ManageAnualPlanPolicy",
                    policy => policy.AddRequirements(new ManageEntriesRequirement("Modificar plan anual")));

            });

            services.AddScoped<IAuthorizationHandler, CanManageClaimHandler>();
            services.AddScoped<IAuthorizationHandler, CanEditOtherUsersRolesHandler>();


            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IAnualPlanRepository, AnualPlanRepository>();
            services.AddScoped<IDocumentCategoryRepository, DocumentCategoryRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IIncidenceRepository, IncidenceRepository>();
            services.AddScoped<IIncidenceTypeRepository, IncidenceTypeRepository>();
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventTypeRepository, EventTypeRepository>();
            services.AddScoped<IEventThematicRepository, EventThematicRepository>();
            services.AddScoped<IEventPersonalityRepository, EventPersonalityRepository>();
            services.AddScoped<IEventOrganizerRepository, EventOrganizerRepository>();
            services.AddScoped<IEORepository, EORepository>();
            services.AddScoped<IPersonalityInEventRepository, PersonalityInEventRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IResidentRepository, ResidentRepository>();
            services.AddScoped<ITypeActRepository, TypeActRepository>();            
            services.AddScoped<IVisitRepository, VisitRepository>();
            services.AddScoped<IResidentVisitRepository, ResidentVisitRepository>();
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
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
