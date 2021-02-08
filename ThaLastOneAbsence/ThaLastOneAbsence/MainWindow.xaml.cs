using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using HandyControl.Data;
using HandyControl.Themes;
using HandyControl.Tools;
using System.Windows.Markup;
using System.ComponentModel;
using System.Net;


namespace ThaLastOneAbsence
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Connect c = new Connect();
        private void btn_cn_Click(object sender, RoutedEventArgs e)
        {
            if (role.Text == "Formateur")
            {
                c.connecter();
                c.cmd.CommandText = "SELECT * FROM  Formateur WHERE email= '" + inp_mail.Text + "' and password = '" + passBox.Password + "' ";
                c.cmd.Connection = c.con;
                c.dr = c.cmd.ExecuteReader();
                while (c.dr.Read())
                {
                    Formateur f = new Formateur();
                    f.Show();
                    f.ShowDT(c.dr[0].ToString());
                    
                }


                c.dr.Close();
            }
            else if (role.Text== "Apprenant")
            {
                c.connecter();
                c.cmd.CommandText = "SELECT * FROM  Student WHERE Email= '" + inp_mail.Text + "' and password = '" + passBox.Password + "' ";
                c.cmd.Connection = c.con;
                c.dr = c.cmd.ExecuteReader();
                while (c.dr.Read())
                {
                    Etudiant E = new Etudiant();
                    E.Show();
                    E.getTotlaAbs(c.dr[0].ToString());
                    E.getTotlaAbsJus(c.dr[0].ToString());
                    E.getTotlaAbsNoJus(c.dr[0].ToString());
                    E.GetInfoEtudiant(c.dr[0].ToString());

                }
            }

            else if (role.Text == "Secretaire")

            {
                c.connecter();
                c.cmd.CommandText = "SELECT * FROM  Secretaire WHERE Email= '" + inp_mail.Text + "' and password = '" + passBox.Password + "' ";
                c.cmd.Connection = c.con;
                c.dr = c.cmd.ExecuteReader();
                while (c.dr.Read())
                {
                   Secretaire s = new Secretaire();
                    s.Show();
                    

                }
            }
            else if (role.Text == "Admin")

            {
                c.connecter();
                c.cmd.CommandText = "SELECT * FROM  Admin WHERE Email= '" + inp_mail.Text + "' and password = '" + passBox.Password + "' ";
                c.cmd.Connection = c.con;
                c.dr = c.cmd.ExecuteReader();
                while (c.dr.Read())
                {
                    Admin a =new Admin();
                    a.Show();


                }
            }




            /*  var name = c.dt.Rows[0][0].ToString();
              MessageBox.Show(name);*/

            /* if (c.dr.HasRows)
             {
                  c.dr.Read();
                 int StudentId = c.dr.GetInt32(0);
                 MessageBox.Show(StudentId.ToString());
                 // Call Close when done reading.
                 c.dr.Close();

             }*/






        }

        private void combotype_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
