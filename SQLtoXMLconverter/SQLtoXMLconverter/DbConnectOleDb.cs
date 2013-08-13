using System.Data;
using System.Data.OleDb;
using System.Collections;
using System;

public class BdConnectOleDb
{
    static public DataSet GetData(string strConnection, string strSQL)        // Connect to BD
    {
        using (OleDbConnection objConnection = new OleDbConnection(strConnection))
        {
            objConnection.Open();
            DataSet ds = new DataSet();
            OleDbCommand cmd = new OleDbCommand(strSQL, objConnection);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;

            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                ds.Clear();
            }
            objConnection.Close();
            return ds;
        }
    }

}