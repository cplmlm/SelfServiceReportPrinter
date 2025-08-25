using System.Windows;
using System.Windows.Controls;

namespace SelfServiceReportPrinter;


public static class TextBoxSelectionHelper
{
    public static readonly DependencyProperty SelectionStartProperty =
        DependencyProperty.RegisterAttached(
            "SelectionStart",
            typeof(int),
            typeof(TextBoxSelectionHelper),
            new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectionStartChanged));

    public static int GetSelectionStart(DependencyObject obj) => (int)obj.GetValue(SelectionStartProperty);
    public static void SetSelectionStart(DependencyObject obj, int value) => obj.SetValue(SelectionStartProperty, value);

    private static void OnSelectionStartChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is TextBox tb && tb.SelectionStart != (int)e.NewValue)
            tb.SelectionStart = (int)e.NewValue;
    }

    static TextBoxSelectionHelper()
    {
        EventManager.RegisterClassHandler(typeof(TextBox), TextBox.SelectionChangedEvent, new RoutedEventHandler(OnSelectionChanged));
    }

    private static void OnSelectionChanged(object sender, RoutedEventArgs e)
    {
        if (sender is TextBox tb)
        {
            SetSelectionStart(tb, tb.SelectionStart);
        }
    }
}
