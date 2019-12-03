using AgendaMedica.Data;
using AgendaMedica.Data.Repositories;
using AgendaMedica.Data.UoW;
using AgendaMedica.Domain.Identity;
using AgendaMedica.Domain.Interfaces.Repositories;
using AgendaMedica.Domain.Interfaces.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Text;
using AgendaMedica.Domain.Services;
using AgendaMedica.Application.AutoMapper;
using AgendaMedica.Application.Interfaces;
using AgendaMedica.Application.AppServices;
using Microsoft.AspNetCore.Http;

namespace AgendaMedica.API
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
            services.AddDbContext<AgendaMedicaDbContext>(
                x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            IdentityBuilder builder = services.AddIdentityCore<AppUser>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 0;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(1);
                options.Lockout.MaxFailedAccessAttempts = 1000;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
            builder.AddEntityFrameworkStores<AgendaMedicaDbContext>();
            builder.AddRoleValidator<RoleValidator<Role>>();
            builder.AddRoleManager<RoleManager<Role>>();
            builder.AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Add application services.
            // services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors();

            services.AddAutoMapper();
            AutoMapperConfig.RegisterMappings();

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new Info
                {
                    Title = "Agenda Médica",
                    Version = "v1",
                    Contact = new Contact
                    {
                        Name = "Repositório do GitHub",
                        Url = "https://github.com/DaniloSI/Agenda-Medica"
                    }
                });
            });

            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Agenda Médica");
            });

            UpdateDatabase(app);
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<AgendaMedicaDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }

        private void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IEspecialidadeAppService, EspecialidadeAppService>();
            services.AddScoped<IAgendaAppService, AgendaAppService>();
            services.AddScoped<IConsultaAppService, ConsultaAppService>();

            // Domain
            services.AddScoped<IEspecialidadeService, EspecialidadeService>();
            services.AddScoped<IAgendaService, AgendaService>();
            services.AddScoped<IConsultaService, ConsultaService>();

            // Repository
            services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();
            services.AddScoped<IAgendaRepository, AgendaRepository>();
            services.AddScoped<IConsultaRepository, ConsultaRepository>();
            services.AddScoped<IUsuarioProfissionalRepository, UsuarioProfissionalRepository>();
            services.AddScoped<IUsuarioPacienteRepository, UsuarioPacienteRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<AgendaMedicaDbContext>();
        }
    }
}
