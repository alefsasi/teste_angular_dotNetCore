using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TesteConfitec.Repository;
using TesteConfitec.Repository.Implementacao;
using TesteConfitec.Services;
using TesteConfitec.Services.Implementacao;

namespace TesteConfitec
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
            var connection = Configuration["AppSettings:ConnectionSQLServer"];
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<Contexto>(
                    options => options.UseSqlServer(connection)
            );

            services.AddControllers();
            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Desafio Confitec",
                        Version = "v1",
                        Description = "API REST criada com o ASP.NET Core 3.1 para o desafio da Confitec",
                    });
            });
            services.AddCors(options => {
                options.AddPolicy("myPolicy", builder => builder
                 .WithOrigins("http://localhost:4200/")
                 .SetIsOriginAllowed((host) => true)
                 .AllowAnyMethod()
                 .AllowAnyHeader());
            });

            /* Injeção de dependencias */
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IEscolaridadeService, EscolaridadeService>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IEscolaridadeRepository, EscolaridadeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio Confitec");
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("myPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
