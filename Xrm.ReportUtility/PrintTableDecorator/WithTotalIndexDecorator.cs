namespace Xrm.ReportUtility.PrintTableDecorator
{
	public class WithTotalIndexDecorator : BaseDecorator
	{
		WithTotalIndexDecorator(ITable table) : base(table)
		{
			headerRow = "№\t" + headerRow;
			rowTemplate = "{0}\t" + rowTemplate;
		}
	}
}
