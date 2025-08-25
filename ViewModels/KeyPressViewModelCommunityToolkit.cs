using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SelfServiceReportPrinter.ViewModel;

public partial class KeyPressViewModelCommunityToolkit : ObservableObject
{
    [ObservableProperty]
    private string cardNumber = string.Empty;

    [ObservableProperty]
    private int selectionStart;

    /// <summary>
    /// 数字点击事件
    /// </summary>
    /// <param name="key"></param>
    [RelayCommand]
    private void Number(string? key)
    {
        CardNumber += key;
    }

    /// <summary>
    /// 清空输入框
    /// </summary>
    [RelayCommand]
    private void Clear()
    {
        CardNumber = string.Empty;
    }

    /// <summary>
    /// 删除点击事件
    /// </summary>
    [RelayCommand]
    private void Delete()
    {
        // 光标在输入框时，删除光标前一个字符
        if (!string.IsNullOrEmpty(CardNumber) && SelectionStart > 0)
        {
            CardNumber = CardNumber.Remove(SelectionStart - 1, 1);
        }
        //光标没有在输入框时，删除最后一个字符
        if (SelectionStart == 0)
        {
            CardNumber = CardNumber.Remove(CardNumber.Length - 1, 1);
        }
    }
}
