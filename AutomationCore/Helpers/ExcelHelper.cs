using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace AutomationCore.Helpers
{
    public class ExcelHelper
    {
        // Private fields
        private FileStream _fileStream;
        private IWorkbook _workbook;
        private ISheet _sheet;
        private ICell _cell;
        private string _excelFilePath;
        private Dictionary<string, int> columns = new Dictionary<string, int>();

        // Method to set the Excel file and sheet
        public void SetExcelFile(string ExcelPath, string SheetName)
        {
            try
            {
                // Create a new FileInfo object for the Excel file
                FileInfo f = new FileInfo(ExcelPath);

                // Check if the file exists, and create it if it doesn't
                if (!f.Exists)
                {
                    f.Create();
                    Console.WriteLine("File doesn't exist, so created!");
                }

                // Open the Excel file using a FileStream
                _fileStream = new FileStream(ExcelPath, FileMode.Open, FileAccess.Read);

                // Create a new XSSFWorkbook object from the FileStream
                _workbook = new XSSFWorkbook(_fileStream);

                // Get the sheet with the specified name from the workbook
                _sheet = _workbook.GetSheet(SheetName);

                // If the sheet doesn't exist, create it
                if (_sheet == null)
                {
                    _sheet = _workbook.CreateSheet(SheetName);
                }

                // Add all the column header names to the dictionary 'columns'
                IRow headerRow = _sheet.GetRow(0);
                for (int i = 0; i < headerRow.LastCellNum; i++)
                {
                    ICell headerCell = headerRow.GetCell(i);
                    columns.Add(headerCell.StringCellValue, headerCell.ColumnIndex);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // Method to get the data from a cell based on row number and column number
        public string GetCellData(int rownum, int colnum)
        {
            try
            {
                // Get the cell at the specified row and column
                _cell = _sheet.GetRow(rownum).GetCell(colnum);
                string CellData = null;

                // Check the cell type and set the value accordingly
                switch (_cell.CellType)
                {
                    case CellType.String:
                        CellData = _cell.StringCellValue;
                        break;
                    case CellType.Numeric:
                        if (DateUtil.IsCellDateFormatted(_cell))
                        {
                            CellData = _cell.DateCellValue.ToString();
                        }
                        else
                        {
                            CellData = _cell.NumericCellValue.ToString();
                        }
                        break;
                    case CellType.Boolean:
                        CellData = _cell.BooleanCellValue.ToString();
                        break;
                    case CellType.Blank:
                        CellData = "";
                        break;
                    default:
                        throw new Exception("Unsupported cell type: " + _cell.CellType);
                }

                // Return the cell data
                return CellData;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while getting cell data: " + e.Message);

                // Return an empty string if there was an error
                return "";
            }
        }

        // Method to get the data from a cell based on column name and row number
        public string GetCellData(string columnName, int rownum)
        {
            // Use the dictionary 'columns' to get the column number from the column name
            return GetCellData(rownum, columns[columnName]);
        }
    }
}
