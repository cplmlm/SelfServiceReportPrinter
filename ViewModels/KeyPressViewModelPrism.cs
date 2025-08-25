namespace SelfServiceReportPrinter.ViewModel;

public partial class KeyPressViewModelPrism : BindableBase
{
    private string cardNumber;
    private int selectionStart;

    public string CardNumber
    {
        get { return cardNumber; }
        set { SetProperty(ref cardNumber, value); }
    }

    public int SelectionStart
    {
        get { return selectionStart; }
        set { SetProperty(ref selectionStart, value); }
    }

    public DelegateCommand<string> NumberCommand { get; }
    public DelegateCommand ClearCommand { get; }
    public DelegateCommand DeleteCommand { get; }
    public KeyPressViewModelPrism()
    {
        NumberCommand = new DelegateCommand<string>(Number);
        ClearCommand = new DelegateCommand(Clear);
        DeleteCommand = new DelegateCommand(Delete);
    }

    /// <summary>
    /// 数字点击事件
    /// </summary>
    /// <param name="key"></param>
    private void Number(string? key)
    {
        CardNumber += key;
    }

    /// <summary>
    /// 清空点击事件
    /// </summary>
    private void Clear()
    {
        CardNumber = string.Empty;
    }

    /// <summary>
    /// 删除点击事件
    /// </summary>
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
