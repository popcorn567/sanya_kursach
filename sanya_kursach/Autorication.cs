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
    public partial class Autorication : Form
    {
        public Autorication()
        {
            InitializeComponent();
        }
        private void Autorication_Load(object sender, EventArgs e)
        {

        }
        private void EntranceBtn_Click(object sender, EventArgs e)
        {
            string loginUser = LoginField.Text;
            string passwordUser = PasswordField.Text;


            DataTable table = database.ExecuteSqlCommand($@"SELECT * FROM Users where Logins = '{LoginField.Text}'  and Password = '{PasswordField.Text}'");

            if (table.Rows.Count > 0)
            {
                new AddForm().Show();
                this.Hide();
            }
            else
                MessageBox.Show("Неправильный логин или пароль");
        }


    }
}
