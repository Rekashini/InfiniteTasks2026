using ReportGeneratorApp.Interface;

namespace ReportGeneratorApp.Abstract
{
    public abstract class ReportFactory
    {
        public abstract IReportGenerator CreateReport();
    }
}
