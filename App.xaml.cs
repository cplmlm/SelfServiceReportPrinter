using Microsoft.Extensions.DependencyInjection;
using SelfServiceReportPrinter.ViewModel;
using System.Windows;

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
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the current <see cref="App"/> instance in use
        /// </summary>
        public new static App Current => (App)Application.Current;

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
            services.AddTransient<KeyPressViewModelCommunityToolkit>();
            services.AddTransient<KeyPressViewModelPrism>();
            services.AddTransient<KeyPressViewModel>();
            services.AddTransient(sp=>new MainWindow() { DataContext=sp.GetRequiredService<KeyPressViewModelCommunityToolkit>()});
            return services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow= Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
        }
    }
}
