using System;
using ReportGeneratorApp.Interface;

namespace ReportGeneratorApp.Concrete
{
    public class ChartReportGenerator : IReportGenerator
    {
        public void GenerateReport()
        {
            Console.WriteLine("Generating chart-based report...");
        }
    }
}