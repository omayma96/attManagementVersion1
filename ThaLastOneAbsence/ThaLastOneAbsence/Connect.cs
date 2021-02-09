using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ThaLastOneAbsence
{
    class Connect
    {
        public SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader dr;
        public DataTable dt = new DataTable();
        public DataTable dmt = new DataTable();
        public DataTable dat = new DataTable();


        public void connecter()
        {
            if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
            {
                con.ConnectionString = @"Data Source=DESKTOP-122P6H8\SQLEXPRESS;Initial Catalog=AttManagement;Integrated Security=True";
                con.Open();
            }
        }
    }
}
