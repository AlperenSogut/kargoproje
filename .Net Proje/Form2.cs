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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection Baglan = new SqlConnection(@"Data Source =DESKTOP-DGRSG92\SQLEXPRESS; Initial Catalog = Kargo_Sirketi; Integrated Security = True");

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 yeni = new Form3();
            yeni.Show();
            this.Hide();

            Baglan.Open();

            if (Baglan.State == System.Data.ConnectionState.Open)
            {

                
                try
                {
                    if (Baglan.State == ConnectionState.Closed)
                        Baglan.Open();
                    
                    string kayit = "insert into Kargoyu_Gonderen_Kisiler (TC_No,Ad_Soyad,Telefon_No,Kargoyu_Teslim_Alan_Kisi,Gonderilen_Nesne) values (@TC_No,@Ad_Soyad,@Telefon_No,@Kargoyu_Teslim_Alan_Kisi,@Gonderilen_Nesne)";
                    
                    SqlCommand komut = new SqlCommand(kayit, Baglan);
                    
                    komut.Parameters.AddWithValue("@TC_No", textBox1.Text);
                    komut.Parameters.AddWithValue("@Ad_Soyad", textBox2.Text);                
                    komut.Parameters.AddWithValue("@Telefon_No", textBox3.Text);
                    komut.Parameters.AddWithValue("@Kargoyu_Teslim_Alan_Kisi", textBox4.Text);
                    komut.Parameters.AddWithValue("@Gonderilen_Nesne", textBox5.Text);

                    komut.ExecuteNonQuery();

                    Baglan.Close();
                    
                }
                catch (Exception hata)
                {
                    MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                }

            }


        }


        

    }
}
