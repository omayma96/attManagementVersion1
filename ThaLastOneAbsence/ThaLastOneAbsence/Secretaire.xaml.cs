using HandyControl.Data;
using HandyControl.Themes;
using HandyControl.Tools;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.VisualBasic;
using System.IO;


namespace ThaLastOneAbsence
{
    /// <summary>
    /// Logique d'interaction pour Secretaire.xaml
    /// </summary>
    public partial class Secretaire : Window
    {

        [DefaultProperty("Items")]
        [ContentProperty("Items")]
        [TemplatePart(Name = " ", Type = typeof(Panel))]


        public class HeaderedSimpleItemsControl : SimpleItemsControl
        {

        }
        public class SideMenu : HeaderedSimpleItemsControl
        {

        }
        public class SimpleItemsControl : Control
        {

        }


        public Secretaire()
        {
            InitializeComponent();
            InitializeComponent();
            ConfigHelper.Instance.SetLang("fr");
            showDT();
        }
        public void UpdateSkin(SkinType skin)
        {
            SharedResourceDictionary.SharedDictionaries.Clear();
            Resources.MergedDictionaries.Add(ResourceHelper.GetSkin(skin));
            Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/HandyControl;component/Themes/Theme.xaml")
            });

        }

        Connect c = new Connect();
        public void showDT()
        {
            c.connecter();
            c.cmd.Connection = c.con;
            date_today.Content = "Aujourd'hui le : " + dateN;
            //  c.dr = c.cmd.ExecuteReader();
            //c.dt.Load(c.dr);
            //c.dr.Close();
        }
        /*      public void ShowDT()
              {
                  c.connecter();
                 // c.cmd.CommandText = "SELECT s.StudentId,s.Fullname,s.Email,a.valAbsence,a.valRetard,a.valPresence  from Student s   INNER JOIN Absence A ON s.StudentId=a.EtudiantId  ";
                  c.cmd.Connection = c.con;
                  c.dr = c.cmd.ExecuteReader();
                  c.dt.Load(c.dr);
                 // dg.ItemsSource = c.dt.DefaultView;
                  c.dr.Close();
              }*/


        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }





        private void btn_dashboard_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (c.dt != null)
            {
                c.dt.Clear();
            }
            dg_Dash.Visibility = Visibility.Visible;
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=DESKTOP-OA38PF8;Initial Catalog=Attendance-Management;Integrated Security=True";
            String QuerySelect = "SELECT COUNT(dateAbsence) FROM Absence WHERE Absence.valPresence=1 AND CAST(Absence.dateAbsence AS DATE) = CAST(GETDATE() AS DATE)";
            SqlCommand cmd = new SqlCommand(QuerySelect, cnx);
            cnx.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                ValP.Content = data[0];
            }

            datetimepicker.Visibility = Visibility.Hidden;
            lab_filtre.Visibility = Visibility.Hidden;
            date_today.Visibility = Visibility.Hidden;

            dg.Visibility = Visibility.Hidden;
            dg_RE.Visibility = Visibility.Hidden;
            dg_ABS.Visibility = Visibility.Hidden;
            dg_C.Visibility = Visibility.Hidden;
            dg_JEE.Visibility = Visibility.Hidden;
            dg_FEBE.Visibility = Visibility.Hidden;
            dg_Classe1.Visibility = Visibility.Hidden;
            dg_Classe2.Visibility = Visibility.Hidden;
            dg_Classe3.Visibility = Visibility.Hidden;
            dg_Classe4.Visibility = Visibility.Hidden;

            val_AbsM.Visibility = Visibility.Visible;
            val_JSM.Visibility = Visibility.Visible;
            val_JSVM.Visibility = Visibility.Visible;

            cer_Ab.Visibility = Visibility.Visible;
            cer_Js.Visibility = Visibility.Visible;
            cer_V.Visibility = Visibility.Visible;

            lab_tabs.Visibility = Visibility.Visible;
            lab_tjs.Visibility = Visibility.Visible;
            lab_tv.Visibility = Visibility.Visible;

            rec_Ab.Visibility = Visibility.Visible;
            rec_Js.Visibility = Visibility.Visible;
            rec_V.Visibility = Visibility.Visible;


        }
        public class checkedBoxIte
        {

            public bool MyBool { get; set; }
        }

        private void btn_abs_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (c.dt != null)
            {
                c.dt.Clear();
            }
            dg_Dash.Visibility = Visibility.Hidden;
            dg.Visibility = Visibility.Hidden;
            dg_RE.Visibility = Visibility.Hidden;
            dg_ABS.Visibility = Visibility.Visible;
            dg_C.Visibility = Visibility.Hidden;
            dg_JEE.Visibility = Visibility.Hidden;
            dg_FEBE.Visibility = Visibility.Hidden;
            dg_Classe1.Visibility = Visibility.Hidden;
            dg_Classe2.Visibility = Visibility.Hidden;
            dg_Classe3.Visibility = Visibility.Hidden;
            dg_Classe4.Visibility = Visibility.Hidden;



            datetimepicker.Visibility = Visibility.Visible;
            lab_filtre.Visibility = Visibility.Visible;
            date_today.Visibility = Visibility.Visible;

            val_AbsM.Visibility = Visibility.Hidden;
            val_JSM.Visibility = Visibility.Hidden;
            val_JSVM.Visibility = Visibility.Hidden;

            cer_Ab.Visibility = Visibility.Hidden;
            cer_Js.Visibility = Visibility.Hidden;
            cer_V.Visibility = Visibility.Hidden;

            lab_tabs.Visibility = Visibility.Hidden;
            lab_tjs.Visibility = Visibility.Hidden;
            lab_tv.Visibility = Visibility.Hidden;

            rec_Ab.Visibility = Visibility.Hidden;
            rec_Js.Visibility = Visibility.Hidden;
            rec_V.Visibility = Visibility.Hidden;

            c.cmd.CommandText = " SELECT Student.StudentId, Student.Fullname As Nom , Student.image, Classe.Classename As Classe from Student LEFT JOIN Classe ON Classe.ClasseId = Student.ClasseId  LEFT JOIN Absence ON Student.StudentId = Absence.EtudiantId LEFT JOIN Justification On Justification.AbsenceId = Absence.AbsenceId   where Absence.valAbsence = 1 AND CAST(Absence.dateAbsence AS DATE) = CAST(GETDATE() AS DATE) ";

            c.dr = c.cmd.ExecuteReader();
            c.dt.Load(c.dr);
            dg_ABS.ItemsSource = c.dt.DefaultView;

            c.dr.Close();

        }



        private void btn_ret_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (c.dt != null)
            {
                c.dt.Clear();
            }
            dg_Dash.Visibility = Visibility.Hidden;
            dg.Visibility = Visibility.Hidden;
            dg_ABS.Visibility = Visibility.Hidden;
            dg_C.Visibility = Visibility.Hidden;
            dg_JEE.Visibility = Visibility.Hidden;
            dg_FEBE.Visibility = Visibility.Hidden;
            dg_Classe1.Visibility = Visibility.Hidden;
            dg_Classe2.Visibility = Visibility.Hidden;
            dg_Classe3.Visibility = Visibility.Hidden;
            dg_Classe4.Visibility = Visibility.Hidden;

            datetimepicker.Visibility = Visibility.Visible;
            lab_filtre.Visibility = Visibility.Visible;
            date_today.Visibility = Visibility.Visible;

            val_AbsM.Visibility = Visibility.Hidden;
            val_JSM.Visibility = Visibility.Hidden;
            val_JSVM.Visibility = Visibility.Hidden;

            cer_Ab.Visibility = Visibility.Hidden;
            cer_Js.Visibility = Visibility.Hidden;
            cer_V.Visibility = Visibility.Hidden;

            lab_tabs.Visibility = Visibility.Hidden;
            lab_tjs.Visibility = Visibility.Hidden;
            lab_tv.Visibility = Visibility.Hidden;

            rec_Ab.Visibility = Visibility.Hidden;
            rec_Js.Visibility = Visibility.Hidden;
            rec_V.Visibility = Visibility.Hidden;

            dg_RE.Visibility = Visibility.Visible;
            c.cmd.CommandText = " SELECT Student.Fullname As Nom , Student.image, Classe.Classename As Classe from Student LEFT JOIN Classe ON Classe.ClasseId = Student.ClasseId  LEFT JOIN Absence ON Student.StudentId = Absence.EtudiantId where Absence.valRetard = 1 AND CAST(Absence.dateAbsence AS DATE) = CAST(GETDATE() AS DATE)";

            c.dr = c.cmd.ExecuteReader();
            c.dt.Load(c.dr);
            dg_RE.ItemsSource = c.dt.DefaultView;
            c.dr.Close();

        }
        public String dateN = DateTime.Now.ToString("dd-MM-yyyy");



        private void btn_C_MouseDoubleClick(object sender, MouseButtonEventArgs e)

        {

            if (c.dt != null)
            {
                c.dt.Clear();
            }


            dg_Dash.Visibility = Visibility.Hidden;
            dg.Visibility = Visibility.Hidden;
            dg_ABS.Visibility = Visibility.Hidden;
            dg_JEE.Visibility = Visibility.Hidden;
            dg_FEBE.Visibility = Visibility.Hidden;
            dg_Classe1.Visibility = Visibility.Hidden;
            dg_Classe2.Visibility = Visibility.Hidden;
            dg_Classe3.Visibility = Visibility.Hidden;
            dg_Classe4.Visibility = Visibility.Hidden;
            dg_RE.Visibility = Visibility.Hidden;

            datetimepicker.Visibility = Visibility.Visible;
            lab_filtre.Visibility = Visibility.Visible;
            date_today.Visibility = Visibility.Visible;

            val_AbsM.Visibility = Visibility.Hidden;
            val_JSM.Visibility = Visibility.Hidden;
            val_JSVM.Visibility = Visibility.Hidden;

            cer_Ab.Visibility = Visibility.Hidden;
            cer_Js.Visibility = Visibility.Hidden;
            cer_V.Visibility = Visibility.Hidden;

            lab_tabs.Visibility = Visibility.Hidden;
            lab_tjs.Visibility = Visibility.Hidden;
            lab_tv.Visibility = Visibility.Hidden;

            rec_Ab.Visibility = Visibility.Hidden;
            rec_Js.Visibility = Visibility.Hidden;
            rec_V.Visibility = Visibility.Hidden;

            dg_C.Visibility = Visibility.Visible;



            c.cmd.CommandText = " SELECT Student.Fullname As Nom , Student.image, Classe.Classename As Classe from Student LEFT JOIN Classe ON Classe.ClasseId = Student.ClasseId  LEFT JOIN Absence ON Student.StudentId = Absence.EtudiantId where Absence.valAbsence = 1 AND Classe.ClasseId = 1 AND CAST(Absence.dateAbsence AS DATE) = CAST(GETDATE() AS DATE) ";

            c.dr = c.cmd.ExecuteReader();
            c.dt.Load(c.dr);
            dg_C.ItemsSource = c.dt.DefaultView;
            c.dr.Close();


        }
        private void btn_JEE_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (c.dt != null)
            {
                c.dt.Clear();
            }
            dg_Dash.Visibility = Visibility.Hidden;
            dg.Visibility = Visibility.Hidden;
            dg_ABS.Visibility = Visibility.Hidden;
            dg_C.Visibility = Visibility.Hidden;
            dg_FEBE.Visibility = Visibility.Hidden;
            dg_Classe1.Visibility = Visibility.Hidden;
            dg_Classe2.Visibility = Visibility.Hidden;
            dg_Classe3.Visibility = Visibility.Hidden;
            dg_Classe4.Visibility = Visibility.Hidden;
            dg_RE.Visibility = Visibility.Hidden;

            datetimepicker.Visibility = Visibility.Visible;
            lab_filtre.Visibility = Visibility.Visible;
            date_today.Visibility = Visibility.Visible;

            val_AbsM.Visibility = Visibility.Hidden;
            val_JSM.Visibility = Visibility.Hidden;
            val_JSVM.Visibility = Visibility.Hidden;

            cer_Ab.Visibility = Visibility.Hidden;
            cer_Js.Visibility = Visibility.Hidden;
            cer_V.Visibility = Visibility.Hidden;

            lab_tabs.Visibility = Visibility.Hidden;
            lab_tjs.Visibility = Visibility.Hidden;
            lab_tv.Visibility = Visibility.Hidden;

            rec_Ab.Visibility = Visibility.Hidden;
            rec_Js.Visibility = Visibility.Hidden;
            rec_V.Visibility = Visibility.Hidden;

            dg_JEE.Visibility = Visibility.Visible;

            c.cmd.CommandText = "SELECT Student.Fullname As Nom , Student.image, Classe.Classename As Classe from Student LEFT JOIN Classe ON Classe.ClasseId = Student.ClasseId  LEFT JOIN Absence ON Student.StudentId = Absence.EtudiantId where Absence.valAbsence = 1 AND Classe.ClasseId = 2 AND CAST(Absence.dateAbsence AS DATE) = CAST(GETDATE() AS DATE)";

            c.dr = c.cmd.ExecuteReader();
            c.dt.Load(c.dr);
            dg_JEE.ItemsSource = c.dt.DefaultView;
            c.dr.Close();

        }

        private void btn_FEBE_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (c.dt != null)
            {
                c.dt.Clear();
            }
            dg_Dash.Visibility = Visibility.Hidden;
            dg.Visibility = Visibility.Hidden;
            dg_ABS.Visibility = Visibility.Hidden;
            dg_C.Visibility = Visibility.Hidden;
            dg_JEE.Visibility = Visibility.Hidden;
            dg_Classe1.Visibility = Visibility.Hidden;
            dg_Classe2.Visibility = Visibility.Hidden;
            dg_Classe3.Visibility = Visibility.Hidden;
            dg_Classe4.Visibility = Visibility.Hidden;
            dg_RE.Visibility = Visibility.Hidden;

            datetimepicker.Visibility = Visibility.Visible;
            lab_filtre.Visibility = Visibility.Visible;
            date_today.Visibility = Visibility.Visible;

            val_AbsM.Visibility = Visibility.Hidden;
            val_JSM.Visibility = Visibility.Hidden;
            val_JSVM.Visibility = Visibility.Hidden;

            cer_Ab.Visibility = Visibility.Hidden;
            cer_Js.Visibility = Visibility.Hidden;
            cer_V.Visibility = Visibility.Hidden;

            lab_tabs.Visibility = Visibility.Hidden;
            lab_tjs.Visibility = Visibility.Hidden;
            lab_tv.Visibility = Visibility.Hidden;

            rec_Ab.Visibility = Visibility.Hidden;
            rec_Js.Visibility = Visibility.Hidden;
            rec_V.Visibility = Visibility.Hidden;

            dg_FEBE.Visibility = Visibility.Visible;
            c.cmd.CommandText = "SELECT Student.Fullname As Nom , Student.image, Classe.Classename As Classe from Student LEFT JOIN Classe ON Classe.ClasseId = Student.ClasseId  LEFT JOIN Absence ON Student.StudentId = Absence.EtudiantId where Absence.valAbsence = 1 AND Classe.ClasseId = 3 AND CAST(Absence.dateAbsence AS DATE) = CAST(GETDATE() AS DATE)";

            c.dr = c.cmd.ExecuteReader();
            c.dt.Load(c.dr);
            dg_FEBE.ItemsSource = c.dt.DefaultView;
            c.dr.Close();

        }
        private void btn_Classe1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (c.dt != null)
            {
                c.dt.Clear();
            }
            dg_Dash.Visibility = Visibility.Hidden;
            dg.Visibility = Visibility.Hidden;
            dg_ABS.Visibility = Visibility.Hidden;
            dg_C.Visibility = Visibility.Hidden;
            dg_JEE.Visibility = Visibility.Hidden;
            dg_FEBE.Visibility = Visibility.Hidden;
            dg_Classe2.Visibility = Visibility.Hidden;
            dg_Classe3.Visibility = Visibility.Hidden;
            dg_Classe4.Visibility = Visibility.Hidden;
            dg_RE.Visibility = Visibility.Hidden;

            datetimepicker.Visibility = Visibility.Visible;
            lab_filtre.Visibility = Visibility.Visible;
            date_today.Visibility = Visibility.Visible;

            val_AbsM.Visibility = Visibility.Hidden;
            val_JSM.Visibility = Visibility.Hidden;
            val_JSVM.Visibility = Visibility.Hidden;

            cer_Ab.Visibility = Visibility.Hidden;
            cer_Js.Visibility = Visibility.Hidden;
            cer_V.Visibility = Visibility.Hidden;

            lab_tabs.Visibility = Visibility.Hidden;
            lab_tjs.Visibility = Visibility.Hidden;
            lab_tv.Visibility = Visibility.Hidden;

            rec_Ab.Visibility = Visibility.Hidden;
            rec_Js.Visibility = Visibility.Hidden;
            rec_V.Visibility = Visibility.Hidden;

            dg_Classe1.Visibility = Visibility.Visible;
            c.cmd.CommandText = "SELECT Student.Fullname As Nom , Student.image, Classe.Classename As Classe from Student LEFT JOIN Classe ON Classe.ClasseId = Student.ClasseId  LEFT JOIN Absence ON Student.StudentId = Absence.EtudiantId where Absence.valAbsence = 1 AND Classe.ClasseId = 4 AND CAST(Absence.dateAbsence AS DATE) = CAST(GETDATE() AS DATE)";

            c.dr = c.cmd.ExecuteReader();
            c.dt.Load(c.dr);
            dg_Classe1.ItemsSource = c.dt.DefaultView;
            c.dr.Close();

        }
        private void btn_Classe2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (c.dt != null)
            {
                c.dt.Clear();
            }
            dg_Dash.Visibility = Visibility.Hidden;
            dg.Visibility = Visibility.Hidden;
            dg_ABS.Visibility = Visibility.Hidden;
            dg_C.Visibility = Visibility.Hidden;
            dg_JEE.Visibility = Visibility.Hidden;
            dg_FEBE.Visibility = Visibility.Hidden;
            dg_Classe1.Visibility = Visibility.Hidden;
            dg_Classe3.Visibility = Visibility.Hidden;
            dg_Classe4.Visibility = Visibility.Hidden;
            dg_RE.Visibility = Visibility.Hidden;

            datetimepicker.Visibility = Visibility.Visible;
            lab_filtre.Visibility = Visibility.Visible;
            date_today.Visibility = Visibility.Visible;

            val_AbsM.Visibility = Visibility.Hidden;
            val_JSM.Visibility = Visibility.Hidden;
            val_JSVM.Visibility = Visibility.Hidden;

            cer_Ab.Visibility = Visibility.Hidden;
            cer_Js.Visibility = Visibility.Hidden;
            cer_V.Visibility = Visibility.Hidden;

            lab_tabs.Visibility = Visibility.Hidden;
            lab_tjs.Visibility = Visibility.Hidden;
            lab_tv.Visibility = Visibility.Hidden;

            rec_Ab.Visibility = Visibility.Hidden;
            rec_Js.Visibility = Visibility.Hidden;
            rec_V.Visibility = Visibility.Hidden;

            dg_Classe2.Visibility = Visibility.Visible;
            c.cmd.CommandText = "SELECT Student.Fullname As Nom , Student.image, Classe.Classename As Classe from Student LEFT JOIN Classe ON Classe.ClasseId = Student.ClasseId  LEFT JOIN Absence ON Student.StudentId = Absence.EtudiantId where Absence.valAbsence = 1 AND Classe.ClasseId = 5 AND CAST(Absence.dateAbsence AS DATE) = CAST(GETDATE() AS DATE)";

            c.dr = c.cmd.ExecuteReader();
            c.dt.Load(c.dr);
            dg_Classe2.ItemsSource = c.dt.DefaultView;
            c.dr.Close();

        }
        private void btn_Classe3_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (c.dt != null)
            {
                c.dt.Clear();
            }
            dg_Dash.Visibility = Visibility.Hidden;
            dg.Visibility = Visibility.Hidden;
            dg_ABS.Visibility = Visibility.Hidden;
            dg_C.Visibility = Visibility.Hidden;
            dg_JEE.Visibility = Visibility.Hidden;
            dg_FEBE.Visibility = Visibility.Hidden;
            dg_Classe1.Visibility = Visibility.Hidden;
            dg_Classe2.Visibility = Visibility.Hidden;
            dg_Classe4.Visibility = Visibility.Hidden;
            dg_RE.Visibility = Visibility.Hidden;

            val_AbsM.Visibility = Visibility.Hidden;
            val_JSM.Visibility = Visibility.Hidden;
            val_JSVM.Visibility = Visibility.Hidden;

            datetimepicker.Visibility = Visibility.Visible;
            lab_filtre.Visibility = Visibility.Visible;
            date_today.Visibility = Visibility.Visible;

            cer_Ab.Visibility = Visibility.Hidden;
            cer_Js.Visibility = Visibility.Hidden;
            cer_V.Visibility = Visibility.Hidden;

            lab_tabs.Visibility = Visibility.Hidden;
            lab_tjs.Visibility = Visibility.Hidden;
            lab_tv.Visibility = Visibility.Hidden;

            rec_Ab.Visibility = Visibility.Hidden;
            rec_Js.Visibility = Visibility.Hidden;
            rec_V.Visibility = Visibility.Hidden;

            dg_Classe3.Visibility = Visibility.Visible;
            c.cmd.CommandText = "SELECT Student.Fullname As Nom , Student.image, Classe.Classename As Classe from Student LEFT JOIN Classe ON Classe.ClasseId = Student.ClasseId  LEFT JOIN Absence ON Student.StudentId = Absence.EtudiantId where Absence.valAbsence = 1 AND Classe.ClasseId = 6 AND CAST(Absence.dateAbsence AS DATE) = CAST(GETDATE() AS DATE)";

            c.dr = c.cmd.ExecuteReader();
            c.dt.Load(c.dr);
            dg_Classe3.ItemsSource = c.dt.DefaultView;
            c.dr.Close();
        }
        private void btn_Classe4_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (c.dt != null)
            {
                c.dt.Clear();
            }
            dg_Dash.Visibility = Visibility.Hidden;
            dg.Visibility = Visibility.Hidden;
            dg_ABS.Visibility = Visibility.Hidden;
            dg_C.Visibility = Visibility.Hidden;
            dg_JEE.Visibility = Visibility.Hidden;
            dg_FEBE.Visibility = Visibility.Hidden;
            dg_Classe1.Visibility = Visibility.Hidden;
            dg_Classe2.Visibility = Visibility.Hidden;
            dg_Classe3.Visibility = Visibility.Hidden;
            dg_RE.Visibility = Visibility.Hidden;

            datetimepicker.Visibility = Visibility.Visible;
            lab_filtre.Visibility = Visibility.Visible;
            date_today.Visibility = Visibility.Visible;

            val_AbsM.Visibility = Visibility.Hidden;
            val_JSM.Visibility = Visibility.Hidden;
            val_JSVM.Visibility = Visibility.Hidden;

            cer_Ab.Visibility = Visibility.Hidden;
            cer_Js.Visibility = Visibility.Hidden;
            cer_V.Visibility = Visibility.Hidden;

            lab_tabs.Visibility = Visibility.Hidden;
            lab_tjs.Visibility = Visibility.Hidden;
            lab_tv.Visibility = Visibility.Hidden;

            rec_Ab.Visibility = Visibility.Hidden;
            rec_Js.Visibility = Visibility.Hidden;
            rec_V.Visibility = Visibility.Hidden;

            dg_Classe4.Visibility = Visibility.Visible;
            c.cmd.CommandText = "SELECT Student.Fullname As Nom , Student.image, Classe.Classename As Classe from Student LEFT JOIN Classe ON Classe.ClasseId = Student.ClasseId  LEFT JOIN Absence ON Student.StudentId = Absence.EtudiantId where Absence.valAbsence = 1 AND Classe.ClasseId = 7 AND CAST(Absence.dateAbsence AS DATE) = CAST(GETDATE() AS DATE)";

            c.dr = c.cmd.ExecuteReader();
            c.dt.Load(c.dr);
            dg_Classe4.ItemsSource = c.dt.DefaultView;
            c.dr.Close();
        }
        private void SideMenuItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void btn_presents_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=DESKTOP-OA38PF8;Initial Catalog=Attendance-Management;Integrated Security=True";
            String QuerySelect = "SELECT COUNT(dateAbsence) FROM Absence WHERE Absence.valPresence=1 AND CAST(Absence.dateAbsence AS DATE) = CAST(GETDATE() AS DATE)";
            SqlCommand cmd = new SqlCommand(QuerySelect, cnx);
            cnx.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                ValP.Content = data[0];
            }


        }

        private void btn_retards_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=DESKTOP-OA38PF8;Initial Catalog=Attendance-Management;Integrated Security=True";
            String QuerySelect = "SELECT COUNT(dateAbsence) FROM Absence WHERE Absence.valRetard=1 AND CAST(Absence.dateAbsence AS DATE) = CAST(GETDATE() AS DATE)";
            SqlCommand cmd = new SqlCommand(QuerySelect, cnx);
            cnx.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                valR.Content = data[0];
            }
        }

        private void btn_absents_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=DESKTOP-OA38PF8;Initial Catalog=Attendance-Management;Integrated Security=True";
            String QuerySelect = "SELECT COUNT(dateAbsence) FROM Absence WHERE Absence.valAbsence=1 AND CAST(Absence.dateAbsence AS DATE) = CAST(GETDATE() AS DATE)";
            SqlCommand cmd = new SqlCommand(QuerySelect, cnx);
            cnx.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                valA.Content = data[0];
            }
        }

        public void abs_chk_Checked(object sender, RoutedEventArgs e)

        {

            var row = dg_ABS.SelectedItem as DataRowView;
            var id = row.Row[0].ToString();
            int value = 1;
            int Unvalue = 0;


            int v = 1;

            switch (v)
            {
                case 0:
                    c.connecter();
                    c.cmd.CommandText = $"INSERT INTO Justification ( jusV, jusNV, AbsenceId ) values ( '{value}','{Unvalue}', '{id}') ";
                    c.cmd.Connection = c.con;
                    c.dr = c.cmd.ExecuteReader();
                    c.dt.Load(c.dr);
                    dg_ABS.ItemsSource = c.dt.DefaultView;
                    c.dr.Close();
                    break;
                case 1:
                    c.connecter();
                    c.cmd.CommandText = $"INSERT INTO Justification ( jusV, jusNV, AbsenceId ) values ( '{Unvalue}','{value}', '{id}') ";
                    c.cmd.Connection = c.con;
                    c.dr = c.cmd.ExecuteReader();
                    c.dt.Load(c.dr);
                    dg_ABS.ItemsSource = c.dt.DefaultView;
                    c.dr.Close();
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }




        }

        private void abs_chk_Unchecked(object sender, RoutedEventArgs e)
        {
            var row = dg_ABS.SelectedItem as DataRowView;
            var id = row.Row[0].ToString();

            c.connecter();
            c.cmd.CommandText = "DELETE FROM Absence WHERE EtudiantId = '" + id + "' ";
            c.cmd.Connection = c.con;
            c.dr = c.cmd.ExecuteReader();
            c.dt.Load(c.dr);
            dg_ABS.ItemsSource = c.dt.DefaultView;
            c.dr.Close();
        }
        private void datetimepicker1(object sender, KeyEventArgs e)
        {

        }

    }
}
