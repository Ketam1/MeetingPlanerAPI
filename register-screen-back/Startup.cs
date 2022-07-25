using API.RegisterScreen.Frontier.Entities;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace API.RegisterScreen
{
    public class Startup
    {
        public static List<UserEntity> UserDatabase = new List<UserEntity>();
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
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
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "API Register Screen");
                c.DocumentTitle = "Register Screen";
                c.DocExpansion(DocExpansion.None);
            });

            app.UseHttpsRedirection();
            app.UseMvc();

        }
        private static void SetupSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.CustomOperationIds(e => $"{string.Join("", e.ActionDescriptor.RouteValues.Values)}");
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Register Screen",
                    Version = "v1"
                });
            });
        }
    }
}
