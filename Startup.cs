using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using beermeAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace beermeAPI
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BeerMeContext>(ops => ops.UseMySQL("Server=localhost; Port=3306; Database=beerme; Uid=root;"));
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }
    }
}
