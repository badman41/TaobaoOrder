using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTool
{

    public static class ExcelHelper
    {
        public static ExcelPackage UpdateDataIntoExcelTemplate(FileInfo path)
        {
            using (ExcelPackage p = new ExcelPackage(path))
            {
                ExcelWorksheet wsEstimate = p.Workbook.Worksheets["Danh sách"];
                wsEstimate.Cells["B9"].Value = "123";
                return p;
            }
        }
    }
}
