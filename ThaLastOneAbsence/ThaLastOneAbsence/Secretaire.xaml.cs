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





       

        private void btn_abs_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (c.dt != null)
            {
                c.dt.Clear();
            }

            dg.Visibility = Visibility.Hidden;
            dg2.Visibility = Visibility.Hidden;
            dg1.Visibility = Visibility.Visible;
            dg_C.Visibility = Visibility.Hidden;
            dg_JEE.Visibility = Visibility.Hidden;
            dg_FEBE.Visibility = Visibility.Hidden;
            dg_Classe1.Visibility = Visibility.Hidden;
            dg_Classe2.Visibility = Visibility.Hidden;
            dg_Classe3.Visibility = Visibility.Hidden;
            dg_Classe4.Visibility = Visibility.Hidden;
            c.cmd.CommandText = " SELECT Student.Fullname As Nom , Student.image, Classe.Classename As Classe from Student LEFT JOIN Classe ON Classe.ClasseId = Student.ClasseId  LEFT JOIN Absence ON Student.StudentId = Absence.EtudiantId where Absence.valAbsence = 1";

            c.dr = c.cmd.ExecuteReader();
            c.dt.Load(c.dr);
            dg1.ItemsSource = c.dt.DefaultView;
            c.dr.Close();

        }

        private void btn_ret_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (c.dt != null)
            {
                c.dt.Clear();
            }

            dg.Visibility = Visibility.Hidden;
            dg1.Visibility = Visibility.Hidden;
            dg_C.Visibility = Visibility.Hidden;
            dg_JEE.Visibility = Visibility.Hidden;
            dg_FEBE.Visibility = Visibility.Hidden;
            dg_Classe1.Visibility = Visibility.Hidden;
            dg_Classe2.Visibility = Visibility.Hidden;
            dg_Classe3.Visibility = Visibility.Hidden;
            dg_Classe4.Visibility = Visibility.Hidden;


            dg2.Visibility = Visibility.Visible;
            c.cmd.CommandText = " SELECT Student.Fullname As Nom , Student.image, Classe.Classename As Classe from Student LEFT JOIN Classe ON Classe.ClasseId = Student.ClasseId  LEFT JOIN Absence ON Student.StudentId = Absence.EtudiantId where Absence.valRetard = 1 ";

            c.dr = c.cmd.ExecuteReader();
            c.dt.Load(c.dr);
            dg2.ItemsSource = c.dt.DefaultView;
            c.dr.Close();

        }
        private void btn_C_MouseDoubleClick(object sender, MouseButtonEventArgs e)

        {
            if (c.dt != null)
            {
                c.dt.Clear();
            }
            dg.Visibility = Visibility.Hidden;
            dg1.Visibility = Visibility.Hidden;
            dg_JEE.Visibility = Visibility.Hidden;
            dg_FEBE.Visibility = Visibility.Hidden;
            dg_Classe1.Visibility = Visibility.Hidden;
            dg_Classe2.Visibility = Visibility.Hidden;
            dg_Classe3.Visibility = Visibility.Hidden;
            dg_Classe4.Visibility = Visibility.Hidden;
            dg2.Visibility = Visibility.Hidden;


            dg_C.Visibility = Visibility.Visible;
            c.cmd.CommandText = " SELECT Student.Fullname As Nom , Student.image, Classe.Classename As Classe from Student LEFT JOIN Classe ON Classe.ClasseId = Student.ClasseId  LEFT JOIN Absence ON Student.StudentId = Absence.EtudiantId where Absence.valAbsence = 1 AND Classe.ClasseId = 1";

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
            dg.Visibility = Visibility.Hidden;
            dg1.Visibility = Visibility.Hidden;
            dg_C.Visibility = Visibility.Hidden;
            dg_FEBE.Visibility = Visibility.Hidden;
            dg_Classe1.Visibility = Visibility.Hidden;
            dg_Classe2.Visibility = Visibility.Hidden;
            dg_Classe3.Visibility = Visibility.Hidden;
            dg_Classe4.Visibility = Visibility.Hidden;
            dg2.Visibility = Visibility.Hidden;


            dg_JEE.Visibility = Visibility.Visible;

            c.cmd.CommandText = "SELECT Student.Fullname As Nom , Student.image, Classe.Classename As Classe from Student LEFT JOIN Classe ON Classe.ClasseId = Student.ClasseId  LEFT JOIN Absence ON Student.StudentId = Absence.EtudiantId where Absence.valAbsence = 1 AND Classe.ClasseId = 2";

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
            dg.Visibility = Visibility.Hidden;
            dg1.Visibility = Visibility.Hidden;
            dg_C.Visibility = Visibility.Hidden;
            dg_JEE.Visibility = Visibility.Hidden;
            dg_Classe1.Visibility = Visibility.Hidden;
            dg_Classe2.Visibility = Visibility.Hidden;
            dg_Classe3.Visibility = Visibility.Hidden;
            dg_Classe4.Visibility = Visibility.Hidden;
            dg2.Visibility = Visibility.Hidden;


            dg_FEBE.Visibility = Visibility.Visible;
            c.cmd.CommandText = "SELECT Student.Fullname As Nom , Student.image, Classe.Classename As Classe from Student LEFT JOIN Classe ON Classe.ClasseId = Student.ClasseId  LEFT JOIN Absence ON Student.StudentId = Absence.EtudiantId where Absence.valAbsence = 1 AND Classe.ClasseId = 3";

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
            dg.Visibility = Visibility.Hidden;
            dg1.Visibility = Visibility.Hidden;
            dg_C.Visibility = Visibility.Hidden;
            dg_JEE.Visibility = Visibility.Hidden;
            dg_FEBE.Visibility = Visibility.Hidden;
            dg_Classe2.Visibility = Visibility.Hidden;
            dg_Classe3.Visibility = Visibility.Hidden;
            dg_Classe4.Visibility = Visibility.Hidden;
            dg2.Visibility = Visibility.Hidden;


            dg_Classe1.Visibility = Visibility.Visible;
            c.cmd.CommandText = "SELECT Student.Fullname As Nom , Student.image, Classe.Classename As Classe from Student LEFT JOIN Classe ON Classe.ClasseId = Student.ClasseId  LEFT JOIN Absence ON Student.StudentId = Absence.EtudiantId where Absence.valAbsence = 1 AND Classe.ClasseId = 4";

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
            dg.Visibility = Visibility.Hidden;
            dg1.Visibility = Visibility.Hidden;
            dg_C.Visibility = Visibility.Hidden;
            dg_JEE.Visibility = Visibility.Hidden;
            dg_FEBE.Visibility = Visibility.Hidden;
            dg_Classe1.Visibility = Visibility.Hidden;
            dg_Classe3.Visibility = Visibility.Hidden;
            dg_Classe4.Visibility = Visibility.Hidden;
            dg2.Visibility = Visibility.Hidden;


            dg_Classe2.Visibility = Visibility.Visible;
            c.cmd.CommandText = "SELECT Student.Fullname As Nom , Student.image, Classe.Classename As Classe from Student LEFT JOIN Classe ON Classe.ClasseId = Student.ClasseId  LEFT JOIN Absence ON Student.StudentId = Absence.EtudiantId where Absence.valAbsence = 1 AND Classe.ClasseId = 5";

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
            dg.Visibility = Visibility.Hidden;
            dg1.Visibility = Visibility.Hidden;
            dg_C.Visibility = Visibility.Hidden;
            dg_JEE.Visibility = Visibility.Hidden;
            dg_FEBE.Visibility = Visibility.Hidden;
            dg_Classe1.Visibility = Visibility.Hidden;
            dg_Classe2.Visibility = Visibility.Hidden;
            dg_Classe4.Visibility = Visibility.Hidden;
            dg2.Visibility = Visibility.Hidden;


            dg_Classe3.Visibility = Visibility.Visible;
            c.cmd.CommandText = "SELECT Student.Fullname As Nom , Student.image, Classe.Classename As Classe from Student LEFT JOIN Classe ON Classe.ClasseId = Student.ClasseId  LEFT JOIN Absence ON Student.StudentId = Absence.EtudiantId where Absence.valAbsence = 1 AND Classe.ClasseId = 6";

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
            dg.Visibility = Visibility.Hidden;
            dg1.Visibility = Visibility.Hidden;
            dg_C.Visibility = Visibility.Hidden;
            dg_JEE.Visibility = Visibility.Hidden;
            dg_FEBE.Visibility = Visibility.Hidden;
            dg_Classe1.Visibility = Visibility.Hidden;
            dg_Classe2.Visibility = Visibility.Hidden;
            dg_Classe3.Visibility = Visibility.Hidden;
            dg2.Visibility = Visibility.Hidden;


            dg_Classe4.Visibility = Visibility.Visible;
            c.cmd.CommandText = "SELECT Student.Fullname As Nom , Student.image, Classe.Classename As Classe from Student LEFT JOIN Classe ON Classe.ClasseId = Student.ClasseId  LEFT JOIN Absence ON Student.StudentId = Absence.EtudiantId where Absence.valAbsence = 1 AND Classe.ClasseId = 7";

            c.dr = c.cmd.ExecuteReader();
            c.dt.Load(c.dr);
            dg_Classe4.ItemsSource = c.dt.DefaultView;
            c.dr.Close();
        }
        private void SideMenuItem_Selected(object sender, RoutedEventArgs e)
        {

        }

    }
}
