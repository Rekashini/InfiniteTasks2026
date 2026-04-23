using ReportGeneratorApp.Abstract;
using ReportGeneratorApp.Interface;
using ReportGeneratorApp.Concrete;

namespace ReportGeneratorApp.Factories
{
    public class ChartReportFactory : ReportFactory
    {
        public override IReportGenerator CreateReport()
        {
            return new ChartReportGenerator();
        }
    }
}