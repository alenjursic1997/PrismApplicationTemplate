using Prism.Mvvm;
using Prism.Regions;
using PrismApplicationTemplate.Infrastructure;
using PrismApplicationTemplate.Views;

namespace PrismApplicationTemplate.ViewModels
{
	public class MainWindowViewModel : BindableBase
	{
		private readonly IRegionManager _regionManager;

		private string _title = "Prism Application";

		public MainWindowViewModel(IRegionManager regionManager)
		{
			_regionManager = regionManager;
			_regionManager.RegisterViewWithRegion(Regions.ContentRegion, typeof(MainView));
			_regionManager.RequestNavigate(Regions.ContentRegion, Pages.MainPage);
		}


		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}
	}
}
