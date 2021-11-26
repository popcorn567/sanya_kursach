using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace sanya_kursach
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadGird();
        }

        private void LoadGird()
        {
            dataGridView1.DataSource = database.ExecuteSqlCommand($@"SELECT        tovar.name AS Наименования,
                                                                                   tovar.price AS Цена,
                                                                                   tovar.kol AS Количество,
                                                                                   kassir.fam AS Фамилия,
                                                                                   kassir.nam AS Имя,
                                                                                   kassir.oth AS Отчество
                                                                                   FROM            zakaz INNER JOIN
                                                                                   tovar ON zakaz.ID = tovar.ID INNER JOIN
                                                                                   kassir ON zakaz.ID = kassir.ID");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AddForm().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
          
                var excel = new Excel.Application();
                var workSheet = excel.Workbooks.Add().Sheets[1];
                workSheet.Name = "Отчет";
                workSheet.Cells[2, 3] = "Чек покупки";
                dynamic range = workSheet.Range[workSheet.Cells[2, 3], workSheet.Cells[2, 3]];
                range.Cells.Font.Name = "Times New Roman";
                range.Cells.Font.Size = 24;
                workSheet.Cells[4, 1] = "№ п\\п";
                workSheet.Columns[1].ColumnWidth = 10;
                workSheet.Cells[4, 2] = "Название";
                workSheet.Columns[2].ColumnWidth = 15;
                workSheet.Cells[4, 3] = "Цена";
                workSheet.Columns[3].ColumnWidth = 20;
                workSheet.Cells[4, 4] = "Количество";
                workSheet.Columns[4].ColumnWidth = 20;
                workSheet.Cells[4, 5] = "Фамилия";
                workSheet.Columns[5].ColumnWidth = 30;
                workSheet.Cells[4, 6] = "Имя";
                workSheet.Columns[6].ColumnWidth = 30;
                workSheet.Cells[4, 7] = "Отчество";
                workSheet.Columns[7].ColumnWidth = 30;


                workSheet.Cells[3, 2] = "Дата " + DateTime.Now;

                range = workSheet.Range[workSheet.Cells[4, 1], workSheet.Cells[4, 5]];
                range.Font.Bold = true;



                string sql = @"SELECT        tovar.name AS Наименование, tovar.price AS Цена, tovar.kol AS Количество, kassir.fam AS Фамилия, kassir.nam AS Имя, kassir.oth AS Отчество
FROM            zakaz INNER JOIN
                         tovar ON zakaz.ID = tovar.ID INNER JOIN
                         kassir ON zakaz.ID = kassir.ID";
                DataTable table = new DataTable();
                new SqlDataAdapter(sql, database.conStr).Fill(table);
                int i = 5;

                foreach (DataRow row in table.Rows)
                {
                    workSheet.Cells[i, 0] = row["Наименование"];
                    workSheet.Cells[i, 1] = row["Цена"];
                    workSheet.Cells[i, 2] = row["Количество"];
                    workSheet.Cells[i, 3] = row["Фамилия"];
                    workSheet.Cells[i, 4] = row["Имя"];
                    workSheet.Cells[i, 5] = row["Отчество"];



                    i++;
                range = workSheet.Range[workSheet.Cells[4, 1], workSheet.Cells[i - 1, 7]];

                range.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;    // внутренние вертикальные
                range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlContinuous;  // внутренние горизонтальные            
                range.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;           // верхняя внешняя
                range.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;         // правая внешняя
                range.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;          // левая внешняя
                range.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                }



                excel.Visible = true;
                excel.UserControl = true;


         
        }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new zakazForm().Show();
        }
    }
}
