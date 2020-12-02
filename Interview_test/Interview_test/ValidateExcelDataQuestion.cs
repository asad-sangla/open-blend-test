using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ExcelDataReader;

namespace Interview_test
{
    public static class ValidateExcelDataQuestion
    {
        /// <summary>
        /// Get excel sheet file path and returns each row data with row number and status true if it has 2 email in row data.
        /// This is done for data representation for console app, as it can be refactored more
        /// I have left possible exceptions due to less time I have now.
        /// Also I have left Unit testing for thi due to time.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static IList<Tuple<int, bool, string>> ReadData(string filePath)
        {
            var model = new List<Tuple<int, bool, string>>();

            if (string.IsNullOrEmpty(filePath))
                return model;


            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            //open file and read
            using var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateReader(stream);
            do
            {
                var rowCounter = 1;
                while (reader.Read())
                {
                    //select data of all columns
                    var rowObjects = Enumerable.Range(0, reader.FieldCount)
                                            .Select(i => reader.GetValue(i))
                                            .ToList();

                    //validate email address and count how many times it exists in the row
                    var emailsCountInRow = rowObjects.Count(x => x != null && IsValidEmail(x.ToString()));

                    //just select data in plan string
                    var rowData = string.Join(" | ", rowObjects.ConvertAll(x => x?.ToString()).ToArray());

                    var rowResult = new Tuple<int, bool, string>(rowCounter, emailsCountInRow == 2, rowData);
                    model.Add(rowResult);

                    rowCounter++;
                }
            } while (reader.NextResult());

            return model;
        }

        private static bool IsValidEmail(string value) => !string.IsNullOrEmpty(value) && Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
    }
}
