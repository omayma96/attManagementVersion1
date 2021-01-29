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


        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void butDashboard_MouseDoubleClick(object sender, RoutedEventArgs e)
        {

        }

        private void butFormateur_MouseDoubleClick(object sender, RoutedEventArgs e)
        {

            if (d.dt != null)
            {
                d.dt.Clear();
            }


            DataGrid.Visibility = Visibility.Visible;
            butAjouter.Visibility = Visibility.Visible;
            txtFullname.Visibility = Visibility.Hidden;
            txtEmail.Visibility = Visibility.Hidden;
            txtPassword.Visibility = Visibility.Hidden;
            txtDateNaissance.Visibility = Visibility.Hidden;
            txtClasse.Visibility = Visibility.Hidden;
            txtFormateur.Visibility = Visibility.Hidden;
            txtRoleld.Visibility = Visibility.Hidden;
            lblFullname.Visibility = Visibility.Hidden;
            lblEmail.Visibility = Visibility.Hidden;
            lblPassword.Visibility = Visibility.Hidden;
            lblRoleId.Visibility = Visibility.Hidden;
            lblDateNaissance.Visibility = Visibility.Hidden;
            txtAnnée.Visibility = Visibility.Hidden;
            lblAnnée.Visibility = Visibility.Hidden;
            butVider.Visibility = Visibility.Hidden;
            lblClasse.Visibility = Visibility.Hidden;
            lblFourmateur.Visibility = Visibility.Hidden;
            butEnregister.Visibility = Visibility.Hidden;
            butSupprimer.Visibility = Visibility.Visible;
            butModifier.Visibility = Visibility.Visible;
            butEnregistetModefication.Visibility = Visibility.Hidden;

            d.connecter();
            d.cmd.CommandText = "SELECT f.FormateurId, f.Fullname,f.Email,f.Année,c.Classename from  Formateur f  INNER JOIN Classe c   ON f.ClassId = c.ClasseId";
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            d.dt.Load(d.dr);
            DataGrid.ItemsSource = d.dt.DefaultView;




        }

        private void butSecrétaire_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            /*DataGrid.Visibility = Visibility.Visible;
            d.CONNECTER();
            d.cmd.CommandText = ("select * from Secretaire");
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            d.dt.Load(d.dr);
            DataGrid.ItemsSource = d.dt.DefaultView;
            d.dr.Close();*/

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


        }



        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }
        // Remplir de datagid

        /*  public void RemplirGrid()
          {
              d.cmd.CommandText = "select * form Formateur";
              d.cmd.Connection = d.con;
              d.dr = d.cmd.ExecuteReader();
              d.dt.Load(d.dr);
              DataGrid.ItemsSource = d.dt.DefaultView;
              d.dr.Close();
          }*/

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

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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




            /*d.CONNECTER();
            DataRowView row = DataGrid.SelectedItem as DataRowView;
            var id = row.Row[0].ToString();
*/
            /*this.txtFullname.Text = d.dt.Rows[DataRow][1].ToString();*/
            /* txtFullname.Text = row.Cells[];
  */
        }

        private void butApprenants_MouseDoubleClick(object sender, RoutedEventArgs e)
        {

        }

        private void txtClasse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }


        private void txtFullname_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void lblRoleld_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtClasse_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtRoleld_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



        private void txtRoleld_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        /*  public void VIDER(Control f)
          {

              foreach (Control item in Controls) if (item is TextBox) ((TextBox)item).Clear();

              foreach (Control ct in f.Controls)
              {
                  if (ct.GetType() == typeof(TextBox))
                  {
                      ct.TextInput = "";
                  }

                  if (ct.Controls.Count == 0) ;
                  {
                      VIDER(ct);
                  }

              }
          }*/
    }
}
