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
            services.AddDbContext<BeerMeContext>(ops => ops.UseMySQL("Server=mysql://bf6d7af703f0b8:00e6550b@us-cdbr-iron-east-02.cleardb.net/heroku_56ce30671474616?reconnect=true; Database=beerme; Uid=bf6d7af703f0b8; Password=00e6550b;"));
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
