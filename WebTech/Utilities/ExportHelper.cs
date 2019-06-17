using ClosedXML.Excel;
using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.UI;
namespace WebTech.Utilities
{
    public static class ExportHelper
    {
        #region Export EXCEL

        public static void ExportToExcel<T>(
            string filename
            , IEnumerable<T> source
            , Dictionary<string, string> columnDefinition
            , string sheetName = "Reporte"
            , string cookieName = "DescargaCompleta"
            , string valueName = "1")
        {
            var originalFileName = Path.GetFileNameWithoutExtension(filename) + ".xlsx";

            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add(sheetName);
            List<string> columns = new List<string>();
            int index = 1;

            foreach (KeyValuePair<string, string> keyvalue in columnDefinition)
            {
                //Establece las columnas
                ws.Cell(1, index).Value = keyvalue.Value;
                index++;
                columns.Add(keyvalue.Key);
            }

            int row = 2;
            foreach (var dataItem in (IEnumerable)source)
            {
                var col = 1;
                foreach (string column in columns)
                {
                    foreach (PropertyInfo property in dataItem.GetType().GetProperties())
                    {
                        if (column == property.Name)
                        {
                            if (property.PropertyType == typeof(bool?) || property.PropertyType == typeof(bool))
                            {
                                string value = DataBinder.GetPropertyValue(dataItem, property.Name, null);
                                ws.Cell(row, col).Value = (string.IsNullOrEmpty(value) ? "" : (value == "True" ? "Si" : "No"));
                            }
                            else if (property.PropertyType == typeof(decimal?) || property.PropertyType == typeof(decimal))
                            {
                                string value = DataBinder.GetPropertyValue(dataItem, property.Name, null);
                                ws.Cell(row, col).Value = string.Format("{0:N2}", value);
                            }
                            else if (property.PropertyType == typeof(int?) || property.PropertyType == typeof(int))
                            {
                                string value = DataBinder.GetPropertyValue(dataItem, property.Name, null);
                                ws.Cell(row, col).Value = value;
                                ws.Cell(row, col).DataType = XLCellValues.Number;
                            }
                            else
                            {
                                if (property.PropertyType == typeof(DateTime?) || property.PropertyType == typeof(DateTime))
                                    ws.Cell(row, col).Style.DateFormat.Format = "dd/MM/yyyy";
                                else
                                    ws.Cell(row, col).Style.NumberFormat.Format = "@";
                                ws.Cell(row, col).Value = DataBinder.GetPropertyValue(dataItem, property.Name, null);

                            }
                            break;
                        }
                    }
                    col++;
                }
                row++;
            }
            ws.Range(1, 1, 1, index - 1).AddToNamed("Titles");

            var titlesStyle = wb.Style;
            titlesStyle.Font.Bold = true;
            titlesStyle.Font.FontColor = XLColor.White;
            titlesStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            titlesStyle.Fill.BackgroundColor = XLColor.FromHtml("#006600");
            titlesStyle.Border.BottomBorder = XLBorderStyleValues.Thin;
            titlesStyle.Border.BottomBorderColor = XLColor.Black;
            titlesStyle.Border.TopBorder = XLBorderStyleValues.Thin;
            titlesStyle.Border.TopBorderColor = XLColor.Black;
            titlesStyle.Border.RightBorder = XLBorderStyleValues.Thin;
            titlesStyle.Border.RightBorderColor = XLColor.Black;
            titlesStyle.Border.LeftBorder = XLBorderStyleValues.Thin;
            titlesStyle.Border.LeftBorderColor = XLColor.Black;

            wb.NamedRanges.NamedRange("Titles").Ranges.Style = titlesStyle;
            ws.Columns().AdjustToContents();

            var stream = new MemoryStream();
            wb.SaveAs(stream);

            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Clear();
            //HttpContext.Current.Response.SetCookie("Cache-Control", "private");
            if (!string.IsNullOrEmpty(cookieName) && !string.IsNullOrEmpty(valueName))
                HttpContext.Current.Response.AppendCookie(new HttpCookie(cookieName, valueName));
            HttpContext.Current.Response.Buffer = false;
            HttpContext.Current.Response.AddHeader("Content-disposition", "attachment; filename=" + originalFileName);
            HttpContext.Current.Response.Charset = "UTF-8";
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Private);
            //HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.BinaryWrite(stream.ToArray());
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();

            stream.Dispose();
        }

        #endregion

        #region Export CSV

        public static void ExportToCSV<T>(
            string filename
            , IEnumerable<T> source
            , Dictionary<string, string> columnDefinition
            , string cookieName = "DescargaCompleta"
            , string valueName = "1")
        {

            List<string> columns = new List<string>();
            CsvWriter writer = null;
            var memoryStream = new MemoryStream();

            using (StreamWriter streamWriter = new StreamWriter(memoryStream, System.Text.Encoding.UTF8))
            {
                writer = new CsvWriter(streamWriter);
                //writer.WriteRecords(source);


                foreach (KeyValuePair<string, string> keyvalue in columnDefinition)
                {
                    writer.WriteField(keyvalue.Value);
                    columns.Add(keyvalue.Key);
                }
                writer.NextRecord();

                foreach (var dataItem in (IEnumerable)source)
                {
                    foreach (string column in columns)
                    {
                        foreach (PropertyInfo property in dataItem.GetType().GetProperties())
                        {
                            if (column == property.Name)
                            {
                                if (property.PropertyType == typeof(bool?) || property.PropertyType == typeof(bool))
                                {
                                    string value = DataBinder.GetPropertyValue(dataItem, property.Name, null);
                                    writer.WriteField(string.IsNullOrEmpty(value) ? "" : (value == "True" ? "Si" : "No"));
                                }
                                else if (property.PropertyType == typeof(decimal?) || property.PropertyType == typeof(decimal))
                                {
                                    string value = DataBinder.GetPropertyValue(dataItem, property.Name, null);
                                    writer.WriteField(string.Format("{0:N2}", value));
                                }
                                else if (property.PropertyType == typeof(int?) || property.PropertyType == typeof(int))
                                {
                                    string value = DataBinder.GetPropertyValue(dataItem, property.Name, null);
                                    writer.WriteField<int>(Convert.ToInt32(value));
                                }
                                else
                                {
                                    writer.WriteField(DataBinder.GetPropertyValue(dataItem, property.Name, null));
                                }
                                break;
                            }
                        }
                    }
                    writer.NextRecord();
                }

            }


            var originalFileName = Path.GetFileNameWithoutExtension(filename) + ".csv";

            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Clear();
            //HttpContext.Current.Response.SetCookie("Cache-Control", "private");
            if (!string.IsNullOrEmpty(cookieName) && !string.IsNullOrEmpty(valueName))
                HttpContext.Current.Response.AppendCookie(new HttpCookie(cookieName, valueName));
            HttpContext.Current.Response.Buffer = false;
            HttpContext.Current.Response.AddHeader("Content-disposition", "attachment; filename=" + originalFileName);
            HttpContext.Current.Response.Charset = "UTF-8";
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Private);
            //HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.BinaryWrite(memoryStream.ToArray());
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();

            memoryStream.Dispose();
        }

        #endregion
    }
}