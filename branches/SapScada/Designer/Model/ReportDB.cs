using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Drawing;

namespace Designer.Model
{
    public class ReportDB
    {
        public static void PreProcess()
        {

        }

        static public void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                throw new Exception("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        static public bool exportDataToExcel(string tieude, DataTable dt)
        {
            bool result = false;
            //khoi tao cac doi tuong Com Excel de lam viec
         
            Excel.Application xlApp;
            Excel.Worksheet xlSheet;
            Excel.Workbook xlBook;
            //doi tuong Trống để thêm  vào xlApp sau đó lưu lại sau
            object missValue = System.Reflection.Missing.Value;
            //khoi tao doi tuong Com Excel moi
            xlApp = new Excel.Application();
            xlBook = xlApp.Workbooks.Add(missValue);
            //su dung Sheet dau tien de thao tac
            xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(1);
            //không cho hiện ứng dụng Excel lên để tránh gây đơ máy
            xlApp.Visible = false;
            int socot=dt.Columns.Count;
            int sohang=dt.Rows.Count;
            int i,j;

            SaveFileDialog f = new SaveFileDialog();
            f.Filter = "Excel file (*.xls)|*.xls";
            if (f.ShowDialog() == DialogResult.OK)
            {
                //set thuoc tinh cho tieu de
                xlSheet.get_Range("A1", Convert.ToChar(socot + 65) + "1").Merge(false);
                Excel.Range caption = xlSheet.get_Range("A1", Convert.ToChar(socot + 65) + "1");
                caption.Select();
                caption.FormulaR1C1 = tieude;
				//căn lề cho tiêu đề
                caption.HorizontalAlignment = Excel.Constants.xlCenter;
                caption.Font.Bold = true;
                caption.VerticalAlignment = Excel.Constants.xlCenter;
                caption.Font.Size = 15;
				//màu nền cho tiêu đề
                caption.Interior.ColorIndex = 20;
                caption.RowHeight = 30;
                //set thuoc tinh cho cac header
                Excel.Range header = xlSheet.get_Range("A2", Convert.ToChar(socot + 65) + "2");
                header.Select();

                header.HorizontalAlignment = Excel.Constants.xlCenter;
                header.Font.Bold = true;
                header.Font.Size = 10;
                header.Interior.Color = Color.Yellow;
                //điền tiêu đề cho các cột trong file excel
                for (i = 0; i < socot; i++)
                    xlSheet.Cells[2, i + 2] = dt.Columns[i].ColumnName;
                //dien cot stt
                xlSheet.Cells[2, 1] = "STT";
                for (i = 0; i < sohang; i++)
                    xlSheet.Cells[i + 3, 1] = i + 1;
                //dien du lieu vao sheet


                for (i = 0; i < sohang; i++)
                    for (j = 0; j < socot; j++)
                    {
                        xlSheet.Cells[i + 3, j + 2] = dt.Rows[i][j];

                    }
                //autofit độ rộng cho các cột 
                xlSheet.Columns.AutoFit();

                // boder
                Excel.Range en = xlSheet.get_Range("A2", Convert.ToChar(socot + 65) + (sohang+2).ToString());
                en.Borders.LineStyle = Excel.XlLineStyle.xlDash;
               
                //save file
                bool IsSaved = false;
                xlBook.SaveAs(f.FileName, Excel.XlFileFormat.xlWorkbookNormal, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlExclusive, missValue, missValue, missValue, missValue, missValue);
                xlBook.Close(true, missValue, missValue);
                xlApp.Quit();
                IsSaved = true;
                // release cac doi tuong COM
                releaseObject(xlSheet);
                releaseObject(xlBook);
                releaseObject(xlApp);
             
                if (IsSaved)
                {
                    var m = MessageBox.Show("Thành công \r\n Xem file ?", "Done", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    if (m == System.Windows.Forms.DialogResult.Yes)
                    {
                        Process.Start(f.FileName);
                    }
                }

                result = true;
            }
            return result;
        }

        static public int exportDataToExcel(string tieude, DataTable dt,int row)
        {
            int result = row;
            //khoi tao cac doi tuong Com Excel de lam viec

            Excel.Application xlApp;
            Excel.Worksheet xlSheet;
            Excel.Workbook xlBook;
            //doi tuong Trống để thêm  vào xlApp sau đó lưu lại sau
            object missValue = System.Reflection.Missing.Value;
            //khoi tao doi tuong Com Excel moi
            xlApp = new Excel.Application();
            xlBook = xlApp.Workbooks.Add(missValue);
            //su dung Sheet dau tien de thao tac
            xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(1);
            //không cho hiện ứng dụng Excel lên để tránh gây đơ máy
            xlApp.Visible = false;
            int socot = dt.Columns.Count;
            int sohang = dt.Rows.Count;
            int i, j;

            SaveFileDialog f = new SaveFileDialog();
            f.Filter = "Excel file (*.xls)|*.xls";
            if (f.ShowDialog() == DialogResult.OK)
            {
                //set thuoc tinh cho tieu de
                xlSheet.get_Range("A"+row.ToString(), Convert.ToChar(socot + 65) + row.ToString()).Merge(false);
                Excel.Range caption = xlSheet.get_Range("A" + row.ToString(), Convert.ToChar(socot + 65) + row.ToString());
                caption.Select();
                caption.FormulaR1C1 = tieude;
                //căn lề cho tiêu đề
                caption.HorizontalAlignment = Excel.Constants.xlCenter;
                caption.Font.Bold = true;
                caption.VerticalAlignment = Excel.Constants.xlCenter;
                caption.Font.Size = 15;
                //màu nền cho tiêu đề
                caption.Interior.ColorIndex = 20;
                caption.RowHeight = 30;
                //set thuoc tinh cho cac header
                Excel.Range header = xlSheet.get_Range("A" + (row + 1).ToString(), Convert.ToChar(socot + 65) + (row+1).ToString());
                header.Select();

                header.HorizontalAlignment = Excel.Constants.xlCenter;
                header.Font.Bold = true;
                header.Font.Size = 10;
                header.Interior.Color = Color.Yellow;
                //điền tiêu đề cho các cột trong file excel
                for (i = 0; i < socot; i++)
                    xlSheet.Cells[row+1, i + 2] = dt.Columns[i].ColumnName;
                //dien cot stt
                xlSheet.Cells[row+1, 1] = "STT";
                for (i = 0; i < sohang; i++)
                    xlSheet.Cells[i + 2 + row, 1] = i + 1;
                //dien du lieu vao sheet


                for (i = 0; i < sohang; i++)
                    for (j = 0; j < socot; j++)
                    {
                        xlSheet.Cells[i + 2 + row , j + 2] = dt.Rows[i][j];

                    }
                //autofit độ rộng cho các cột 
                xlSheet.Columns.AutoFit();

                // boder
                Excel.Range en = xlSheet.get_Range("A" + (row+1).ToString(), Convert.ToChar(socot + 65) + (sohang +row + 1).ToString());
                en.Borders.LineStyle = Excel.XlLineStyle.xlDash;

                //save file
                bool IsSaved = false;
                xlBook.SaveAs(f.FileName, Excel.XlFileFormat.xlWorkbookNormal, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlExclusive, missValue, missValue, missValue, missValue, missValue);
             
                xlBook.Close(true, missValue, missValue);
                xlApp.Quit();
                IsSaved = true;
                // release cac doi tuong COM
                releaseObject(xlSheet);
                releaseObject(xlBook);
                releaseObject(xlApp);

                if (IsSaved)
                {
                    var m = MessageBox.Show("Thành công \r\n Xem file ?", "Done", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    if (m == System.Windows.Forms.DialogResult.Yes)
                    {
                        Process.Start(f.FileName);
                    }
                }

                result = sohang + 3 + row;
            }
            return result;
        }

        static public bool exportDataToExcel(Dictionary<string, DataTable> data)
        {
            bool result = false;
            //khoi tao cac doi tuong Com Excel de lam viec

            Excel.Application xlApp;
            Excel.Worksheet xlSheet;
            Excel.Workbook xlBook;
            //doi tuong Trống để thêm  vào xlApp sau đó lưu lại sau
            object missValue = System.Reflection.Missing.Value;
            //khoi tao doi tuong Com Excel moi
            xlApp = new Excel.Application();
            xlBook = xlApp.Workbooks.Add(missValue);
            //su dung Sheet dau tien de thao tac
            xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(1);
            //không cho hiện ứng dụng Excel lên để tránh gây đơ máy
            xlApp.Visible = false;
           
            int i, j;

            SaveFileDialog f = new SaveFileDialog();
            f.Filter = "Excel file (*.xls)|*.xls";
            if (f.ShowDialog() == DialogResult.OK)
            {
                List<string> staff_name = data.Keys.ToList();
                int row = 1;
                for (int jk = 0; jk < data.Count; jk++)
                {
                    DataTable dt = data[staff_name[jk]];
                    string tieude = staff_name[jk];
                    int socot = dt.Columns.Count;
                    int sohang = dt.Rows.Count;

                     //set thuoc tinh cho tieu de
                    xlSheet.get_Range("A" + row.ToString(), Convert.ToChar(socot + 65) + row.ToString()).Merge(false);
                    Excel.Range caption = xlSheet.get_Range("A" + row.ToString(), Convert.ToChar(socot + 65) + row.ToString());
                    caption.Select();
                    caption.FormulaR1C1 = tieude;
                    //căn lề cho tiêu đề
                    caption.HorizontalAlignment = Excel.Constants.xlCenter;
                    caption.Font.Bold = true;
                    caption.VerticalAlignment = Excel.Constants.xlCenter;
                    caption.Font.Size = 15;
                    //màu nền cho tiêu đề
                    caption.Interior.ColorIndex = 20;
                    caption.RowHeight = 30;
                    //set thuoc tinh cho cac header
                    Excel.Range header = xlSheet.get_Range("A" + (row + 1).ToString(), Convert.ToChar(socot + 65) + (row + 1).ToString());
                    header.Select();

                    header.HorizontalAlignment = Excel.Constants.xlCenter;
                    header.Font.Bold = true;
                    header.Font.Size = 10;
                    header.Interior.Color = Color.Yellow;
                    //điền tiêu đề cho các cột trong file excel
                    for (i = 0; i < socot; i++)
                        xlSheet.Cells[row + 1, i + 2] = dt.Columns[i].ColumnName;
                    //dien cot stt
                    xlSheet.Cells[row + 1, 1] = "STT";
                    for (i = 0; i < sohang; i++)
                        xlSheet.Cells[i + 2 + row, 1] = i + 1;
                    //dien du lieu vao sheet


                    for (i = 0; i < sohang; i++)
                        for (j = 0; j < socot; j++)
                        {
                            xlSheet.Cells[i + 2 + row, j + 2] = dt.Rows[i][j];

                        }
                    //autofit độ rộng cho các cột 
                    xlSheet.Columns.AutoFit();

                    // boder
                    Excel.Range en = xlSheet.get_Range("A" + (row + 1).ToString(), Convert.ToChar(socot + 65) + (sohang + row + 1).ToString());
                    en.Borders.LineStyle = Excel.XlLineStyle.xlDash;

                    row = sohang + 3 + row;
                }
                //save file
                bool IsSaved = false;
                xlBook.SaveAs(f.FileName, Excel.XlFileFormat.xlWorkbookNormal, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlExclusive, missValue, missValue, missValue, missValue, missValue);

                xlBook.Close(true, missValue, missValue);
                xlApp.Quit();
                IsSaved = true;
                // release cac doi tuong COM
                releaseObject(xlSheet);
                releaseObject(xlBook);
                releaseObject(xlApp);

                if (IsSaved)
                {
                    var m = MessageBox.Show("Thành công \r\n Xem file ?", "Done", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    if (m == System.Windows.Forms.DialogResult.Yes)
                    {
                        Process.Start(f.FileName);
                    }
                }

                result = true;
            }
            return result;
        }

        static public bool exportDataToExcel(Dictionary<string, DataTable> Main, List<Dictionary<string,DataTable>> Details   )
        {
            bool result = false;
            Dictionary<string,DataTable> data = Main;

            Excel.Application xlApp;
            Excel.Worksheet xlSheet;
            Excel.Workbook xlBook;
            //doi tuong Trống để thêm  vào xlApp sau đó lưu lại sau
            object missValue = System.Reflection.Missing.Value;
            //khoi tao doi tuong Com Excel moi
            xlApp = new Excel.Application();
            xlBook = xlApp.Workbooks.Add(missValue);
            //su dung Sheet dau tien de thao tac
            xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(1);
            //không cho hiện ứng dụng Excel lên để tránh gây đơ máy
            xlApp.Visible = false;
           
            int i, j;

            SaveFileDialog f = new SaveFileDialog();
            f.Filter = "Excel file (*.xls)|*.xls";
            if (f.ShowDialog() == DialogResult.OK)
            {
                int count = Details.Count + 1;
                int row = 1;
                for (int k = 0; k < count; k++)
                {
                    if (k == 0)
                    {
                        data = Main;
                    }
                    if (k == 1)
                    {
                        // new sheet for Maintenance Task
                        if (xlBook.Worksheets.Count < 2)   
                        {
                            xlSheet = xlBook.Worksheets.Add();
                        }
                        xlSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(2);
                        xlSheet.Select();
                        row = 1;    
                    }
                    if (k >= 1)
                    {
                        data = Details[k - 1];
                    }

                    List<string> Keys = data.Keys.ToList();
                    
                    for (int jk = 0; jk < data.Count; jk++)
                    {
                        DataTable dt = data[Keys[jk]];
                        string tieude = Keys[jk];
                        int socot = dt.Columns.Count;
                        int sohang = dt.Rows.Count;

                        //set thuoc tinh cho tieu de
                        xlSheet.get_Range("A" + row.ToString(), Convert.ToChar(socot + 65) + row.ToString()).Merge(false);
                        Excel.Range caption = xlSheet.get_Range("A" + row.ToString(), Convert.ToChar(socot + 65) + row.ToString());
                        caption.Select();
                        caption.FormulaR1C1 = tieude;
                        //căn lề cho tiêu đề
                        caption.HorizontalAlignment = Excel.Constants.xlCenter;
                        caption.Font.Bold = true;
                        caption.VerticalAlignment = Excel.Constants.xlCenter;
                        caption.Font.Size = 15;
                        //màu nền cho tiêu đề
                        caption.Interior.ColorIndex = 20;
                        caption.RowHeight = 30;
                        //set thuoc tinh cho cac header
                        Excel.Range header = xlSheet.get_Range("A" + (row + 1).ToString(), Convert.ToChar(socot + 65) + (row + 1).ToString());
                        header.Select();

                        header.HorizontalAlignment = Excel.Constants.xlCenter;
                        header.Font.Bold = true;
                        header.Font.Size = 10;
                        header.Interior.Color = Color.Yellow;
                        //điền tiêu đề cho các cột trong file excel
                        for (i = 0; i < socot; i++)
                            xlSheet.Cells[row + 1, i + 2] = dt.Columns[i].ColumnName;
                        //dien cot stt
                        xlSheet.Cells[row + 1, 1] = "STT";
                        for (i = 0; i < sohang; i++)
                            xlSheet.Cells[i + 2 + row, 1] = i + 1;
                        //dien du lieu vao sheet


                        for (i = 0; i < sohang; i++)
                            for (j = 0; j < socot; j++)
                            {
                                xlSheet.Cells[i + 2 + row, j + 2] = dt.Rows[i][j];

                            }
                        //autofit độ rộng cho các cột 
                        xlSheet.Columns.AutoFit();

                        // boder
                        Excel.Range en = xlSheet.get_Range("A" + (row + 1).ToString(), Convert.ToChar(socot + 65) + (sohang + row + 1).ToString());
                        en.Borders.LineStyle = Excel.XlLineStyle.xlDash;

                        row = sohang + 3 + row;
                    }
                }
                //save file
                bool IsSaved = false;
                xlBook.SaveAs(f.FileName, Excel.XlFileFormat.xlWorkbookNormal, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlExclusive, missValue, missValue, missValue, missValue, missValue);

                xlBook.Close(true, missValue, missValue);
                xlApp.Quit();
                IsSaved = true;
                // release cac doi tuong COM
                releaseObject(xlSheet);
                releaseObject(xlBook);
                releaseObject(xlApp);

                if (IsSaved)
                {
                    var m = MessageBox.Show("Thành công \r\n Xem file ?", "Done", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    if (m == System.Windows.Forms.DialogResult.Yes)
                    {
                        Process.Start(f.FileName);
                    }
                }
            }
            return result;
        }
    }
}
