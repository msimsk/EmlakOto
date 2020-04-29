using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EmlakOto
{
    public class SqlBaglantisi
    {

        public SqlConnection Baglanti()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=EmlakVT;Integrated Security=True");
            baglanti.Open();
            return baglanti;
        }

    }
}
