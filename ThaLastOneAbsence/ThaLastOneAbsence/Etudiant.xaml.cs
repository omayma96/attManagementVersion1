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
    /// <summary>
    /// Logique d'interaction pour Etudiant.xaml
    /// </summary>
    public partial class Etudiant : Window
    {
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
            cnx.ConnectionString = @"Data Source=DESKTOP-OA38PF8;Initial Catalog=Attendance-Management;Integrated Security=True";
            String QuerySelect = "SELECT COUNT(date) FROM Absence WHERE EtudiantId =  " + a;
            SqlCommand cmd = new SqlCommand(QuerySelect, cnx);
            cnx.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                Total_abs.Content = data[0] + " days";
            }
        }
        public void getTotlaAbsJus(string a)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=DESKTOP-OA38PF8;Initial Catalog=Attendance-Management;Integrated Security=True";
            String QuerySelect = "SELECT COUNT(date) FROM Absence WHERE EtudiantId =  " + a;
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
            cnx.ConnectionString = @"Data Source=DESKTOP-OA38PF8;Initial Catalog=Attendance-Management;Integrated Security=True";
            String QuerySelect = "SELECT COUNT(date) FROM Absence WHERE EtudiantId = "+ a;
            SqlCommand cmd = new SqlCommand(QuerySelect, cnx);
            cnx.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                Total_noJust.Content = data[0] + " days";
            }
        }

        public void getAllAbs()
        {
            
        }

        public void GetInfoEtudiant(string a)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=DESKTOP-OA38PF8;Initial Catalog=Attendance-Management;Integrated Security=True";
            String QuerySelect = "Select S.Fullname ,C.Classename , F.Fullname FROM Student as S , Formateur as F , Classe as C Where S.StudentId = "+ a +" and S.FormateurId = F.FormateurId and F.ClassId = C.ClasseId";
            SqlCommand cmd = new SqlCommand(QuerySelect, cnx);
            cnx.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {

                
            }


        }
        //int position = -1;
        private void just_abs(object sender, RoutedEventArgs e)
        {
            //position = this.deatail_abs.SelectedIndex;
            //MessageBox.Show(position.ToString());
            //idClients = int.Parse(this.deatail_abs.Items[position]..Cells[0].Value.ToString());
            DataRowView rows = deatail_abs.SelectedItem as DataRowView;
            int id_student = Convert.ToInt32(rows.Row[0].ToString());
            string date_abs = rows.Row[1].ToString();
            string date_absname = rows.Row[5].ToString();
            MessageBox.Show(id_student.ToString());

            //Microsoft.Win32.OpenFileDialog openFileDialog = new OpenFileDialog();
            //bool? response = openFileDialog.ShowDialog();
            //if(response == true)
            //{
            //    string filepath = openFileDialog.FileName;
            //    string[] f = file.Split('\\');
            //    // to get the only file name
            //    string fn = f[(f.Length) - 1];
            //    string dest = @"C:\Users\youcode\source\repos\lastVersGestiAbs\testt\" + fn;
            //    MessageBox.Show(filepath);

            //}
        }
    }
}
