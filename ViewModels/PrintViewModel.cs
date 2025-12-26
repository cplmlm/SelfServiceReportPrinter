using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SelfServiceReportPrinter.Models;
using SelfServiceReportPrinter.Services;
using SelfServiceReportPrinter.Views;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace SelfServiceReportPrinter.ViewModels
{
    public partial class PrintViewModel : ViewModelBase
    {
        private readonly NavigationService navigationService;
        private readonly ReportService reportService;

        [ObservableProperty]
        private int countDown = 30;   //默认 30 秒

        [ObservableProperty]
        private string countDownText = string.Empty;
        private DispatcherTimer? _timer;
        private ObservableCollection<Report> datalist = new ObservableCollection<Report>();
        public ObservableCollection<Report> Datalist
        {
            get { return datalist; }
            set
            {
                datalist = value;
                OnPropertyChanged();//属性通知
            }
        }

        public PrintViewModel(NavigationService navigationService,ReportService reportService)
        {
            this.navigationService = navigationService;
            this.reportService =reportService;
            GetData(this.reportService.CardNumber);
            StartCountdown(); //启动倒计时
        }


        private void StartCountdown()
        {
            CountDownText = TimeSpan.FromSeconds(CountDown).ToString(@"mm\:ss");
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += (_, _) =>
            {
                if (CountDown > 0)
                {
                    CountDown--;
                    CountDownText = TimeSpan.FromSeconds(CountDown).ToString(@"mm\:ss");
                }
                else
                {
                    _timer.Stop();
                    GoBack();
                }
            };
            _timer.Start();
        }


        [RelayCommand]
        private void GoBack()
        {
            _timer?.Stop();
            navigationService.NavigateTo<KeyPressViewModelCommunityToolkit>();
        }
        [RelayCommand]
        private void Print()
        {
            _timer?.Stop();
            navigationService.NavigateTo<KeyPressViewModelCommunityToolkit>();
        }
        private void GetData(string? cardNumber)
        {
            Datalist.Add(new Report() { Name = "血常规", Status = "未打印" });
            Datalist.Add(new Report() { Name = "尿常规", Status = "已打印" });
            Datalist.Add(new Report() { Name = "肝功能", Status = "未打印" });
            Datalist.Add(new Report() { Name = "肾功能", Status = "已打印" });
        }
    }
}
