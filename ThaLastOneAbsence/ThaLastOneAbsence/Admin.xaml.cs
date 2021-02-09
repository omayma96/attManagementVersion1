using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using HandyControl.Data;
using HandyControl.Themes;
using HandyControl.Tools;
using System.Windows.Markup;
using System.Data;

namespace ThaLastOneAbsence
{
    /// <summary>
    /// Logique d'interaction pour Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }
       Connect d = new Connect();

        // ****************************************************** Formateur ********************************************************************

        private void butFormateur_MouseDoubleClick(object sender, RoutedEventArgs e)
        {

            if (d.dt != null)
            {
                d.dt.Clear();
            }

            DataGridApprennent.Visibility = Visibility.Hidden;
            DataGridApprennentJEE.Visibility = Visibility.Hidden;
            DataGridApprennentFEBE.Visibility = Visibility.Hidden;
            DataGridSecrétaire.Visibility = Visibility.Hidden;
            DataGrid.Visibility = Visibility.Visible;
            butAjouter.Visibility = Visibility.Visible;
            txtFullname.Visibility = Visibility.Hidden;
            txtEmail.Visibility = Visibility.Hidden;
            txtPassword.Visibility = Visibility.Hidden;
            txtdateNaissance.Visibility = Visibility.Hidden;
            txtClasse.Visibility = Visibility.Hidden;
            txtFormateur.Visibility = Visibility.Hidden;
            txtRoleld.Visibility = Visibility.Hidden;
            lblFullname.Visibility = Visibility.Hidden;
            lblEmail.Visibility = Visibility.Hidden;
            lblPassword.Visibility = Visibility.Hidden;
            lblRoleId.Visibility = Visibility.Hidden;
            lbldateNaissance.Visibility = Visibility.Hidden;
            txtAnnée.Visibility = Visibility.Hidden;
            lblAnnée.Visibility = Visibility.Hidden;
            butVider.Visibility = Visibility.Hidden;
            lblClasse.Visibility = Visibility.Hidden;
            lblFourmateur.Visibility = Visibility.Hidden;
            lblFormateurId.Visibility = Visibility.Hidden;
            txFormateurId.Visibility = Visibility.Hidden;
            butEnregister.Visibility = Visibility.Hidden;
            butSupprimer.Visibility = Visibility.Visible;
            butModifier.Visibility = Visibility.Visible;
            butEnregistetModefication.Visibility = Visibility.Hidden;
            AjouterSecretaire.Visibility = Visibility.Hidden;
            ModifirerSecretaire.Visibility = Visibility.Hidden;
            EnregistrerModificationSecretaire.Visibility = Visibility.Hidden;
            EnregistrerSecretaire.Visibility = Visibility.Hidden;
            txtdateNaissance.Visibility = Visibility.Hidden;
            lbldateNaissance.Visibility = Visibility.Hidden;
            EnregistrerStudent.Visibility = Visibility.Hidden;
            AjouterStudent.Visibility = Visibility.Hidden;
            ModifirerStudent.Visibility = Visibility.Hidden;
            SupprimerStudent.Visibility = Visibility.Hidden;
            SupprimerSecretaire.Visibility = Visibility.Hidden;
            EnregistrerStudent.Visibility = Visibility.Hidden;
            ModifirerStudent.Visibility = Visibility.Hidden;
            EnregistrerModificationStudent.Visibility = Visibility.Hidden;


            d.connecter();
            d.cmd.CommandText = "SELECT f.FormateurId, f.Fullname,f.Email,f.Année,c.Classename from  Formateur f  INNER JOIN Classe c   ON f.ClassId = c.ClasseId";
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            d.dt.Load(d.dr);
            DataGrid.ItemsSource = d.dt.DefaultView;




        }





