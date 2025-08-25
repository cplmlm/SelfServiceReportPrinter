using System.Windows;

namespace SelfServiceReportPrinter.Services
{
    internal class MessageBoxService : IMessageBoxService
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
