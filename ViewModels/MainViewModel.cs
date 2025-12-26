using CommunityToolkit.Mvvm.ComponentModel;

namespace SelfServiceReportPrinter.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        private readonly NavigationService navigator;

        [ObservableProperty]
        private ViewModelBase? currentViewModel;

        public MainViewModel(NavigationService navigationService)
        {
            navigator = navigationService;

            navigator.CurrentViewModelChanged += () =>
            {
                CurrentViewModel = navigationService.CurrentViewModel;
            };
            navigator.NavigateTo<KeyPressViewModelCommunityToolkit>();
        }
    }
}
