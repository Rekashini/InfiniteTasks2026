using System;
using ReportGeneratorApp.Interface;

namespace ReportGeneratorApp.Concrete
{
    public class SummaryReportGenerator : IReportGenerator
    {
        public void GenerateReport()
        {
            Console.WriteLine("Generating summary report...");
        }
    }
}