using System;
using System.Linq;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;
using Xrm.ReportUtility.Services;
using Xrm.ReportUtility.PrintTableDecorator;

namespace Xrm.ReportUtility
{
    public static class Program
    {
        // "Files/table.txt" -data -weightSum -costSum -withIndex -withTotalVolume
        public static void Main(string[] args)
        {
            var service = GetReportService(args);

            var report = service.CreateReport();

            PrintReport(report);

            Console.WriteLine("");
            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }

        private static IReportService GetReportService(string[] args)
        {
            var filename = args[0];

            if (filename.EndsWith(".txt"))
            {
                return new TxtReportService(args);
            }

            if (filename.EndsWith(".csv"))
            {
                return new CsvReportService(args);
            }

            if (filename.EndsWith(".xlsx"))
            {
                return new XlsxReportService(args);
            }

            throw new NotSupportedException("this extension not supported");
        }

        private static void PrintReport(Report report)
        {
            if (report.Config.WithData && report.Data != null && report.Data.Any())
            {
                var headerRow = "Наименование\tОбъём упаковки\tМасса упаковки\tСтоимость\tКоличество";
                var rowTemplate = "{1,12}\t{2,14}\t{3,14}\t{4,9}\t{5,10}";

				var baseTable = new BaseTable(headerRow, rowTemplate);
	
				var _handler = new WithTotalWeightHandler(null);
				_handler = new WithTotalVolumeHandler(_handler);
				_handler = new WithTotalIndexHandler(_handler);

				var decoratedTable = _handler.decorateTable(report.Config, baseTable);

                Console.WriteLine(decoratedTable.headerRow);

                for (var i = 0; i < report.Data.Length; i++)
                {
                    var dataRow = report.Data[i];
                    Console.WriteLine(rowTemplate, i + 1, dataRow.Name, dataRow.Volume, dataRow.Weight, dataRow.Cost, dataRow.Count, dataRow.Volume * dataRow.Count, dataRow.Weight * dataRow.Count);
                }

                Console.WriteLine();
            }

            if (report.Rows != null && report.Rows.Any())
            {
                Console.WriteLine("Итого:");
                foreach (var reportRow in report.Rows)
                {
                    Console.WriteLine(string.Format("  {0,-20}\t{1}", reportRow.Name, reportRow.Value));
                }
            }
        }
    }
}