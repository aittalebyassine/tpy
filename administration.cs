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
    public partial class administration : Form
    {
        public administration()
        {
            InitializeComponent();
            
        }
        
       
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RFJ2KR8\SQLEXPRESS;Initial Catalog=gestion_note;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void administration_Load(object sender, EventArgs e)
        {

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from professeur  ";
            SqlDataReader dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                guna2ComboBox1.Items.Add(dr.GetValue(0).ToString());
            }
           
            dr.Close();
            con.Close();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from matiere  ";
            SqlDataReader dr1 = cmd.ExecuteReader();

            while (dr1.Read())
            {
                guna2ComboBox2.Items.Add(dr1.GetValue(0).ToString());
            }

            dr.Close();
            con.Close();
           
            guna2ComboBox1.SelectedIndex = 0;
            guna2ComboBox2.SelectedIndex = 0;
           
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
          
        }

        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void guna2GradientButton4_Click_1(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Clear();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = " select matiere.id_etu, note.la_note from matiere,note,professeur where matiere.id_matiere = professeur.id_matiere and matiere.id_matiere = note.id_matiere and matiere.id_matiere = '" + guna2ComboBox2.Text + "' and matiere.id_prof = '" + guna2ComboBox1.Text + "' ";
            SqlDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {

                guna2DataGridView1.Rows.Add(dr1.GetValue(0).ToString(), dr1.GetValue(1).ToString());
            }

            dr1.Close();
            con.Close();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton8_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update professeur set nom='" +guna2TextBox2.Text+ "'  ,  prenom='" + guna2TextBox3.Text + "', id_etu ='" + guna2TextBox4.Text + "', id_matiere='" + guna2TextBox5.Text + "', id_adm='" + guna2TextBox6.Text + "'  where id_pro='" + guna2TextBox1.Text + "'", con);
            int h = cmd.ExecuteNonQuery();
            if (h != 0)
                MessageBox.Show("Bien modifié");
            con.Close();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {

            
           
        }
        private void guna2GradientButton1_Click_2(object sender, EventArgs e)
        {


            
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into professeur values ('"+ guna2TextBox1.Text+ "', '" + guna2TextBox2.Text + "','" + guna2TextBox3.Text + "','" + guna2TextBox4.Text + "','" + guna2TextBox5.Text + "','" + guna2TextBox6.Text + "')", con);
            int h = cmd.ExecuteNonQuery();
            if (h != 0)
                MessageBox.Show("Bien ajouter");
            con.Close();
        }

        private void guna2GradientButton9_Click(object sender, EventArgs e)
        {
            guna2DataGridView2.Rows.Clear();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = " select * from professeur";
            SqlDataReader dr2 = cmd.ExecuteReader();
            while (dr2.Read())
            {

                guna2DataGridView2.Rows.Add(dr2.GetValue(0).ToString(), dr2.GetValue(1).ToString(), dr2.GetValue(2).ToString(), dr2.GetValue(3).ToString(), dr2.GetValue(4).ToString());
            }

            dr2.Close();
            con.Close();

        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from  professeur where id_pro = '"+guna2TextBox1.Text+"'", con);
            int h = cmd.ExecuteNonQuery();
            if (h != 0)
                MessageBox.Show("Bien suprimer");
            con.Close();

        }

        private void guna2GradientButton11_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Clear();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = " select matiere.id_etu, note.la_note from matiere,note,professeur where matiere.id_matiere = professeur.id_matiere and matiere.id_matiere = note.id_matiere and matiere.id_matiere = '" + guna2ComboBox2.Text + "' and matiere.id_prof = '" + guna2ComboBox1.Text + "' ";
            SqlDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {

                guna2DataGridView1.Rows.Add(dr1.GetValue(0).ToString(), dr1.GetValue(1).ToString());
            }

            dr1.Close();
            con.Close();
        }

        private void guna2GradientButton15_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into etudiant values ('" + guna2TextBox12.Text + "', '" + guna2TextBox11.Text + "','" + guna2TextBox10.Text + "','" + guna2TextBox9.Text + "','" + guna2TextBox8.Text + "')", con);
            int h = cmd.ExecuteNonQuery();
            if (h != 0)
                MessageBox.Show("Bien ajouter");
            con.Close();
        }

        private void guna2GradientButton12_Click(object sender, EventArgs e)
        {
            guna2DataGridView2.Rows.Clear();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = " select * from etudiant";
            SqlDataReader dr2 = cmd.ExecuteReader();
            while (dr2.Read())
            {

                guna2DataGridView3.Rows.Add(dr2.GetValue(0).ToString(), dr2.GetValue(1).ToString(), dr2.GetValue(2).ToString(), dr2.GetValue(3).ToString(), dr2.GetValue(4).ToString());
            }

            dr2.Close();
            con.Close();

        }

        private void guna2GradientButton13_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update etudiant  set nom='" + guna2TextBox11.Text + "'  ,  prenom='" + guna2TextBox10.Text + "', id_pro ='" + guna2TextBox9.Text + "', id_matiere='" + guna2TextBox8.Text + "'  where id_etu='" + guna2TextBox12.Text + "'", con);
            int h = cmd.ExecuteNonQuery();
            if (h != 0)
                MessageBox.Show("Bien modifié");
            con.Close();
        }

        private void guna2GradientButton14_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from  etudiant where id_etu = '" + guna2TextBox12.Text + "'", con);
            int h = cmd.ExecuteNonQuery();
            if (h != 0)
                MessageBox.Show("Bien suprimer");
            con.Close();
        }

        private void guna2GradientButton4_Click_2(object sender, EventArgs e)
        {
            panel3.Show();
            panel1.Visible = false;
            panel2.Visible = false;

        }

        private void guna2GradientButton10_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 f1 = new Form1();
            f1.Show();
            
        }

        private void guna2GradientButton17_Click(object sender, EventArgs e)
        {
            panel2.Show();
            panel1.Visible = false;
            panel3.Visible = false;


        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
