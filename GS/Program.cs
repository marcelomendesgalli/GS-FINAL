using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;
using GS.Infrastructure;
using GS.Infrastructure.Repositories;
using GS.Application;

namespace GS // Certifique-se de que seu namespace está correto
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Configurando serviços
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

			builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
			builder.Services.AddScoped<ICadastroDispositivoRepository, CadastroDispositivoRepository>();
			builder.Services.AddScoped<IConfiguracaoRepository, ConfiguracaoRepository>();

			builder.Services.AddScoped<UsuarioService>();
			builder.Services.AddScoped<CadastroDispositivoService>();
			builder.Services.AddScoped<ConfiguracaoService>();

			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			// Configurando o pipeline de middleware
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
			name: "default",
			pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}