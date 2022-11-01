using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG2B_POE.Classes
{
    public class Connection
    {
        public static SqlConnection GetConeection()
        {
            string fileName = "StudentDB.mdf";
            string filePath = Path.GetFullPath(fileName).Replace(@"\bin\Debug", @"\Data");
            string strCon = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={filePath};Integrated Security=True";

            return new SqlConnection(strCon);
        }
    }
}
