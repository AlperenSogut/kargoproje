using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp12
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        SqlConnection Baglan = new SqlConnection(@"Data Source =DESKTOP-DGRSG92\SQLEXPRESS; Initial Catalog = Kargo_Sirketi; Integrated Security = True");

        

        private void getir2()
        {

            SqlDataAdapter cod = new SqlDataAdapter("SELECT * FROM  Kargoyu_Gonderen_Kisiler ", Baglan);
            DataSet ds = new DataSet();
            cod.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            Baglan.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
            getir2();
        }
    }
}
