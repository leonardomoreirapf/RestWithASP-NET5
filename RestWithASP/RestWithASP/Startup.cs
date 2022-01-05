using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using RestWithASP.Business;
using RestWithASP.Business.Implementations;
using RestWithASP.Data.Converter.Contract;
using RestWithASP.Data.Converter.Implementations;
using RestWithASP.Model.Context;
using RestWithASP.Repository.Generic;
using Serilog;
using System;
using System.Collections.Generic;

namespace RestWithASP
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            //DataBase connection
            var connection = Configuration.GetConnectionString("MySQLConnectionString");
            services.AddDbContext<MySqlContext>(options => options.UseMySql(connection));
            //Migrations
            if (Environment.IsDevelopment())
            {
                MigrateDatabase(connection);
            }
            //Configuration others formatters
           
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("json",MediaTypeHeaderValue.Parse("application/json"));
            })
            //support application/xml
            .AddXmlDataContractSerializerFormatters();
   
            //API Versioning
            services.AddApiVersioning();
            //Dependency Injection
            services.AddScoped<IPersonBusiness, PersonBusiness>();
            services.AddScoped<IBookBusiness, BookBusiness>();
            services.AddScoped<IPersonConverter, PersonConverter>();
            services.AddScoped<IBookConverter, BookConverter>();

            //Dependency Injection Generic Repository
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void MigrateDatabase(string connection)
        {
            try
            {
                var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);
                var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> {"db/migrations","db/dataset"},
                    IsEraseDisabled = true
                };
                evolve.Migrate();
            }
            catch (Exception ex)
            {

                Log.Error("Database Migration Failed ", ex);
                throw;
            }
        }
    }
}
