using API.MeetingPlanner.Frontier.Entities;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace API.MeetingPlanner
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddCors(o => o.AddPolicy("ApiPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
            }));
            SetupSwagger(services);
            Map.Map.SetupDependenceInjection(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IServiceProvider serviceProvider
        )
        {
            app.UseDeveloperExceptionPage();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "API Meeting Planner");
                c.DocumentTitle = "Meeting Planner";
                c.DocExpansion(DocExpansion.None);
            });

            app.UseHttpsRedirection();
            app.UseCors("ApiPolicy");
            app.UseMvc();
        }
        private static void SetupSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.CustomOperationIds(e => $"{string.Join("", e.ActionDescriptor.RouteValues.Values)}");
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Meeting Planner",
                    Version = "v1"
                });
            });
        }
    }
}
