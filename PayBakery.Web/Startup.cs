using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PayBakery.Domain.Core;
using PayBakery.Domain.Core.Interfaces;
using PayBakery.Proxy;

namespace PayBakery.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
            });

            services.AddSingleton<HttpClient>();
            services.AddTransient<IBankAccount, BankAccountManager>();
            services.AddTransient<IRecipent, RecipentManager>();
            services.AddTransient<ITransfer, TransferManager>();
            services.AddTransient(typeof(HttpRequestClient), t =>
            {
                var httpClient = t.GetService<HttpClient>();
                return new HttpRequestClient(httpClient, Configuration);
            });
            services.AddTransient(typeof(BankAccountClient), a =>
            {
                var httpRequestClient = a.GetService<HttpRequestClient>();
                return new BankAccountClient(httpRequestClient, Configuration);
            });
            services.AddTransient(typeof(TransferClient), b =>
            {
                var httpRequestClient = b.GetService<HttpRequestClient>();
                return new TransferClient(httpRequestClient, Configuration);
            });
            services.AddTransient(typeof(RecipentClient), b =>
            {
                var httpRequestClient = b.GetService<HttpRequestClient>();
                return new RecipentClient(httpRequestClient, Configuration);
            });
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
