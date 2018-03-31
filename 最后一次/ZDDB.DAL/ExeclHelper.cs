using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;


namespace ZDDB.DAL
{
    public class ExeclHelper
    {
        public static DataSet ImportXlsToData(string fileName)
        {
            DataSet ds = new DataSet();
            try
            {
                string connStr = string.Empty;

                connStr = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + fileName + ";Extended Properties='Excel 8.0; HDR=YES; IMEX=1'";

                OleDbConnection conn = new OleDbConnection(connStr);
                string query = "select * from [sheet1$]";
                OleDbCommand com = new OleDbCommand(query, conn);
                OleDbDataAdapter ad = new OleDbDataAdapter(com);
                ad.Fill(ds);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }
    }
}