        private void butAjouter_Click(object sender, RoutedEventArgs e)
        {


            DataGrid.Visibility = Visibility.Hidden;
            txtFullname.Visibility = Visibility.Visible;
            txtEmail.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Visible;
            txtClasse.Visibility = Visibility.Visible;
            txtRoleld.Visibility = Visibility.Visible;
            lblFullname.Visibility = Visibility.Visible;
            lblEmail.Visibility = Visibility.Visible;
            lblPassword.Visibility = Visibility.Visible;
            lblRoleId.Visibility = Visibility.Visible;
            lblClasse.Visibility = Visibility.Visible;
            txtAnnée.Visibility = Visibility.Visible;
            lblAnnée.Visibility = Visibility.Visible;
            butEnregister.Visibility = Visibility.Visible;
            butAjouter.Visibility = Visibility.Visible;
            butVider.Visibility = Visibility.Visible;
            butSupprimer.Visibility = Visibility.Hidden;
            butModifier.Visibility = Visibility.Hidden;
            SupprimerSecretaire.Visibility = Visibility.Hidden;
            butAjouter.Visibility = Visibility.Hidden;


        }


        private void butEnregister_Click(object sender, RoutedEventArgs e)
        {
            d.connecter();
            d.cmd = new SqlCommand(" insert into Formateur (Fullname,email,password,Année,RoleId,ClassId) values ('" + txtFullname.Text + "','" + txtEmail.Text + "','" + txtPassword.Text + "'," + txtAnnée.Text + "," + txtRoleld.SelectedItem + ",'" + txtClasse.SelectedItem + "')", d.con);
            d.cmd.Connection = d.con;
            d.cmd.ExecuteNonQuery();
            d.con.Close();
        }

        private void butVider_Click(object sender, RoutedEventArgs e)
        {
            txtFullname.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtAnnée.Clear();
            txtRoleld.Text = "";
            txtClasse.Text = "";
            txFormateurId.Text = "";
            txtdateNaissance.Text = "";
        }



        private void loadData(object sender, RoutedEventArgs e)
        {
            rempliertxtRoleld();
            rempliertxtClasse();

        }

        public void rempliertxtRoleld()
        {
            d.connecter();
            d.cmd.Connection = d.con;
            d.cmd = new SqlCommand("select [Rolename] from Role", d.con);
            SqlDataReader dr = d.cmd.ExecuteReader();


            while (dr.Read())
            {

                txtRoleld.Items.Add(dr["Rolename"].ToString());

            }
            d.con.Close();
        }

        public void rempliertxtClasse()
        {
            d.connecter();
            d.cmd.Connection = d.con;
            d.cmd = new SqlCommand("select [Classename] from Classe", d.con);
            SqlDataReader dr = d.cmd.ExecuteReader();


            while (dr.Read())
            {

                txtClasse.Items.Add(dr["Classename"].ToString());

            }
            d.con.Close();
        }

        private void butSupprimer_Click(object sender, RoutedEventArgs e)
        {

            DataRowView row = DataGrid.SelectedItem as DataRowView;
            var id = row.Row[0].ToString();

            d.connecter();
            d.cmd.CommandText = "DELETE FROM Formateur WHERE FormateurId = '" + id + "'";
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            d.dt.Load(d.dr);
            DataGrid.ItemsSource = d.dt.DefaultView;
            d.dr.Close();
        }

        private void butEnregistetModefication_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = DataGrid.SelectedItem as DataRowView;
            var id = row.Row[0].ToString();

