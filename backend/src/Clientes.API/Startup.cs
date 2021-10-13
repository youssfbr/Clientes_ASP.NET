using Clientes.Application;
using Clientes.Application.Interfaces;
using Clientes.Persistence;
using Clientes.Persistence.Context;
using Clientes.Persistence.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Clientes.API
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
            services.AddDbContext<DataContext>(
                context => context.UseSqlServer(Configuration.GetConnectionString("Default"))
            );
            services.AddControllers()
                    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = 
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );

            services.AddScoped<IGeralPersist, GeralPersist>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClientePersist, ClientePersist>();
            services.AddScoped<IBairroService, BairroService>();
            services.AddScoped<IBairroPersist, BairroPersist>();
            services.AddScoped<ICidadeService, CidadeService>();
            services.AddScoped<ICidadePersist, CidadePersist>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IEnderecoPersist, EnderecoPersist>();
            services.AddScoped<IEquipamentoService, EquipamentoService>();
            services.AddScoped<IEquipamentoPersist, EquipamentoPersist>();
            services.AddScoped<IEquipamentoMarcaService, EquipamentoMarcaService>();
            services.AddScoped<IEquipamentoMarcaPersist, EquipamentoMarcaPersist>();
            
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Clientes.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clientes.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
