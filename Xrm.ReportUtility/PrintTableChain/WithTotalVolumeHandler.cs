using Xrm.ReportUtility.Models;
using Xrm.ReportUtility.PrintTableDecorator;

namespace Xrm.ReportUtility.PrintTableChain
{
	public class WithTotalVolumeHandler : PrintTableHandler
	{
		WithTotalVolumeHandler(PrintTableHandler nextHandler)
		{
			_nextHandler = nextHandler;
		}

		decorateTable(ReportConfig config, ITable table)
		{
			if (config.WithTotalVolume)
			{
				return new WithTotalVolumeDecorator(table);
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