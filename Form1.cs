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
namespace tpy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Form1( string a)
        {
            InitializeComponent();
            a = guna2TextBox2.Text;
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RFJ2KR8\SQLEXPRESS;Initial Catalog=gestion_note;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from administrateur where username = '"+ guna2TextBox1.Text + "' and mot_de_passe = '" + float.Parse( guna2TextBox2.Text) + "' ";
            SqlDataReader dr = cmd.ExecuteReader();
            int a = 0; 
            if (dr.Read())
            {

                a = 1;
                    if (dr["fonction"].ToString()=="admin")
                    {

                        this.Hide();
                        administration  ad1 = new administration();
                        ad1.Show();

                    }
                    else if (dr["fonction"].ToString() == "prof")
                    {

                        this.Hide();
                    professeur pr1 = new professeur(guna2TextBox2.Text);
                        pr1.Show();
                    }
                   
            }
            if (a==0)
               {
                    MessageBox.Show("Le login ou le mot de passe est incorrecte", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
            dr.Close();
            con.Close();
            guna2TextBox1.Clear();
            guna2TextBox2.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            


        }
    }
}