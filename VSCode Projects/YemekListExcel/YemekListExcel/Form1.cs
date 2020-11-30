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

namespace YemekListExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void keyPressFunc(KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46 && ch != 44 && ch != 10 )
            {
                e.Handled = true;
                MessageBox.Show("Bir Sayi Giriniz");
            }                                     
        }
        // KUMANYA TEXTBOX 
        private void KumBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }     
        private void KumBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void KumBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void KumBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void KumBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void KumBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void KumBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void KumBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void KumBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void KumBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void KumBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void KumBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void KumBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void KumBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void KumBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        // KAHVALTI TEXTBOX 
        private void KahBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void KahBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void KahBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void KahBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void KahBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void KahBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void KahBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void KahBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void KahBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void KahBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void KahBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void KahBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void KahBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void KahBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void KahBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        // YEMEK TEXTBOX 
        private void YBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void YBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void YBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void YBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void YBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void YBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void YBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void YBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void YBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void YBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void YBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void YBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void YBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void YBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }
        private void YBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressFunc(e);
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            // txtName is your text box id
            string query = string.Concat("INSERT INTO your_tablename (columName) VALUES('", KahBox1.Text, "')");
            SqlConnection con1 = new SqlConnection();
            {
                con1.Open();
                SqlCommand cmd = new SqlCommand(query, con1);
                cmd.ExecuteNonQuery();
            }
        }

        private void aboutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("This product is developed by Berk DOGUS  (2019 August PAS IT Intern)");
        }
    }
}