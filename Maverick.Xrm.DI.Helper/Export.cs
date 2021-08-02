using Maverick.Xrm.DI.DataObjects;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Maverick.XTB.DI.Helper
{
    public class Export
    {
        #region Private

        private static List<string> ColumnHeaders = new List<string> { "\"Entity Schema Name\"", "\"Dependent Component\"", "\"Dependent Component Type\"", "\"Dependent Description\"" };

        #endregion

        public static void ExportAsCsv(List<DependencyReport> rows, string fileName)
        {
            var writer = new StreamWriter(fileName);

            var header = string.Join(",", ColumnHeaders);
            writer.WriteLine(header);

            foreach (var row in rows.Where(r => r.SkipAdding == false))
            {
                writer.WriteLine($"\"{row.EntitySchemaName}\",\"{row.DependentComponentName}\",\"{row.DependentComponentType}\",\"{row.DependentDescription}\"");
            }

            writer.Close();
        }

        public static void ExportAsExcel(List<DependencyReport> rows, string fileName)
        {
            var package = new ExcelPackage();

            var worksheet = package.Workbook.Worksheets.Add("Dependencies");
            worksheet.Cells[1, 1].Value = ColumnHeaders[0].Replace("\"", string.Empty);
            worksheet.Cells[1, 2].Value = ColumnHeaders[1].Replace("\"", string.Empty);
            worksheet.Cells[1, 3].Value = ColumnHeaders[2].Replace("\"", string.Empty);
            worksheet.Cells[1, 4].Value = ColumnHeaders[3].Replace("\"", string.Empty);

            for (var index = 0; index < rows.Count; index++)
            {
                var row = rows[index];

                worksheet.Cells[index + 2, 1].Value = row.EntitySchemaName;
                worksheet.Cells[index + 2, 2].Value = row.DependentComponentName;
                worksheet.Cells[index + 2, 3].Value = row.DependentComponentType;
                worksheet.Cells[index + 2, 4].Value = row.DependentDescription;
            }
            var table = worksheet.Tables
                .Add(worksheet.Cells[1, 1, rows.Count + 1, 4], "TableDependency");
            table.TableStyle = TableStyles.Medium9;

            worksheet.Cells.AutoFitColumns();

            package.SaveAs(new FileInfo(fileName));

        }
    }
}
