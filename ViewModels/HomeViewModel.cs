using CommunityToolkit.Mvvm.Input;
using SelfServiceReportPrinter.Helper;

namespace SelfServiceReportPrinter.ViewModels
{
    public partial class HomeViewModel : ViewModelBase
    {
        private readonly NavigationService navigationService;
 

        public HomeViewModel(NavigationService navigationService)
        {
            this.navigationService = navigationService;

        }
    }
}
