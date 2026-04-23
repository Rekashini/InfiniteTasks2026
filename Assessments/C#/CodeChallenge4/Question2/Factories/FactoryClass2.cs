using ReportGeneratorApp.Abstract;
using ReportGeneratorApp.Interface;
using ReportGeneratorApp.Concrete;

namespace ReportGeneratorApp.Factories
{
    public class TabularReportFactory : ReportFactory
    {
        public override IReportGenerator CreateReport()
        {
            return new TabularReportGenerator();
        }
    }
}