namespace Xrm.ReportUtility.PrintTableDecorator
{
	public class WithTotalWeightDecorator : BaseDecorator
	{
		WithTotalWeightDecorator(ITable table) : base(table)
		{
			headerRow = headerRow + "\tСуммарный вес";
			rowTemplate = rowTemplate + "\t{7,13}";
		}
	}
}
