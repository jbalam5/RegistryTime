using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ClosedXML.Excel;

namespace RegistryTime.CustomControls
{
    public partial class ExportExcelControl : UserControl
    {
        public DataGridView data { get; set; }
        public string Title { get; set; }

        public ExportExcelControl()
        {
            InitializeComponent();
        }

        private void ExportExcelButton_Click(object sender, EventArgs e)
        {
            if(data != null && data.Rows.Count > 0)
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                if (fichero.ShowDialog() == DialogResult.OK)
                {

                    //Creating DataTable.
                    DataTable dt = new DataTable();

                    //Adding the Columns.
                    foreach (DataGridViewColumn column in data.Columns)
                    {
                        dt.Columns.Add(column.HeaderText, column.ValueType);
                    }

                    //Adding the Rows.
                    foreach (DataGridViewRow row in data.Rows)
                    {
                        dt.Rows.Add();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                        }
                    }

                    //Exporting to Excel.
                    //string folderPath = "C:\\Excel\\";
                    //if (!Directory.Exists(folderPath))
                    //{
                    //    Directory.CreateDirectory(folderPath);
                    //}
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dt, Title);

                        ////Set the color of Header Row.
                        ////A resembles First Column while C resembles Third column.
                        //wb.Worksheet(1).Cells("A1:C1").Style.Fill.BackgroundColor = XLColor.DarkGreen;
                        //for (int i = 1; i <= dt.Rows.Count; i++)
                        //{
                        //    //A resembles First Column while C resembles Third column.
                        //    //Header row is at Position 1 and hence First row starts from Index 2.
                        //    string cellRange = string.Format("A{0}:C{0}", i + 1);
                        //    if (i % 2 != 0)
                        //    {
                        //        wb.Worksheet(1).Cells(cellRange).Style.Fill.BackgroundColor = XLColor.GreenYellow;
                        //    }
                        //    else
                        //    {
                        //        wb.Worksheet(1).Cells(cellRange).Style.Fill.BackgroundColor = XLColor.Yellow;
                        //    }

                        //}
                        //Adjust widths of Columns.
                        wb.Worksheet(1).Columns().AdjustToContents();

                        //Save the Excel file.
                        wb.SaveAs(fichero.FileName);
                        if (File.Exists(fichero.FileName))
                        {
                            Alerts.cFAT100010 alr = new Alerts.cFAT100010("Información", "Exportación Exitosa", MessageBoxIcon.Information);
                            alr.ShowDialog();
                        }
                        else
                        {
                            Alerts.cFAT100010 alr = new Alerts.cFAT100010("Error", "Exportación Fallida", MessageBoxIcon.Error);
                            alr.ShowDialog();
                        }
                    }
                }
                //SaveFileDialog fichero = new SaveFileDialog();
                //fichero.Filter = "Excel (*.xls)|*.xls";
                //if (fichero.ShowDialog() == DialogResult.OK)
                //{
                //    Microsoft.Office.Interop.Excel.Application aplicacion;
                //    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                //    Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                //    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                //    libros_trabajo = aplicacion.Workbooks.Add();
                //    hoja_trabajo =
                //        (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                //    //Recorremos el DataGridView rellenando la hoja de trabajo
                //    for (int i = 0; i < grd.Rows.Count - 1; i++)
                //    {
                //        for (int j = 0; j < grd.Columns.Count; j++)
                //        {
                //            hoja_trabajo.Cells[i + 1, j + 1] = grd.Rows[i].Cells[j].Value.ToString();
                //        }
                //    }
                //    libros_trabajo.SaveAs(fichero.FileName,
                //        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                //    libros_trabajo.Close(true);
                //    aplicacion.Quit();
                //}
            }
        }
    }
}
