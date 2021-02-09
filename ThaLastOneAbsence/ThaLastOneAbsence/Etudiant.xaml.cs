using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Data;
using Microsoft.Win32;
using System.IO;

namespace ThaLastOneAbsence
{
    //Data Source = DESKTOP - 122P6H8\SQLEXPRESS;Initial Catalog = lastDataAbs; Integrated Security = True
    /// <summary>
    /// Logique d'interaction pour Etudiant.xaml
    /// </summary>
    public partial class Etudiant : Window
    {
        Connect d = new Connect();
        public Etudiant()
        {
            InitializeComponent();

        }
        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        public void getTotlaAbs(string a)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=DESKTOP-122P6H8\SQLEXPRESS;Initial Catalog=AttManagement;Integrated Security=True";
            String QuerySelect = "SELECT (SELECT COUNT(date) FROM   Absence WHERE  EtudiantId = " + a + " and valAbsence = 1) , (SELECT COUNT(date) FROM   Absence WHERE EtudiantId = " + a + " and valRetard = 1) ";
            SqlCommand cmd = new SqlCommand(QuerySelect, cnx);
            cnx.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                int absDays = Convert.ToInt32(data[0]);
                int absDemiDays = Convert.ToInt32(data[1]) /2 ;
                int lastRes = absDays + absDemiDays;
                Total_abs.Content = lastRes + " days";
            }
        }
        public void getTotlaAbsJus(string a)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=DESKTOP-122P6H8\SQLEXPRESS;Initial Catalog=AttManagement;Integrated Security=True";
            String QuerySelect = "SELECT COUNT(date) FROM Absence WHERE EtudiantId =  " + a + "and Justifier = 1";
            SqlCommand cmd = new SqlCommand(QuerySelect, cnx);
            cnx.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                Total_jus.Content = data[0] + " days";
            }
        }
        public void getTotlaAbsNoJus(string a)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=DESKTOP-122P6H8\SQLEXPRESS;Initial Catalog=AttManagement;Integrated Security=True";
            String QuerySelect = "SELECT COUNT(date) FROM Absence WHERE EtudiantId = " + a + "and Justifier != 1";
            SqlCommand cmd = new SqlCommand(QuerySelect, cnx);
            cnx.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                Total_noJust.Content = data[0] + " days";
            }
        }

        public void getAllAbs(string a)
        {
            d.connecter();
            d.cmd.CommandText = "SELECT * FROM Absence WHERE EtudiantId = " + a + " and valPresence !=1 and Justifier IS NOT NULL";
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            d.dt.Load(d.dr);
            deatail_abs.ItemsSource = d.dt.DefaultView;
            d.dr.Close();
        }

        public void GetInfoEtudiant(string a)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=DESKTOP-122P6H8\SQLEXPRESS;Initial Catalog=AttManagement;Integrated Security=True";
            String QuerySelect = "Select S.Fullname ,C.Classename , F.Fullname FROM Student as S , Formateur as F , Classe as C Where S.StudentId = " + a + " and S.FormateurId = F.FormateurId and F.ClassId = C.ClasseId";
            SqlCommand cmd = new SqlCommand(QuerySelect, cnx);
            cnx.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                name_etud.Content = data[0].ToString();

            }


        }
        //int position = -1;
        string Justif = "";
        //var photo;
        int id_student;
        private void just_abs(object sender, RoutedEventArgs e)
        {
            //position = this.deatail_abs.SelectedIndex;
            //MessageBox.Show(position.ToString());
            //idClients = int.Parse(this.deatail_abs.Items[position]..Cells[0].Value.ToString());
            DataRowView rows = deatail_abs.SelectedItem as DataRowView;
            id_student = Convert.ToInt32(rows.Row[0].ToString());
            string date_abs = rows.Row[1].ToString();
            string date_absname = rows.Row[5].ToString();
            MessageBox.Show(id_student.ToString());

            //Microsoft.Win32.OpenFileDialog openFileDialog = new OpenFileDialog();
            //bool? response = openFileDialog.ShowDialog();
            //if (response == true)
            //{
            //    string filepath = openFileDialog.FileName;
            //    //string[] f = file.Split('\\');
            //    // to get the only file name
            //    //string fn = f[(f.Length) - 1];
            //    //string dest = @"C:\Users\youcode\source\repos\lastVersGestiAbs\testt\" + fn;
            //    MessageBox.Show(filepath);

            //}
            OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All filles";

            if (dialog.ShowDialog() == true)
            {
                //Justif = dialog.FileName.ToString();
                //photo.Source = new BitmapImage(new Uri(dialog.FileName));
                //MessageBox.Show(photo);
            }
            byte[] images = null;
            FileStream Streem = new FileStream(Justif, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(Streem);
            images = brs.ReadBytes((int)Streem.Length);
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=DESKTOP-122P6H8\SQLEXPRESS;Initial Catalog=AttManagement;Integrated Security=True";
            string SqlQuery = "insert Into Justife Values( @images , 'False', " + id_student + ")";
            SqlCommand cmd = new SqlCommand(SqlQuery, cnx);
            cnx.Open();
            SqlDataReader data = cmd.ExecuteReader();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //byte[] images = null;
            //FileStream Streem = new FileStream(Justif, FileMode.Open, FileAccess.Read);
            //BinaryReader brs = new BinaryReader(Streem);
            //images = brs.ReadBytes((int)Streem.Length);
            //SqlConnection cnx = new SqlConnection();
            //cnx.ConnectionString = @"Data Source=DESKTOP-122P6H8\SQLEXPRESS;Initial Catalog=lastDataAbs;Integrated Security=True";
            //string SqlQuery = "insert Into Justife Values( @images , 'False', " + id_student + ")";
            //SqlCommand cmd = new SqlCommand(SqlQuery, cnx);
            //cnx.Open();
            //SqlDataReader data = cmd.ExecuteReader();
        }

        private void deatail_abs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
