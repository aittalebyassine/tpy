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
    public partial class professeur : Form
    {
        public professeur()
        {
            InitializeComponent();
        }
        public professeur(string a)
        {
            InitializeComponent();
            label3.Text = a;
        }
     
       

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-RFJ2KR8\SQLEXPRESS;Initial Catalog=gestion_note;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        string idpro;
        private void professeur_Load(object sender, EventArgs e)
        {


            
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select professeur.id_pro from professeur , administrateur where professeur.id_adm=administrateur.id_adm and mot_de_passe = '"+label3.Text+"' ";
            SqlDataReader dr1 = cmd.ExecuteReader();

            while (dr1.Read())
            {
                idpro = dr1.GetValue(0).ToString();
            }

            dr1.Close();
            con.Close();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from matiere where id_prof = '" +idpro+"' ";
            SqlDataReader dr2 = cmd.ExecuteReader();

            while (dr2.Read())
            {
                guna2ComboBox1.Items.Add(dr2.GetValue(1).ToString());
            }

            dr2.Close();
            con.Close();
            label3.Visible = false;
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Clear();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = " select etudiant.id_etu,etudiant.nom,etudiant.prenom from etudiant,matiere where etudiant.id_matiere=matiere.id_matiere and matiere.nom='"+ guna2ComboBox1.Text+"'";

            SqlDataReader dr3 = cmd.ExecuteReader();
            while (dr3.Read())
            {

                guna2DataGridView1.Rows.Add(dr3.GetValue(0).ToString(), dr3.GetValue(1).ToString(),dr3.GetValue(2).ToString());
            }

            dr3.Close();
            con.Close();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void guna2GradientButton8_Click(object sender, EventArgs e)
        {
            guna2DataGridView2.Rows.Clear();
            int i = guna2DataGridView1.CurrentCell.RowIndex;
            string idetud = guna2DataGridView1.Rows[i].Cells[0].Value.ToString();
            
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = " select note.id_note ,note.la_note,note.id_matiere from note,matiere where matiere.id_matiere=note.id_matiere and  matiere.id_etu='" + idetud + "' and matiere.nom='" + guna2ComboBox1.Text + "'";

            SqlDataReader dr5 = cmd.ExecuteReader();
            while (dr5.Read())
            {

                guna2DataGridView2.Rows.Add(dr5.GetValue(0).ToString(), dr5.GetValue(1).ToString(), dr5.GetValue(2).ToString());
            }

            dr5.Close();
            con.Close();
            
        }

        private void guna2GradientButton9_Click(object sender, EventArgs e)
        {
          
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            int i = guna2DataGridView2.CurrentCell.RowIndex;
            string idetude = guna2DataGridView2.Rows[i].Cells[0].Value.ToString();
            

            con.Open();

            SqlCommand cmd= new SqlCommand("delete from note where id_note = '" + idetude + "'", con);
           
            int h1 = cmd.ExecuteNonQuery();
            if (h1 == 1)
                MessageBox.Show("Bien suprimer");
            con.Close();
            con.Close();
          
        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            int i = guna2DataGridView2.CurrentCell.RowIndex;
            string aa = guna2DataGridView2.Rows[i].Cells[0].Value.ToString();
            string bb = guna2DataGridView2.Rows[i].Cells[1].Value.ToString();
            string cc = guna2DataGridView2.Rows[i].Cells[2].Value.ToString();
          
            con.Open();
            SqlCommand cmd = new SqlCommand("update note  set note.la_note= " + float.Parse(bb) + "  ,  id_matiere = '" + cc + "'  where id_note='" + aa + "' ", con);
            int h = cmd.ExecuteNonQuery();
            if (h != 0)
                MessageBox.Show("Bien modifié");
            con.Close();
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            int i = guna2DataGridView2.CurrentCell.RowIndex;
            string idetude1  = guna2DataGridView2.Rows[i].Cells[0].Value.ToString();
            string idetude2 = guna2DataGridView2.Rows[i].Cells[1].Value.ToString();
            string idetude3 = guna2DataGridView2.Rows[i].Cells[2].Value.ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into note values ('" + idetude1 + "', " + float.Parse( idetude2 )+ ",'" + idetude3 + "')", con);
            int h = cmd.ExecuteNonQuery();
            if (h != 0)
                MessageBox.Show("Bien ajouter");
            con.Close();
        }
    }
}
