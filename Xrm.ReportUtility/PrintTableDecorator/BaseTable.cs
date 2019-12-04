namespace Xrm.ReportUtility.PrintTableDecorator
{
    public class BaseTable : ITable
    {
		BaseTable(string headerRow, string rowTemplate) {
			this.headerRow = headerRow;
			this.rowTemplate = rowTemplate;
		}
    }
}
