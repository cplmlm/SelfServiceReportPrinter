using CommunityToolkit.Mvvm.Input;
using FastReport;
using FastReport.Export.Pdf;
using System.Diagnostics;
using System.IO;

namespace SelfServiceReportPrinter.ViewModels
{
    public partial class ReportViewModel:ViewModelBase
    {
        public ReportViewModel() {
            
        }
        /// <summary>
        /// 预览报表
        /// </summary>
        /// <param name="path">报表路径</param>
        [RelayCommand]
        private void PreviewReport(string path)
        {
            var reportFile = Path.Combine(Environment.CurrentDirectory, $"Reports/{path}");
            if (File.Exists(reportFile))
            {
                using (var report = new Report())
                {
                    //加载报表
                    report.Load(reportFile);
                    //创建数据源
                    var ds =new System.Data.DataSet();
                    
                    //绑定数据源
                    report.RegisterData(ds, "NorthWind");
                    //运行报表
                    report.ShowAsync();
                }
            }
        }
        /// <summary>
        /// 导出PDF
        /// </summary>
        /// <param name="path"></param>
        [RelayCommand]
        private void ReportExport(string path)
        {
            var reportFile = Path.Combine(Environment.CurrentDirectory, $"Reports/{path}");
            if (File.Exists(reportFile))
            {
                using (var report = new Report())
                {
                    ////加载报表
                    //report.Load(reportFile);
                    ////创建数据源
                    //var ds = GetNorthWindDataSet();
                    ////绑定数据源
                    //report.RegisterData(ds, "NorthWind");
                    ////运行报表
                    //report.Prepare();
                    ////导出PDF报表
                    //var file = FileDialogHelper.SavePdf("result.pdf");
                    //if (!string.IsNullOrEmpty(file))
                    //{
                    //    var export = new PDFExport();
                    //    report.Export(export, file);
                    //}
                    ////打开PDF
                    //if (File.Exists(file))
                    //{
                    //    Process.Start("explorer.exe", file);
                    //}
                }
            }
        }
    }
}
