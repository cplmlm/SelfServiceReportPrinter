using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SelfServiceReportPrinter.Helper
{
    // 放到任意命名空间下，比如 SelfServiceReportPrinter.Helpers
    public class StatusToVisibilityConverter : IValueConverter
    {
        // 当状态=目标值时返回 Visible，否则 Collapsed
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = value?.ToString();
            return string.Equals(status, "未打印", StringComparison.OrdinalIgnoreCase) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotSupportedException();
    }
}
