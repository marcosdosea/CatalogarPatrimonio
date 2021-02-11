using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service;

namespace CatalogarPatrimonioWEB
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
            services.AddControllersWithViews();
            services.AddDbContext<CatalogarPatrimonioContext>(options =>
                options.UseMySQL(
                    Configuration.GetConnectionString("CatalogarPatrimonioConnection")));

            services.AddTransient<IAdicionarGestorService, AdicionarGestorService>();
            services.AddTransient<IAlmoxarifadoService, AlmoxarifadoService>();
            services.AddTransient<IDialogoservicoService, DialogoservicoService>();
            //services.AddTransient<IDisponibilidadeService, DisponibilidadeService>();
            services.AddTransient<IEmpresaService, EmpresaService>();
            services.AddTransient<IEntradaService, EntradaService>();
            services.AddTransient<IEntradamaterialService, EntradamaterialService>();
            services.AddTransient<IFornecedorService, FornecedorService>();
            services.AddTransient<ILocalService, LocalService>();
            services.AddTransient<IMaterialService, MaterialService>();

            //services.AddTransient<IMaterialenradaService, MaterialentradaService>();
            services.AddTransient<IPatrimonioService, PatrimonioService>();
            services.AddTransient<IPessoaService, PessoaService>();
            services.AddTransient<IPredioService, PredioService>();
            services.AddTransient<IServicoService, ServicoService>();
            //services.AddTransient<IServicomaterialService, ServicomaterialService>();
            //services.AddTransient<IStatusservicoService, StatusservicoService>();
            //services.AddTransient<ITipomaterialService, TipomaterialService>();
            services.AddTransient<ITipopatrimonioService, TipopatrimonioService > ();
            services.AddTransient<ITipoServicoService, TipoServicoService>();
            //services.AddTransient<ITransferenciaService, TransferenciaService>();
            //services.AddTransient<ITransferenciamaterialService, TransferenciamaterialService>();

            services.AddAutoMapper(typeof(Startup).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
