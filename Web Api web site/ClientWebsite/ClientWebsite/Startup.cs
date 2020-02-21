using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ClientWebsite.Data;
using ClientWebsite.Service;
using ClientWebsite.Service.Customer_Report;
using ClientWebsite.Service.InvoiceLists;

namespace ClientWebsite
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "http://localhost:4200";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => { builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials(); });
            });
            services.AddCors();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            services.AddEntityFrameworkSqlServer()
                .AddDbContext<OrderManagementDbContext>((serviceProvider, options) =>
                    options.UseSqlServer(Configuration.GetConnectionString("RoleManagementDbContext"))
                           .UseInternalServiceProvider(serviceProvider));


            #region add scope for DI
            services.AddScoped<ICustomer_Report, CustomerReportService>();
            services.AddScoped<IInvoiceList, InvoiceListService>();
            #endregion

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(builder => builder
       .AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader()
       .AllowCredentials());


            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

