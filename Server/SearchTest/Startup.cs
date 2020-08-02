using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SearchTest
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to add
        ///  services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddControllers();

           // services.AddCors(); // добавляем сервисы CORS

            services.AddCors( options =>
            {
                options.AddPolicy( "AllowSpecificOrigin", builder =>
                     builder.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin()
                );
            } );


        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to 
        /// configure the HTTP request pipeline. 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
        {
            if( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //             // подключаем CORS
            //             app.UseCors( builder => //.builder.AllowAnyOrigin() 
            //             builder.AllowAnyOrigin()
            //                    .AllowAnyMethod()
            //                   .AllowAnyHeader()
            //                   //.AllowCredentials() 
            //                   );

            app.UseCors( "AllowSpecificOrigin" );

            app.UseAuthorization();

            app.UseEndpoints( endpoints =>
             {
                 endpoints.MapControllers();
             } );
        }
    }
}
