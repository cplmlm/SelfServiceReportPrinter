using SelfServiceReportPrinter.Commands;
using System.ComponentModel;
using System.Windows.Input;

namespace SelfServiceReportPrinter.ViewModel
{
    public class KeyPressViewModel : BaseNotifyPropertyChanged
    {
        private string cardNumber;
        private int selectionStart=0;

        /// <summary>
        /// 输入文本框的值
        /// </summary>
        public string CardNumber
        {
            get { return cardNumber; }
            set
            {
                cardNumber = value;
                RaisePropertyChanged(nameof(CardNumber));
            }
        }

        /// <summary>
        /// 输入框光标位置
        /// </summary>
        public int SelectionStart
        {
            get { return selectionStart; }
            set { RaisePropertyChanged(nameof(SelectionStart)); }
        }

        /// <summary>
        /// Gets 数字按钮绑定事件
        /// </summary>
        public ICommand NumberCommand
        {
            get { return new RelayCommand<string>(Number); }
        }

        /// <summary>
        /// 清空按钮绑定事件
        /// </summary>
        public ICommand ClearCommand
        {
            get { return new RelayCommand(Clear); }
        }

        /// <summary>
        /// 删除按钮绑定事件    
        /// </summary>

        public ICommand DeleteCommand
        {
            get { return new RelayCommand(Delete); }
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
            this.CardNumber = string.Empty;
        }

        /// <summary>
        /// 删除点击事件.
        /// </summary>
        private void Delete()
        {
            // 光标在输入框时，删除光标前一个字符
            if (!string.IsNullOrEmpty(CardNumber) && SelectionStart > 0)
            {
                CardNumber = CardNumber.Remove(SelectionStart - 1, 1);
            }

            // 光标没有在输入框时，删除最后一个字符
            if (this.SelectionStart == 0)
            {
                CardNumber = CardNumber.Remove(CardNumber.Length - 1, 1);
            }
        }
    }
}
