using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sanya_kursach
{
    public partial class zakazForm : Form
    {
        public zakazForm()
        {
            InitializeComponent();
        }

        private void zakazForm_Load(object sender, EventArgs e)
        {
            LoadGrid();
            LoadComboBox();
            LoadComboBox2();
        }
        private void LoadGrid()
        {
            dataGridView1.DataSource = database.ExecuteSqlCommand($@"select * from zakaz");
            dataGridView2.DataSource = database.ExecuteSqlCommand($@"select * from tovar");
            dataGridView3.DataSource = database.ExecuteSqlCommand($@"select * from kassir");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = database.ExecuteSqlCommand($@"INSERT INTO [dbo].[zakaz]
           ([fk_tovar]
           ,[fk_prodavez]

           ,[price]
           ,[kol])
     VALUES
           ('{comboBox1.Text}','{comboBox2.Text}','{textBox1.Text}','{textBox2.Text}')");
            LoadGrid();
        }

        private void LoadComboBox()
        {
            DataTable table = database.ExecuteSqlCommand(@" select * from kassir");

            for (int i = 0; i < table.Rows.Count; i++)
            {
                comboBox1.Items.Add(table.Rows[i][0].ToString());
            }

            
        }
        private void LoadComboBox2()
        {
            DataTable table = database.ExecuteSqlCommand(@" select * from tovar");

            for (int i = 0; i < table.Rows.Count; i++)
            {
                comboBox2.Items.Add(table.Rows[i][0].ToString());

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainForm().Show();
        }
    }
}
