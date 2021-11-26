using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sanya_kursach
{
    class database
    {
        public static string conStr = $@"Data Source=62.78.81.19;Initial Catalog=Box_office;User ID=24-тпдавыдовав;Password=107114";

        public static DataTable ExecuteSqlCommand(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, conStr);
                da.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
            return dt;
        }
    }
}
