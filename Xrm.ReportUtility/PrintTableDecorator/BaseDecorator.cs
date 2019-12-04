namespace Xrm.ReportUtility.PrintTableDecorator
{
    public class BaseDecorator : ITable
    {
		public ITable table;
		BaseDecorator(ITable table) {
			this.table = table;
		}
    }
}
