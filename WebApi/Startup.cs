using ApplicationCore.Interfaces.RepositoryInterfaces;
using ApplicationCore.Interfaces.ServiceInterfaces;
using ApplicationCore.Resources;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SqlInfrastructure.Repositories;

namespace WebApi
{
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration {
        get;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors();
        services.AddControllers();
        services.AddSwaggerGen();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<ICounterAgentRepository, CounterAgentRepository>();
        services.AddTransient<IStaffMemberRepository, StaffMemberRepository>();
        services.AddTransient<IWarehouseRepository, WarehouseRepository>();
        services.AddTransient<IMeasurementUnitRepository, MeasurementUnitRepository>();
        services.AddTransient<IManufacturerRepository, ManufacturerRepository>();
        services.AddTransient<IProductService, ProductService>();
        services.AddTransient<IMeasurementUnitService, MeasurementUnitService>();
        services.AddTransient<IManufacturerService, ManufacturerService>();
        services.AddTransient<ICounterAgentService, CounterAgentService>();
        services.AddTransient<IStaffMemberService, StaffMemberService>();
        services.AddTransient<IWarehouseService, WarehouseService>();

        services.AddAutoMapper(typeof(MappingProfile));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        // global cors policy
        app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true) // allow any origin
                    .AllowCredentials()); // allow credentials

        // Enable middleware to serve generated Swagger as a JSON endpoint.
        app.UseSwagger();

        // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
        // specifying the Swagger JSON endpoint.
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pharmacy Api V1");
        });
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