            d.connecter();
            d.cmd.CommandText = "update Formateur set Fullname ='" + txtFullname.Text + "',email ='" + txtEmail.Text + "',password ='" + txtPassword.Text + "',Année =" + txtAnnée.Text + ",RoleId =" + txtRoleld.SelectedItem + ",ClassId ='" + txtClasse.SelectedItem + "' WHERE FormateurId = '" + id + "'";
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            d.dt.Load(d.dr);
            DataGrid.ItemsSource = d.dt.DefaultView;
            d.dr.Close();
        }

        private void butModifier_Click(object sender, RoutedEventArgs e)
        {

            DataGrid.Visibility = Visibility.Hidden;
            txtFullname.Visibility = Visibility.Visible;
            txtEmail.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Visible;
            txtClasse.Visibility = Visibility.Visible;
            txtRoleld.Visibility = Visibility.Visible;
            lblFullname.Visibility = Visibility.Visible;
            lblEmail.Visibility = Visibility.Visible;
            lblPassword.Visibility = Visibility.Visible;
            lblRoleId.Visibility = Visibility.Visible;
            lblClasse.Visibility = Visibility.Visible;
            txtAnnée.Visibility = Visibility.Visible;
            lblAnnée.Visibility = Visibility.Visible;
            butEnregistetModefication.Visibility = Visibility.Visible;
            butAjouter.Visibility = Visibility.Hidden;
            butSupprimer.Visibility = Visibility.Hidden;

        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        // ****************************************************** Secrétaire ********************************************************************


        private void butSecrétaire_MouseDoubleClick(object sender, RoutedEventArgs e)
        {


            if (d.dmt != null)
            {
                d.dmt.Clear();
            }

            DataGridApprennent.Visibility = Visibility.Hidden;
            DataGridApprennentJEE.Visibility = Visibility.Hidden;
            DataGridApprennentFEBE.Visibility = Visibility.Hidden;
            DataGrid.Visibility = Visibility.Hidden;
            DataGridSecrétaire.Visibility = Visibility.Visible;
            AjouterSecretaire.Visibility = Visibility.Visible;
            txtFullname.Visibility = Visibility.Hidden;
            txtEmail.Visibility = Visibility.Hidden;
            txtPassword.Visibility = Visibility.Hidden;
            txtClasse.Visibility = Visibility.Hidden;
            txtRoleld.Visibility = Visibility.Hidden;
            lblFullname.Visibility = Visibility.Hidden;
            lblEmail.Visibility = Visibility.Hidden;
            lblPassword.Visibility = Visibility.Hidden;
            lblRoleId.Visibility = Visibility.Hidden;
            lblClasse.Visibility = Visibility.Hidden;
            txtAnnée.Visibility = Visibility.Hidden;
            lblAnnée.Visibility = Visibility.Hidden;
            txtdateNaissance.Visibility = Visibility.Hidden;
            lbldateNaissance.Visibility = Visibility.Hidden;
            lblFormateurId.Visibility = Visibility.Hidden;
            txFormateurId.Visibility = Visibility.Hidden;
            butEnregister.Visibility = Visibility.Hidden;
            butAjouter.Visibility = Visibility.Hidden;
            butVider.Visibility = Visibility.Hidden;
            butSupprimer.Visibility = Visibility.Hidden;
            butModifier.Visibility = Visibility.Hidden;
            EnregistrerSecretaire.Visibility = Visibility.Hidden;
            butVider.Visibility = Visibility.Hidden;
            butEnregistetModefication.Visibility = Visibility.Hidden;
            ModifirerSecretaire.Visibility = Visibility.Visible;
            EnregistrerModificationSecretaire.Visibility = Visibility.Hidden;
            SupprimerSecretaire.Visibility = Visibility.Visible;
            EnregistrerStudent.Visibility = Visibility.Hidden;
            AjouterStudent.Visibility = Visibility.Hidden;
            ModifirerStudent.Visibility = Visibility.Hidden;
            SupprimerStudent.Visibility = Visibility.Hidden;
            EnregistrerStudent.Visibility = Visibility.Hidden;
            ModifirerStudent.Visibility = Visibility.Hidden;
            EnregistrerModificationStudent.Visibility = Visibility.Hidden;






            d.connecter();
            d.cmd.CommandText = "SELECT s.SecretaireId, s.Fullname,s.Email from  Secretaire s  ";
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            d.dmt.Load(d.dr);
            DataGridSecrétaire.ItemsSource = d.dmt.DefaultView;

        }

        private void AjouterSecretaire_Click(object sender, RoutedEventArgs e)
        {

            DataGridSecrétaire.Visibility = Visibility.Hidden;
            txtFullname.Visibility = Visibility.Visible;
            txtEmail.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Visible;
            txtRoleld.Visibility = Visibility.Visible;
            lblFullname.Visibility = Visibility.Visible;
            lblEmail.Visibility = Visibility.Visible;
            lblPassword.Visibility = Visibility.Visible;
            lblRoleId.Visibility = Visibility.Visible;
            butSupprimer.Visibility = Visibility.Hidden;
            butModifier.Visibility = Visibility.Hidden;
            butVider.Visibility = Visibility.Hidden;
            EnregistrerSecretaire.Visibility = Visibility.Visible;
            butVider.Visibility = Visibility.Visible;
            SupprimerSecretaire.Visibility = Visibility.Hidden;
            ModifirerSecretaire.Visibility = Visibility.Hidden;
            AjouterSecretaire.Visibility = Visibility.Hidden;


        }
        private void EnregistrerSecretaire_Click(object sender, RoutedEventArgs e)
        {
            d.connecter();
            d.cmd = new SqlCommand(" insert into Secretaire  (Fullname,email,password,RoleId) values ('" + txtFullname.Text + "','" + txtEmail.Text + "','" + txtPassword.Text + "'," + txtRoleld.SelectedItem + ")", d.con);
            d.cmd.Connection = d.con;
            d.cmd.ExecuteNonQuery();
            d.con.Close();

        }
        private void ModifirerSecretaire_Click(object sender, RoutedEventArgs e)
        {
            DataGridSecrétaire.Visibility = Visibility.Hidden;
            txtFullname.Visibility = Visibility.Visible;
            txtEmail.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Visible;
            txtRoleld.Visibility = Visibility.Visible;
            lblFullname.Visibility = Visibility.Visible;
            lblEmail.Visibility = Visibility.Visible;
            lblPassword.Visibility = Visibility.Visible;
            lblRoleId.Visibility = Visibility.Visible;
            butSupprimer.Visibility = Visibility.Hidden;
            butModifier.Visibility = Visibility.Hidden;
            butVider.Visibility = Visibility.Hidden;
            EnregistrerSecretaire.Visibility = Visibility.Hidden;
            AjouterSecretaire.Visibility = Visibility.Hidden;
            butVider.Visibility = Visibility.Visible;
            EnregistrerModificationSecretaire.Visibility = Visibility.Visible;
            SupprimerSecretaire.Visibility = Visibility.Hidden;


            /*butEnregistetModefication.Visibility = Visibility.Visible;
            butAjouter.Visibility = Visibility.Hidden;
            butSupprimer.Visibility = Visibility.Hidden;*/

        }
        private void EnregistrerModificationSecretaire_Click(object sender, RoutedEventArgs e)
        {
            DataRowView gow = DataGridSecrétaire.SelectedItem as DataRowView;
            var id = gow.Row[0].ToString();

            d.connecter();
            d.cmd.CommandText = "update Secretaire set Fullname ='" + txtFullname.Text + "',email ='" + txtEmail.Text + "',password ='" + txtPassword.Text + "',RoleId =" + txtRoleld.SelectedItem + " WHERE SecretaireId = '" + id + "'";
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            d.dmt.Load(d.dr);
            DataGridSecrétaire.ItemsSource = d.dmt.DefaultView;
            d.dr.Close();

        }
        private void SupprimerSecretaire_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = DataGridSecrétaire.SelectedItem as DataRowView;
            var id = row.Row[0].ToString();

            d.connecter();
            d.cmd.CommandText = "DELETE FROM Secretaire WHERE SecretaireId = '" + id + "'";
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            d.dmt.Load(d.dr);
            DataGridSecrétaire.ItemsSource = d.dmt.DefaultView;
            d.dr.Close();
        }
        //********************************************************* Apprennent csharp ****************************************************************************


        private void csharp_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (d.dat != null)
            {
                d.dat.Clear();
            }
            DataGrid.Visibility = Visibility.Hidden;
            DataGridSecrétaire.Visibility = Visibility.Hidden;
            txtFullname.Visibility = Visibility.Hidden;
            txtEmail.Visibility = Visibility.Hidden;
            txtPassword.Visibility = Visibility.Hidden;
            txtRoleld.Visibility = Visibility.Hidden;
            lblFullname.Visibility = Visibility.Hidden;
            lblEmail.Visibility = Visibility.Hidden;
            lblPassword.Visibility = Visibility.Hidden;
            lblRoleId.Visibility = Visibility.Hidden;
            txtdateNaissance.Visibility = Visibility.Hidden;
            lbldateNaissance.Visibility = Visibility.Hidden;
            butSupprimer.Visibility = Visibility.Hidden;
            butModifier.Visibility = Visibility.Hidden;
            butVider.Visibility = Visibility.Hidden;
            lblFormateurId.Visibility = Visibility.Hidden;
            txFormateurId.Visibility = Visibility.Hidden;
            EnregistrerSecretaire.Visibility = Visibility.Hidden;
            butVider.Visibility = Visibility.Hidden;
            SupprimerSecretaire.Visibility = Visibility.Hidden;
            ModifirerSecretaire.Visibility = Visibility.Hidden;
            DataGridApprennent.Visibility = Visibility.Visible;
            AjouterStudent.Visibility = Visibility.Visible;
            EnregistrerStudent.Visibility = Visibility.Hidden;
            ModifirerStudent.Visibility = Visibility.Visible;
            EnregistrerModificationStudent.Visibility = Visibility.Hidden;
            SupprimerStudent.Visibility = Visibility.Visible;
            AjouterSecretaire.Visibility = Visibility.Hidden;

            d.connecter();
            d.cmd.CommandText = "SELECT s.StudentId, s.Fullname,s.Email,s.dateNaissance,c.Classename from  Student s  INNER JOIN Classe c   ON s.FormateurId = c.ClasseId where c.ClasseId = 1 ";
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            d.dat.Load(d.dr);
            DataGridApprennent.ItemsSource = d.dat.DefaultView;

        }
        private void AjouterStudent_Click_1(object sender, RoutedEventArgs e)
        {
            DataGridApprennentJEE.Visibility = Visibility.Hidden;
            DataGridApprennentFEBE.Visibility = Visibility.Hidden;
            DataGridApprennent.Visibility = Visibility.Hidden;
            txtFullname.Visibility = Visibility.Visible;
            txtEmail.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Visible;
            txtRoleld.Visibility = Visibility.Visible;
            lblFullname.Visibility = Visibility.Visible;
            lblEmail.Visibility = Visibility.Visible;
            lblPassword.Visibility = Visibility.Visible;
            lblRoleId.Visibility = Visibility.Visible;
            txtdateNaissance.Visibility = Visibility.Visible;
            lbldateNaissance.Visibility = Visibility.Visible;
            txtClasse.Visibility = Visibility.Visible;
            lblClasse.Visibility = Visibility.Visible;
            lblFormateurId.Visibility = Visibility.Visible;
            txFormateurId.Visibility = Visibility.Visible;
            butVider.Visibility = Visibility.Visible;
            EnregistrerStudent.Visibility = Visibility.Visible;
            AjouterStudent.Visibility = Visibility.Hidden;
            ModifirerStudent.Visibility = Visibility.Hidden;
            SupprimerStudent.Visibility = Visibility.Hidden;

        }

        private void EnregistrerStudent_Click(object sender, RoutedEventArgs e)
        {
            d.connecter();
            d.cmd = new SqlCommand(" insert into Student  (Fullname,email,password,dateNaissance,RoleId,FormateurId) values ('" + txtFullname.Text + "','" + txtEmail.Text + "','" + txtPassword.Text + "','" + txtdateNaissance.Text + "'," + txtRoleld.SelectedItem + "," + txFormateurId.SelectedItem + ")", d.con);
            d.cmd.Connection = d.con;
            d.cmd.ExecuteNonQuery();
            d.con.Close();
        }
        private void loadeDataGridApprennent(object sender, RoutedEventArgs e)
        {
            d.connecter();
            d.cmd.Connection = d.con;
            d.cmd = new SqlCommand("select [FormateurId] from Formateur", d.con);
            SqlDataReader dr = d.cmd.ExecuteReader();


            while (dr.Read())
            {

                txFormateurId.Items.Add(dr["FormateurId"].ToString());

            }
            d.con.Close();

        }

        private void ModifirerStudent_Click(object sender, RoutedEventArgs e)
        {
            DataGridApprennentJEE.Visibility = Visibility.Hidden;
            DataGridApprennentFEBE.Visibility = Visibility.Hidden;
            DataGridApprennent.Visibility = Visibility.Hidden;
            txtFullname.Visibility = Visibility.Visible;
            txtEmail.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Visible;
            txtRoleld.Visibility = Visibility.Visible;
            lblFullname.Visibility = Visibility.Visible;
            lblEmail.Visibility = Visibility.Visible;
            lblPassword.Visibility = Visibility.Visible;
            lblRoleId.Visibility = Visibility.Visible;
            txtdateNaissance.Visibility = Visibility.Visible;
            lbldateNaissance.Visibility = Visibility.Visible;
            txtClasse.Visibility = Visibility.Visible;
            lblClasse.Visibility = Visibility.Visible;
            lblFormateurId.Visibility = Visibility.Visible;
            txFormateurId.Visibility = Visibility.Visible;
            butVider.Visibility = Visibility.Visible;
            EnregistrerStudent.Visibility = Visibility.Hidden;
            AjouterStudent.Visibility = Visibility.Hidden;
            ModifirerStudent.Visibility = Visibility.Hidden;
            EnregistrerModificationStudent.Visibility = Visibility.Visible;
            SupprimerStudent.Visibility = Visibility.Hidden;
        }
        private void EnregistrerModificationStudent_Click(object sender, RoutedEventArgs e)
        {
            DataRowView gow = DataGridApprennent.SelectedItem as DataRowView;
            var id = gow.Row[0].ToString();

            d.connecter();
            d.cmd.CommandText = "update Student set Fullname ='" + txtFullname.Text + "',email ='" + txtEmail.Text + "',password ='" + txtPassword.Text + "',dateNaissance ='" + txtdateNaissance.Text + "',RoleId =" + txtRoleld.SelectedItem + ",FormateurId =" + txFormateurId.SelectedItem + " WHERE StudentId = '" + id + "'";
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            d.dat.Load(d.dr);
            DataGridApprennent.ItemsSource = d.dat.DefaultView;
            d.dr.Close();
        }
        private void SupprimerStudent_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = DataGridApprennent.SelectedItem as DataRowView;
            var id = row.Row[0].ToString();

            d.connecter();
            d.cmd.CommandText = "DELETE FROM Student WHERE StudentId = '" + id + "'";
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            d.dat.Load(d.dr);
            DataGridApprennent.ItemsSource = d.dat.DefaultView;
            d.dr.Close();

        }


        //********************************************************* Apprennent JEE ****************************************************************************

        private void JEE_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (d.dat != null)
            {
                d.dat.Clear();
            }
            DataGridApprennentJEE.Visibility = Visibility.Visible;
            DataGridApprennentFEBE.Visibility = Visibility.Hidden;
            DataGrid.Visibility = Visibility.Hidden;
            DataGridSecrétaire.Visibility = Visibility.Hidden;
            DataGridApprennent.Visibility = Visibility.Hidden;
            txtFullname.Visibility = Visibility.Hidden;
            txtEmail.Visibility = Visibility.Hidden;
            txtPassword.Visibility = Visibility.Hidden;
            txtRoleld.Visibility = Visibility.Hidden;
            lblFullname.Visibility = Visibility.Hidden;
            lblEmail.Visibility = Visibility.Hidden;
            lblPassword.Visibility = Visibility.Hidden;
            lblRoleId.Visibility = Visibility.Hidden;
            txtdateNaissance.Visibility = Visibility.Hidden;
            lbldateNaissance.Visibility = Visibility.Hidden;
            butSupprimer.Visibility = Visibility.Hidden;
            butModifier.Visibility = Visibility.Hidden;
            butVider.Visibility = Visibility.Hidden;
            lblFormateurId.Visibility = Visibility.Hidden;
            txFormateurId.Visibility = Visibility.Hidden;
            EnregistrerSecretaire.Visibility = Visibility.Hidden;
            butVider.Visibility = Visibility.Hidden;
            SupprimerSecretaire.Visibility = Visibility.Hidden;
            ModifirerSecretaire.Visibility = Visibility.Hidden;
            AjouterStudent.Visibility = Visibility.Visible;
            EnregistrerStudent.Visibility = Visibility.Hidden;
            ModifirerStudent.Visibility = Visibility.Visible;
            EnregistrerModificationStudent.Visibility = Visibility.Hidden;
            SupprimerStudent.Visibility = Visibility.Visible;
            AjouterSecretaire.Visibility = Visibility.Hidden;

            d.connecter();
            d.cmd.CommandText = "SELECT s.StudentId, s.Fullname,s.Email,s.dateNaissance,c.Classename from  Student s  INNER JOIN Classe c   ON s.FormateurId = c.ClasseId where c.ClasseId = 2 ";
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            d.dat.Load(d.dr);
            DataGridApprennentJEE.ItemsSource = d.dat.DefaultView;

        }
        //********************************************************* Apprennent FEBE ****************************************************************************

        private void FEBE_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (d.dat != null)
            {
                d.dat.Clear();
            }
            DataGridApprennentFEBE.Visibility = Visibility.Visible;
            DataGridApprennentJEE.Visibility = Visibility.Hidden;
            DataGrid.Visibility = Visibility.Hidden;
            DataGridSecrétaire.Visibility = Visibility.Hidden;
            DataGridApprennent.Visibility = Visibility.Hidden;
            txtFullname.Visibility = Visibility.Hidden;
            txtEmail.Visibility = Visibility.Hidden;
            txtPassword.Visibility = Visibility.Hidden;
            txtRoleld.Visibility = Visibility.Hidden;
            lblFullname.Visibility = Visibility.Hidden;
            lblEmail.Visibility = Visibility.Hidden;
            lblPassword.Visibility = Visibility.Hidden;
            lblRoleId.Visibility = Visibility.Hidden;
            txtdateNaissance.Visibility = Visibility.Hidden;
            lbldateNaissance.Visibility = Visibility.Hidden;
            butSupprimer.Visibility = Visibility.Hidden;
            butModifier.Visibility = Visibility.Hidden;
            butVider.Visibility = Visibility.Hidden;
            lblFormateurId.Visibility = Visibility.Hidden;
            txFormateurId.Visibility = Visibility.Hidden;
            EnregistrerSecretaire.Visibility = Visibility.Hidden;
            butVider.Visibility = Visibility.Hidden;
            SupprimerSecretaire.Visibility = Visibility.Hidden;
            ModifirerSecretaire.Visibility = Visibility.Hidden;
            AjouterStudent.Visibility = Visibility.Visible;
            EnregistrerStudent.Visibility = Visibility.Hidden;
            ModifirerStudent.Visibility = Visibility.Visible;
            EnregistrerModificationStudent.Visibility = Visibility.Hidden;
            SupprimerStudent.Visibility = Visibility.Visible;
            AjouterSecretaire.Visibility = Visibility.Hidden;

            d.connecter();
            d.cmd.CommandText = "SELECT s.StudentId, s.Fullname,s.Email,s.dateNaissance,c.Classename from  Student s  INNER JOIN Classe c   ON s.FormateurId = c.ClasseId where c.ClasseId = 3 ";
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            d.dat.Load(d.dr);
            DataGridApprennentFEBE.ItemsSource = d.dat.DefaultView;

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var text = textboxSearch.Text.Trim().ToLower();
                var row1 = d.dt.AsEnumerable()
                                .Where(row =>
                                     string.IsNullOrEmpty(text)
                                     ? true
                                     : row["Fullname"].ToString().ToLower().Contains(text) ?
                                     true
                                     : row["Email"].ToString().ToLower().Contains(text)
                                         ).CopyToDataTable();
                DataGrid.ItemsSource = row1.DefaultView;
                DataGridApprennent.ItemsSource = row1.DefaultView;
                DataGridApprennentJEE.ItemsSource = row1.DefaultView;
                DataGridApprennentFEBE.ItemsSource = row1.DefaultView;
                DataGridSecrétaire.ItemsSource = row1.DefaultView;
            }
            catch (Exception)
            {

            }
        }
    }
}
