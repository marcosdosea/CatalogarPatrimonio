using System;
using CatalogarPatrimonioWEB.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CatalogarPatrimonioWEB.Areas.Identity.IdentityHostingStartup))]
namespace CatalogarPatrimonioWEB.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityContext>(options =>
                    options.UseMySQL(
                        context.Configuration.GetConnectionString("CatalogarPatrimonioConnection")));

                services.AddDefaultIdentity<Pessoa>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<IdentityContext>();
            });
        }
    }
}