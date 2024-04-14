using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAutomation.ExcelHelper
{
    class TestData
    {
        public static IEnumerable<object[]> TestValue => ExcelHelper.ReadXlsxDataDriveFile(@"C:\Users\NamTT18\source\repos\FinalAutomation\FinalAutomation\ExcelHelper\TestData.xlsx", "Sheet1");
        public static IEnumerable<object[]> TestValueForCreateAccount => ExcelHelper.ReadXlsxDataDriveFile(@"C:\Users\NamTT18\source\repos\FinalAutomation\FinalAutomation\ExcelHelper\TestDataForCreateAccount.xlsx", "Sheet1");
        public static IEnumerable<object[]> TestValueForSignin => ExcelHelper.ReadXlsxDataDriveFile(@"C:\Users\NamTT18\source\repos\FinalAutomation\FinalAutomation\ExcelHelper\TestDataForLogin.xlsx", "Sheet1");
    }
}
