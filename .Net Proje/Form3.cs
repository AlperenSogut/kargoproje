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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection Baglan = new SqlConnection(@"Data Source =DESKTOP-DGRSG92\SQLEXPRESS; Initial Catalog = Kargo_Sirketi; Integrated Security = True");

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 yeni = new Form4();
            yeni.Show();
            this.Hide();


            try
            {
                if (Baglan.State == ConnectionState.Closed)
                    Baglan.Open();

                string kayit = "insert into Kargoyu_Teslim_Alan_Kisiler (TC_No,Ad_Soyad,Telefon_No,Gonderilen_Nesne,il,ilce,Adres) values (@TC_No,@Ad_Soyad,@Telefon_No,@Gonderilen_Nesne,@il,@ilce,@Adres)";
                

                SqlCommand komut = new SqlCommand(kayit, Baglan);

                komut.Parameters.AddWithValue("@TC_No", textBox1.Text);
                komut.Parameters.AddWithValue("@Ad_Soyad", textBox2.Text);
                komut.Parameters.AddWithValue("@Telefon_No", textBox3.Text);
                komut.Parameters.AddWithValue("@Gonderilen_Nesne", textBox5.Text);
                komut.Parameters.AddWithValue("@il", comboBox1.Text);
                komut.Parameters.AddWithValue("@ilce", comboBox2.Text);
                komut.Parameters.AddWithValue("@Adres", textBox4.Text);



                komut.ExecuteNonQuery();

                Baglan.Close();

            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }

        }

        

        private void Form3_Load(object sender, EventArgs e)
        {
            DataSet daset = new DataSet();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from iller", Baglan);
            adtr.Fill(daset, "iller");
            comboBox1.DisplayMember = "il";
            comboBox1.ValueMember = "il_ID";
            comboBox1.DataSource = daset.Tables["iller"];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet daset = new DataSet();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from ilceler where il='" + comboBox1.Text+"'", Baglan);
            adtr.Fill(daset, "ilceler");
            comboBox2.DisplayMember = "ilce";            
            comboBox2.DataSource = daset.Tables["ilceler"]; 
        }
    }
}
