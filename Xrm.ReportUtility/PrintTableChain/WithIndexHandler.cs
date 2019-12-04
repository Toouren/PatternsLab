using Xrm.ReportUtility.Models;
using Xrm.ReportUtility.PrintTableDecorator;

namespace Xrm.ReportUtility.PrintTableChain
{
	public class WithIndexHandler : PrintTableHandler
	{
		WithIndexHandler(PrintTableHandler nextHandler)
		{
			_nextHandler = nextHandler;
		}

		decorateTable(ReportConfig config, ITable table)
		{
			if (config.WithIndex)
			{
				return new WithTotalIndexDecorator(table);
			}
			if (_nextHandler == null)
			{
				return table;
			}
			else
			{
				return _nextHandler.decorateTable(config, table);
			}
		}
	}
}