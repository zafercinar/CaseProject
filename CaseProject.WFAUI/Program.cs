using AutoMapper;
using CaseProject.Business.MappingProfiles;
using CaseProject.Business.Services.Abstract;
using CaseProject.Business.Services.Concrete;
using CaseProject.DataAccess.Contexts;
using CaseProject.DataAccess.Repositories.Abstract;
using CaseProject.DataAccess.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CaseProject.WFAUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            // Add DbContext
            services.AddDbContext<CaseProjectDbContext>(opt => opt.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CaseProjectDb;Trusted_Connection=True;MultipleActiveResultSets=true"));
           
            services.AddScoped<IWordRepository, WordRepository>();
            services.AddTransient<IWordService, WordService>();
            services.AddSingleton<IRandomTextService, RandomTextService>();

            //Auto Mapper Profile
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new WordMappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<MainForm>();

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var mainForm = serviceProvider.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }

        }
    }
}