using OfficeOpenXml;
using OrderTool.Models;
using SelectAll;

namespace OrderTool
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var input = "Dạ shop xin xác nhận lại đơn hàng của mình nha:\r\n- Mẫu: Name - Size - Price\r\n- SĐT: Phone\r\n- Địa chỉ nhận hàng: Address\r\n*note\r\nHàng em chuyển từ Quảng Châu về mất khoảng 10-12 ngày\r\nHàng không yc cọc nên chị vui lòng chờ và nhận hàng giúp em nhé!\r\nCảm ơn chị đã đặt hàng ạ";
            const string productKey = "- Mẫu:";
            const string phoneKey = "- SĐT:";
            const string addressKey = "- Địa chỉ nhận hàng:";
            const string noteKey = "*";
            const string endKey = "Hàng em chuyển từ Quảng Châu";

            int productKeyIndex = input.IndexOf(productKey);
            int phoneKeyIndex = input.IndexOf(phoneKey);
            int addressKeyIndex = input.IndexOf(addressKey);
            int noteKeyIndex = input.IndexOf(noteKey);
            int endKeyIndex = input.IndexOf(endKey);

            var x = new Chat()
            {
                ProductDetail = input.Substring(productKeyIndex + productKey.Length + 1, phoneKeyIndex - (productKeyIndex + productKey.Length) - 3),
                Phone = input.Substring(phoneKeyIndex + phoneKey.Length + 1, addressKeyIndex - (phoneKeyIndex + phoneKey.Length) - 3),
                Address = input.Substring(addressKeyIndex + addressKey.Length + 1, (noteKeyIndex > 0 ? noteKeyIndex : endKeyIndex) - (addressKeyIndex + addressKey.Length) - 3),
                Note = noteKeyIndex > 0 ? input.Substring(noteKeyIndex + noteKey.Length, endKeyIndex - (noteKeyIndex + noteKey.Length) - 2) : ""
            };
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ApplicationConfiguration.Initialize();
            Application.Run(new frmSelectAll());
        }
    }
}