using Microsoft.Extensions.DependencyInjection;
using SelfServiceReportPrinter.Services;
using SelfServiceReportPrinter.ViewModel;
using SelfServiceReportPrinter.ViewModels;
using SelfServiceReportPrinter.Views;
using System.ComponentModel;
using System.Windows;
using System.Xml.Linq;

namespace SelfServiceReportPrinter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();
           // this.InitializeComponent();
        }

        /// <summary>
        /// Gets the current <see cref="App"/> instance in use
        /// </summary>
        public static new  App Current => (App)Application.Current;

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
        /// </summary>
        public IServiceProvider Services { get; }

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<MainWindow>();
            services.AddTransient<KeyPressViewModelPrism>();
            services.AddTransient<KeyPressViewModel>();
            services.AddSingleton<MainViewModel>();
            services.AddTransient<PrintViewModel>();
            services.AddSingleton<NavigationService>();
            services.AddTransient<KeyPressViewModelCommunityToolkit>();
            services.AddTransient<HomeViewModel>();
            services.AddSingleton<ReportService>();
            // services.AddTransient(sp => new MainWindow1(MainViewModel1) { DataContext=sp.GetRequiredService<MainViewModel>() });
            //services.AddTransient(sp => new MainPage() { DataContext=sp.GetRequiredService<KeyPressViewModelCommunityToolkit>() });
            //services.AddTransient(sp => new PrintPage() { DataContext=sp.GetRequiredService<PrintViewModel>() });
            return services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow= Services.GetRequiredService<MainWindow>();
            MainWindow?.Show();
        }
    }
}
