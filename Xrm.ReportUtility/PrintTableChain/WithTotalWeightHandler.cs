using Xrm.ReportUtility.Models;
using Xrm.ReportUtility.PrintTableDecorator;

namespace Xrm.ReportUtility.PrintTableChain
{
	public class WithTotalWeightHandler : PrintTableHandler
	{
		WithTotalWeightHandler(PrintTableHandler nextHandler)
		{
			_nextHandler = nextHandler;
		}

		decorateTable(ReportConfig config, ITable table)
		{
			if (config.WithTotalWeight)
			{
				return new WithTotalWeightDecorator(table);
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