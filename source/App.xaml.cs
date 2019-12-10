using Microsoft.Extensions.Configuration;
using Prism.Ioc;
using PrismApplicationTemplate.Commands;
using PrismApplicationTemplate.Infrastructure;
using PrismApplicationTemplate.Views;
using System.IO;
using System.Threading;
using System.Windows;

namespace PrismApplicationTemplate
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App
	{
		public static Mutex instanceMutex;
		public IConfiguration Configuration { get; private set; }

		protected override Window CreateShell()
		{
			return Container.Resolve<MainWindow>();
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			bool createdNew = true;
			instanceMutex = new Mutex(true, System.Reflection.Assembly.GetEntryAssembly().GetName().Name, out createdNew);
			if (!createdNew)
			{
				Current.Shutdown();
				return;
			}

			Configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddYamlFile("config.yaml", optional: false)
				.Build();

			base.OnStartup(e);
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{

			//!REGISTER SERVICES
			#region SERVICES
			containerRegistry.RegisterInstance<IConfiguration>(Configuration);
			containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();
			#endregion

			#region VIEWS FOR NAVIGATION
			containerRegistry.RegisterForNavigation<MainView>(Pages.MainPage);
			#endregion

		}

		protected override void ConfigureViewModelLocator()
		{
			base.ConfigureViewModelLocator();

			//Connect views with view models (just if view not in Views folder and viewModel not in ViewModel folder, or names are not correct)
			//xViewModelLocationProvider.Register<MainWindow, MainWindowViewModel>();
		}

		private void OnExit(object sender, ExitEventArgs e)
		{
			//empty
		}
	}
}
