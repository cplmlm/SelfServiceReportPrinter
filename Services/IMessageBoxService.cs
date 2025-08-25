using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfServiceReportPrinter.Services
{
    internal interface IMessageBoxService
    {
        void ShowMessage(string message);
    }
}
