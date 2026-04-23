using System;
using ReportGeneratorApp.Interface;

namespace ReportGeneratorApp.Concrete
{
    public class TabularReportGenerator : IReportGenerator
    {
        public void GenerateReport()
        {
            Console.WriteLine("Generating tabular report...");
        }
    }
}