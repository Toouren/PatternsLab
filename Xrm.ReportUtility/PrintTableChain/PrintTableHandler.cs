using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.PrintTableChain
{
    public class PrintTableHandler
    {
		private PrintTableHandler _nextHandler;
		public ITable decorateTable(ReportConfig config, ITable table);
    }
}
