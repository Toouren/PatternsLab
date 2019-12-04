namespace Xrm.ReportUtility.PrintTableDecorator
{
	public class WithTotalVolumeDecorator : BaseDecorator
	{
		WithTotalVolumeDecorator(ITable table) : base(table)
		{
			headerRow = headerRow + "\tСуммарный объём";
			rowTemplate = rowTemplate + "\t{6,15}";
		}
	}
}
